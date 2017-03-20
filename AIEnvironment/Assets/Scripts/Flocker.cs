using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocker : MonoBehaviour {

	//TODO: CalcSteeringForce, LeaderFollow/Tunnel, Constraint controls

	gameManagerScript gManager;
	CharacterController characterController;

	float neighborhoodSize, maxSpeed;
	bool[] inNeighborhood;

	// Use this for initialization
	void Start () {
		gManager = GameObject.Find ("GM").GetComponent<gameManagerScript> ();
		characterController = gameObject.GetComponent<CharacterController> ();

		inNeighborhood = new bool[gManager.Flockers.Count];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BuildNeighborhood() {
		for (int i = 0; i < gManager.Flockers.Count; i++) {
			Flocker tempF = gManager.Flockers [i];
			inNeighborhood [i] = false;
			if (tempF == this) {
				//Ignore ourselves
			} else if (Vector3.Distance (transform.position, tempF.transform.position) < neighborhoodSize) {
				inNeighborhood [i] = true;
			}
		}
	}

	Vector3 GetFlockCenter() {
		return gManager.FlockCenter;
	}

	Vector3 GetNeighborhoodCenter() {
		Vector3 center = Vector3.zero;
		int count = 0;
		for (int i = 0; i < gManager.Flockers.Count; i++) {
			if (inNeighborhood [i]) {
				center += gManager.Flockers [i].transform.position;
				count++;
			}
		}
		center = center / count;
		return center;
	}

	Vector3 GetNeighborhoodVelocity() {
		Vector3 avgVel = Vector3.zero;
		int count = 0;
		for (int i = 0; i < gManager.Flockers.Count; i++) {
			if (inNeighborhood [i]) {
				avgVel += gManager.Flockers [i].transform.position;
				count++;
			}
		}
		avgVel = avgVel / count;
		return avgVel;
	}

	Vector3 GetNeighborhoodAlignment() {
		for (int i = 0; i < gManager.Flockers.Count; i++) {
			if (inNeighborhood [i]) {
				
			}

		}
		return transform.forward;
	}

	Vector3 Separation() {
		return Flee (GetNeighborhoodCenter ());
	}

	Vector3 Cohesion() {
		return Seek (GetFlockCenter ());
	}

	Vector3 Seek(Vector3 targetPos)
	{
		Vector3 dv = targetPos - transform.position;
		dv.Normalize();
		dv *= maxSpeed;
		dv.y = 0;
		return dv;
	}

	Vector3 Flee(Vector3 targetPos)
	{
		Vector3 dv = transform.position - targetPos;
		dv.Normalize();
		dv *= maxSpeed;
		dv.y = 0;
		return dv;
	}
}
