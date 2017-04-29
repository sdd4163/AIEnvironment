using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToWorld : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Cursor.visible = true;

		//raycast from mouse to terrain
		RaycastHit hit;
		Ray ray = Camera.current.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 1000))
		{
			//print ("hit");
			transform.position = new Vector3 (hit.point.x, hit.point.y , hit.point.z);

		}


	}
}
