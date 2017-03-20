using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class nodeScript : MonoBehaviour
{
    Gizmo gizmo;
    public List<GameObject> neighbors;
    public bool visited = false;
    GameObject previousNode;
    float lowestTotalCost = Mathf.Infinity;
    bool dropped = false;

    GameObject[] graph;
    
    //public bool hasNeighbors = false;

    // any visible nodes within this radius will be counting 
    private float detectRadius;

    // Use this for initialization
    void Start()
    {
        gizmo = this.GetComponent<Gizmo>();
        neighbors = new List<GameObject>();

        // get detectRadius from this nodes gizmo script
        detectRadius = gizmo.gizmoSize;

        // calculate all node neighbors
        graph = GameObject.FindGameObjectsWithTag("Node");

        for (int i = 0; i < graph.Length; i++)
        {
            if(((graph[i].transform.position - this.transform.position).magnitude <= detectRadius) && graph[i] != this.gameObject)
            {
                neighbors.Add(graph[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!dropped)
        {
            // first, make sure each node is doubly linked
            for (int i = 0; i < graph.Length; i++)
            {
                if (graph[i].GetComponent<nodeScript>().neighbors.Contains(this.gameObject) && neighbors.Contains(graph[i]) == false)
                    neighbors.Add(graph[i]);
            }

            // drop the node onto the terrain
            RaycastHit hit;

            if (Physics.Raycast(transform.position, -transform.up, out hit))
                transform.position = new Vector3(transform.position.x, transform.position.y - hit.distance, transform.position.z);
            else
                Debug.Log("Terrain not detected below node " + this.name);

            dropped = true;
        }

        // draw lines between each neighbor for debugging purpopses
        for (int i = 0; i < neighbors.Count; i++)
        {
            Debug.DrawLine(transform.position, neighbors[i].transform.position);
        }
    }
}

