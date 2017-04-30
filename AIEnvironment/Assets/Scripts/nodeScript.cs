using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class nodeScript : MonoBehaviour
{
    private Material mat;

    // depricated A*
    /*Gizmo gizmo;
    public List<GameObject> neighbors;
    public bool visited = false;
    GameObject previousNode;
    float lowestTotalCost = Mathf.Infinity;
    bool dropped = false;

    // serves as our NodeRecord
    private float costSoFar = 0;
    private float cost = 0;
    private GameObject connection = null;
    private float estimatedTotalCost = 0;

    public float Cost { get { return cost; } set { cost = value; } }
    public GameObject Connection { get { return connection; } set { connection = value; } }
    public float EstimatedTotalCost { get { return estimatedTotalCost; } set { estimatedTotalCost = value; } }
    public float CostSoFar { get { return costSoFar; } set { costSoFar = value; } }

    GameObject[] graph; */
    
    //public bool hasNeighbors = false;

    // any visible nodes within this radius will be counting 
    //private float detectRadius;

    // Use this for initialization
    void Start()
    {
        //gizmo = this.GetComponent<Gizmo>();
        //neighbors = new List<GameObject>();
        //
        //// get detectRadius from this nodes gizmo script
        //detectRadius = gizmo.gizmoSize;
        //
        //// calculate all node neighbors
        //graph = GameObject.FindGameObjectsWithTag("Node");
        //
        //for (int i = 0; i < graph.Length; i++)
        //{
        //    if(((graph[i].transform.position - this.transform.position).magnitude <= detectRadius) && graph[i] != this.gameObject)
        //    {
        //        neighbors.Add(graph[i]);
        //    }
        //}

        // get the material to be able to change it
        //mat = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!dropped)
        //{
        //    // first, make sure each node is doubly linked
        //    for (int i = 0; i < graph.Length; i++)
        //    {
        //        if (graph[i].GetComponent<nodeScript>().neighbors.Contains(this.gameObject) && neighbors.Contains(graph[i]) == false)
        //            neighbors.Add(graph[i]);
        //    }
        //
        //    // drop the node onto the terrain
        //    RaycastHit hit;
        //
        //    if (Physics.Raycast(transform.position, -transform.up, out hit))
        //        transform.position = new Vector3(transform.position.x, transform.position.y - hit.distance, transform.position.z);
        //    else
        //        Debug.Log("Terrain not detected below node " + this.name);
        //
        //    dropped = true;
        //}
        //
        //// draw lines between each neighbor for debugging purpopses
        //for (int i = 0; i < neighbors.Count; i++)
        //{
        //    Debug.DrawLine(transform.position, neighbors[i].transform.position);
        //}
    }

    /// <summary>
    /// Will drop the current node onto the terrain
    /// </summary>
    public void Drop()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, -transform.up, out hit))
            transform.position = new Vector3(transform.position.x, transform.position.y - hit.distance, transform.position.z);
        else
            Debug.Log("Terrain not detected below node " + this.name);
    }

}

