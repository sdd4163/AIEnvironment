using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class nodeScript : MonoBehaviour
{
    Gizmo gizmo;
    List<GameObject> neighbors;
    public bool visited = false;
    GameObject previousNode;
    float lowestTotalCost = Mathf.Infinity;

    // any visible nodes within this radius will be counting 
    private float detectRadius;

    // Use this for initialization
    void Start()
    {
        gizmo = this.GetComponent<Gizmo>();

        // get detectRadius from this nodes gizmo script
        detectRadius = gizmo.gizmoSize;

        // calculate all node neighbors
        GameObject[] graph = GameObject.FindGameObjectsWithTag("Node");

        for (int i = 0; i < graph.Length; i++)
        {
            if((graph[i].transform.position - this.transform.position).magnitude <= detectRadius)
            {
                neighbors.Add(graph[i]);
            }
        }

        // drop the node onto the terrain

    }

    // Update is called once per frame
    void Update()
    {

    }
}

