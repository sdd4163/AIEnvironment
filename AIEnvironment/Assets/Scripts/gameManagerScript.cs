using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerScript : MonoBehaviour {

    // for use in initializing our grid
    const int NUM_ROWS = 11;
    const int NUM_COLS = 11;
    const int NUM_NODES = NUM_COLS * NUM_ROWS;

	//List<GameObject> nodes;
	//GameObject agent;

    // AStar attributes
    //GameObject aStarAgent;

    // 2 Dimensional grid to hold each node
    GameObject[,] grid;

    // node prefab
    [SerializeField]
    GameObject node;

    //[SerializeField]
    //GameObject goal;

	//PriorityQueue open;

    //bool pathCalculated = false;

    // flocker attributes
	//[SerializeField]
	//GameObject flockerPrefab;
    //
	//[SerializeField]
	//GameObject flockerSpawn;
    //
	//int flockCount = 25;
	//public int FlockCount {
	//	get {
	//		return flockCount;
	//	}
	//}
    //
	//List<Flocker> flockers;
	//public List<Flocker> Flockers {
	//	get {
	//		return flockers;
	//	}
	//}
	//Vector3 flockCenter;
	//public Vector3 FlockCenter {
	//	get {
	//		return flockCenter;
	//	}
	//}

	// Use this for initialization
	void Awake () {
        //open = new PriorityQueue ();
        //nodeArray = GameObject.FindGameObjectsWithTag("Node");
        //aStarAgent = GameObject.Find("aStarAgent");
        //open.Setup ();
        //
        //flockers = new List<Flocker> ();
        //for (int i = 0; i < flockCount; i++) {
        //	Vector3 pos = flockerSpawn.transform.position;
        //	pos.x += Random.Range (-flockCount, flockCount);
        //	pos.z += Random.Range (-flockCount, flockCount);
        //	GameObject tempF = GameObject.Instantiate (flockerPrefab, pos, Quaternion.identity); 
        //	flockers.Add(tempF.GetComponent<Flocker> ());
        //	flockers [i].Initialize (0.85f, 0.15f, 0.1f, 0.3f);
        //}

        // initialize grid
		grid = new GameObject[NUM_ROWS, NUM_COLS];
		Vector3 pos = new Vector3(500 / NUM_COLS / 2, 100, 500 / NUM_ROWS / 2); // pos will be incremented to spawn new nodes at certain spots

		for (int i = 0; i < NUM_ROWS; i++)
		{
			for (int j = 0; j < NUM_COLS; j++)
			{
				grid[i, j] = GameObject.Instantiate(node, pos, Quaternion.identity);

				// drop the node
				grid[i, j].GetComponent<nodeScript>().Drop();

				// increment the position
				pos.x += 500 / NUM_COLS;
			}
			pos.x = 500 / NUM_COLS / 2;
			pos.z += 500 / NUM_ROWS;
		}
	}
	
	// Update is called once per frame
	void Update () {

		//GetFlockCenter ();
        //if (!pathCalculated)
        //{
        //    aStarAgent.GetComponent<PathFollower>().Targets = pathfindAStar(goal);
        //    aStarAgent.GetComponent<PathFollower>().currentTarget = aStarAgent.GetComponent<PathFollower>().Targets[0];
		//	aStarAgent.GetComponent<PathFollower> ().moving = true;
        //    pathCalculated = true;
        //}
            
		if (Input.GetKeyDown (KeyCode.Escape)) {
			quitGame ();
		}
		if(Input.GetKeyDown(KeyCode.P))
		{
			pauseGame ();
		}
		if(Input.GetKeyDown(KeyCode.M))
		{
			GenerateInfluenceMap ();
		}
		//Modify flocking params
		//if (Input.GetKeyDown (KeyCode.Alpha1)) {
		//	ModCohesion ();
		//}
		//else if (Input.GetKeyDown (KeyCode.Alpha2)) {
		//	ModCohesion (true);
		//}
		//if (Input.GetKeyDown (KeyCode.Alpha3)) {
		//	ModSeparation ();
		//}
		//else if (Input.GetKeyDown (KeyCode.Alpha4)) {
		//	ModSeparation (true);
		//}
		//if (Input.GetKeyDown (KeyCode.Alpha5)) {
		//	ModSeek ();
		//}
		//else if (Input.GetKeyDown (KeyCode.Alpha6)) {
		//	ModSeek (true);
		//}
	}

	void GenerateInfluenceMap() {
		Unit[] units = GameObject.Find ("Units").GetComponentsInChildren<Unit> ();
		foreach (GameObject go in grid) {
			Vector2 gridPos2D = new Vector2 (go.transform.position.x, go.transform.position.z);
			float grnInf = 0.0f;
			float redInf = 0.0f;
			foreach (Unit u in units) {
				float influence = u.strength / (Vector2.Distance (gridPos2D, u.pos2D) + 1);
				if (influence < 0.01f) {
					continue;
				}
				if (u.teamColor == 'g') {
					grnInf += influence;
				} else {
					redInf += influence;
				}
			}
			if (grnInf > redInf) {
				go.GetComponent<nodeScript> ().CurrentTeam = nodeScript.Team.GREEN;
			} else if (redInf > grnInf) {
				go.GetComponent<nodeScript> ().CurrentTeam = nodeScript.Team.RED;
			} else {
				go.GetComponent<nodeScript> ().CurrentTeam = nodeScript.Team.GRAY;
			}
		}
	}

	//void GetFlockCenter() {
	//	Vector3 center = Vector3.zero;
	//	foreach (Flocker f in flockers) {
	//		center += f.transform.position;
	//	}
    //
	//	center = center / flockers.Count;
	//	flockCenter = center;
	//}
    //
	//void ModCohesion(bool negative = false) {
	//	foreach (Flocker f in flockers) {
	//		if (negative) {
	//			f.CohesionWgt -= .05f;
	//		} else {
	//			f.CohesionWgt += .05f;
	//		}
	//		if (f.CohesionWgt < 0.05f) {
	//			f.CohesionWgt = 0.05f;
	//		}
	//	}
	//}

	//void ModSeparation(bool negative = false) {
	//	foreach (Flocker f in flockers) {
	//		if (negative) {
	//			f.SeparationWgt -= .05f;
	//		} else {
	//			f.SeparationWgt += .05f;
	//		}
	//		if (f.SeparationWgt < 0.05f) {
	//			f.SeparationWgt = 0.05f;
	//		}
	//	}
	//}

	//void ModSeek(bool negative = false) {
	//	foreach (Flocker f in flockers) {
	//		if (negative) {
	//			f.SeekWgt -= .05f;
	//		} else {
	//			f.SeekWgt += .05f;
	//		}
	//		if (f.SeekWgt < 0.05f) {
	//			f.SeekWgt = 0.05f;
	//		}
	//	}
	//}

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
    //private List<GameObject> pathfindAStar(GameObject goal) // NOTE: return found path
    //{
    //    // find start of path
    //    GameObject closestNode = nodeArray[0];
    //
    //    for (int i = 0; i <nodeArray.Length; i++)
    //    {
    //        float oldDistance = (closestNode.transform.position - aStarAgent.transform.position).magnitude;
    //        float distance = (nodeArray[i].transform.position - aStarAgent.transform.position).magnitude;
    //
    //        // new node is closer
    //        if (distance < oldDistance)
    //        {
    //            closestNode = nodeArray[i];
    //        }
    //    }
    //
    //    // declare start node
    //    GameObject startNode = closestNode;
    //    GameObject currentNode = null;
    //    // total cost should be updated with each node calculated
    //    float totalCost = 0f;
    //
    //    // for keeping track of backtrace
    //    List<GameObject> backtrace = new List<GameObject>();
    //
    //    // make closed list
    //    List<GameObject> closed = new List<GameObject>();
    //
    //    // push start onto queue
    //    open.push(totalCost, startNode);
    //
    //    // loop through open node list
    //    while(open.Count > 0)
    //    {
    //        currentNode = open.pop();
    //        nodeScript currentNodeRecord = currentNode.GetComponent<nodeScript>();
    //
    //        if (currentNode == goal)
    //        {
    //            Debug.Log("End reached at node " + currentNode.name);
    //            break;
    //        }
    //
    //        foreach(GameObject endNode in currentNodeRecord.neighbors)
    //        {
    //            // get nodeScript on endNode, represents node record
    //            nodeScript endNodeRecord = endNode.GetComponent<nodeScript>();
    //
    //            // calculate cost between current and current neighbor
    //            float cost = CalcCost(currentNode, endNode);
    //            float endNodeCost = currentNodeRecord.CostSoFar + cost;
    //            float endNodeHueristic = 0;
    //
    //            if (closed.Contains(endNode))
    //            {
    //                int closedIndex = closed.IndexOf(endNode);
    //
    //                GameObject closedEndNode = closed[closedIndex];
    //
    //                if (endNodeRecord.CostSoFar <= endNodeCost)
    //                    continue;
    //
    //                closed.Remove(endNode);
    //                endNodeHueristic = cost - endNodeRecord.CostSoFar;
    //            }
    //            else if (open.Contains(endNode))
    //            {
    //                GameObject openNeighbor = open.Find(endNode);
    //
    //                if (endNodeRecord.CostSoFar <= endNodeCost)
    //                    continue;
    //
    //                endNodeHueristic = cost - endNodeRecord.CostSoFar;
    //            }
    //            else
    //            {
    //                // calculate hueristic
    //                endNodeHueristic = CalcCost(endNode, goal);
    //            }
    //
    //            endNodeRecord.Cost = endNodeCost;
    //            endNodeRecord.Connection = currentNode;
    //            endNodeRecord.EstimatedTotalCost = endNodeCost + endNodeHueristic;
    //
    //            if (!open.Contains(endNode))
    //                open.push(endNodeRecord.EstimatedTotalCost, endNode);
    //        }
    //
    //        // finished looking at connections, add to closed list
    //        closed.Add(currentNode);
    //    }
    //
    //    if (currentNode != goal)
    //        return null;
    //    else
    //    {
    //        backtrace.Add(goal);
    //        while (currentNode != startNode)
    //        {
    //            backtrace.Add(currentNode.GetComponent<nodeScript>().Connection);
    //
    //            currentNode = currentNode.GetComponent<nodeScript>().Connection;
    //        }
    //
    //        backtrace.Reverse();
    //        return backtrace;
    //    }
    //}
    //
    //private float CalcCost(GameObject current, GameObject neighbor)
    //{
    //    return (neighbor.transform.position - current.transform.position).magnitude;
    //}
    #endregion

}
