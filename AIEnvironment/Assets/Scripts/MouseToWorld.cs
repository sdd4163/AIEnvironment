using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToWorld : MonoBehaviour {

	//preview unit to place
	GameObject unit;

	//change unit to place
	[SerializeField] List<GameObject> unitPrefabs;
	int index;

	// Use this for initialization
	void Start () {
		index = 0;

		unit = GameObject.Instantiate (unitPrefabs [index], transform);
		unit.transform.position = transform.position;
		unit.transform.GetChild(0).GetComponent<CapsuleCollider> ().enabled = false;
	}


	void swapUnit(){
		GameObject.Destroy (unit);
		unit = GameObject.Instantiate (unitPrefabs [index],transform);
		unit.transform.position = transform.position;
		unit.transform.GetChild(0).GetComponent<CapsuleCollider> ().enabled = false;
	}

	void OnTriggerStay(Collider other){
		Debug.Log (other.name);

		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			if (other.tag == "UnitBase")
				GameObject.Destroy (other.transform.parent.gameObject);
		}	
	}

	// Update is called once per frame
	void Update () {

		Cursor.visible = true;

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			index++;
			index = index % unitPrefabs.Count;
			//Debug.Log ("index: " + index);
			swapUnit ();
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			index--;
			if (index < 0)
				index = unitPrefabs.Count - 1;
			//Debug.Log ("index: " + index);
			swapUnit ();
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow)) {
			index += 4;
			index = index % unitPrefabs.Count;
			//Debug.Log ("index: " + index);
			swapUnit ();
		}

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			//Debug.Log ("placing unit");

			GameObject temp = GameObject.Instantiate (unitPrefabs [index], GameObject.Find ("Units").transform);
			temp.transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
			temp.transform.GetChild(0).GetComponent<CapsuleCollider> ().enabled = true;

		}
			
		//raycast from mouse to terrain
		RaycastHit hit;

		//for some reason Input.mousePosition is occasionally null?
		Ray ray;
		try {
			ray = Camera.current.ScreenPointToRay (Input.mousePosition);
		}
		catch {
			ray = new Ray ();
		}
		if (Physics.Raycast (ray, out hit, 1000)) {
			//print ("hit");
			transform.position = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
			unit.transform.position = transform.position;
		}
	}
}
