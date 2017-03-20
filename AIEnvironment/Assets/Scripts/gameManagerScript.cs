using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerScript : MonoBehaviour {

	List<GameObject> nodes;
	GameObject agent;

    // AStar attributes
    GameObject aStarAgent;

    GameObject[] nodeArray;

    [SerializeField]
    GameObject goal;

	PriorityQueue open;

    bool pathCalculated = false;

    // flocker attributes
	List<Flocker> flockers;
	public List<Flocker> Flockers {
		get {
			return flockers;
		}
	}

	Vector3 flockCenter;
	public Vector3 FlockCenter {
		get {
			return flockCenter;
		}
	}

	// Use this for initialization
	void Start () {
		open = new PriorityQueue ();
        nodeArray = GameObject.FindGameObjectsWithTag("Node");
        aStarAgent = GameObject.Find("aStarAgent");
		open.Setup ();
	}
	
	// Update is called once per frame
	void Update () {
        if (!pathCalculated)
        {
            aStarAgent.GetComponent<PathFollower>().Targets = pathfindAStar(goal);
            aStarAgent.GetComponent<PathFollower>().currentTarget = aStarAgent.GetComponent<PathFollower>().Targets[0];
            pathCalculated = true;
        }
            
		if (Input.GetKeyDown (KeyCode.Escape)) {
			quitGame ();
		}
		if(Input.GetKeyDown(KeyCode.P))
		{
			pauseGame ();
		}
	}

	void GetFlockCenter() {
		Vector3 center = Vector3.zero;
		foreach (Flocker f in flockers) {
			center += f.transform.position;
		}

		center = center / flockers.Count;
		flockCenter = center;
	}


	public void quitGame()
	{
		//If we are running in a standalone build of the game
		#if UNITY_STANDALONE
		//Quit the application
		Application.Quit();
		#endif

		//If we are running in the editor
		#if UNITY_EDITOR
		//Stop playing the scene
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}

	public void pauseGame()
	{
		//If we are running in a standalone build of the game
		#if UNITY_STANDALONE
		//Quit the application
		//
		#endif

		//If we are running in the editor
		#if UNITY_EDITOR
		//Stop playing the scene
		Debug.Break();
		#endif
	}

    #region AStar
    private List<GameObject> pathfindAStar(GameObject goal) // NOTE: return found path
    {
        // find start of path
        GameObject closestNode = nodeArray[0];

        for (int i = 0; i <nodeArray.Length; i++)
        {
            float oldDistance = (closestNode.transform.position - aStarAgent.transform.position).magnitude;
            float distance = (nodeArray[i].transform.position - aStarAgent.transform.position).magnitude;

            // new node is closer
            if (distance < oldDistance)
            {
                closestNode = nodeArray[i];
            }
        }

        // declare start node
        GameObject startNode = closestNode;
        GameObject currentNode = null;
        // total cost should be updated with each node calculated
        float totalCost = 0f;

        // for keeping track of backtrace
        List<GameObject> backtrace = new List<GameObject>();

        // make closed list
        List<GameObject> closed = new List<GameObject>();

        // push start onto queue
        open.push(totalCost, startNode);

        // loop through open node list
        while(open.Count > 0)
        {
            currentNode = open.pop();
            nodeScript currentNodeRecord = currentNode.GetComponent<nodeScript>();

            if (currentNode == goal)
            {
                Debug.Log("End reached at node " + currentNode.name);
                break;
            }

            foreach(GameObject endNode in currentNodeRecord.neighbors)
            {
                // get nodeScript on endNode, represents node record
                nodeScript endNodeRecord = endNode.GetComponent<nodeScript>();

                // calculate cost between current and current neighbor
                float cost = CalcCost(currentNode, endNode);
                float endNodeCost = currentNodeRecord.CostSoFar + cost;
                float endNodeHueristic = 0;

                if (closed.Contains(endNode))
                {
                    int closedIndex = closed.IndexOf(endNode);

                    GameObject closedEndNode = closed[closedIndex];

                    if (endNodeRecord.CostSoFar <= endNodeCost)
                        continue;

                    closed.Remove(endNode);
                    endNodeHueristic = cost - endNodeRecord.CostSoFar;
                }
                else if (open.Contains(endNode))
                {
                    GameObject openNeighbor = open.Find(endNode);

                    if (endNodeRecord.CostSoFar <= endNodeCost)
                        continue;

                    endNodeHueristic = cost - endNodeRecord.CostSoFar;
                }
                else
                {
                    // calculate hueristic
                    endNodeHueristic = CalcCost(endNode, goal);
                }

                endNodeRecord.Cost = endNodeCost;
                endNodeRecord.Connection = currentNode;
                endNodeRecord.EstimatedTotalCost = endNodeCost + endNodeHueristic;

                if (!open.Contains(endNode))
                    open.push(endNodeRecord.Cost, endNode);
            }

            // finished looking at connections, add to closed list
            closed.Add(currentNode);
        }

        if (currentNode != goal)
            return null;
        else
        {
            backtrace.Add(goal);
            while (currentNode != startNode)
            {
                backtrace.Add(currentNode.GetComponent<nodeScript>().Connection);

                currentNode = currentNode.GetComponent<nodeScript>().Connection;
            }

            backtrace.Reverse();
            return backtrace;
        }
    }

    private float CalcCost(GameObject current, GameObject neighbor)
    {
        return (neighbor.transform.position - current.transform.position).magnitude;
    }
    #endregion

}
