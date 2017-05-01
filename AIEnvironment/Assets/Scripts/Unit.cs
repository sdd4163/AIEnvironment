using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {


	public char teamColor;
	public int strength;

	public Vector2 pos2D;

	// Use this for initialization
	void Start () {
		pos2D = new Vector2 (transform.position.x, transform.position.z);
	}
		
	// Update is called once per frame
	void Update () {
		
	}
}
