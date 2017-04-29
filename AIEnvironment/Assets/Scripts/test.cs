using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	public Plane plane;

	// Use this for initialization
	void Start () {
		plane = new Plane(Vector3.up,0);
	}
	void TestMouse(){

//		float dist;
//		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//		if (plane.Raycast (ray, out dist)) {
//
//			Vector3 point = ray.GetPoint (dist);
//			//transform.position = point;
//
//			//transform.position = new Vector3(transform.position.x, 0.0f , transform.position.z);
//			float y = Terrain.activeTerrain.SampleHeight (point);
//
//			transform.position = new Vector3 (point.x, point.y , point.z);
//
//			//print ("hit");
//		}

		//raycast from mouse to terrain
		RaycastHit hit;
		Ray ray = Camera.current.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 1000))
		{
			//print ("hit");
			transform.position = new Vector3 (hit.point.x, hit.point.y , hit.point.z);

		}

	}


	// Update is called once per frame
	void Update () {
		Cursor.visible = true;
		TestMouse ();

		//fire projectile
		if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log (Input.mousePosition);
		}

	}
}
