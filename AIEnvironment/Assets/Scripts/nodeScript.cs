using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeScript : MonoBehaviour {

	[SerializeField]
	List<GameObject> neighbors;

	[SerializeField]
	int weight;

	bool visited;
	GameObject previousNode;
	float lowestTotalCost = Mathf.Infinity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
