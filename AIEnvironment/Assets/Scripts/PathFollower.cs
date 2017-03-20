using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {

	[SerializeField]
	bool moving = true;

	[SerializeField]
	bool arrived = false;

	[SerializeField]
	float speed;

	[SerializeField]
	GameObject currentTarget;
	int index = 0;

	[SerializeField]
	List<GameObject> targets;

	Rigidbody RB;

	// Use this for initialization
	void Start () {
		currentTarget = targets [index];
		RB = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (moving) {

			Vector3 tempDir = currentTarget.transform.position - gameObject.transform.position;
			float dist = tempDir.magnitude;
			tempDir.Normalize ();

			if(dist< 10){
				Debug.Log ("arrived!");
				index++ ; index = index % targets.Count;
				currentTarget = targets [index];
			}

			RB.AddForce(tempDir * speed);

			transform.right = tempDir.normalized;
		}

	}
}
