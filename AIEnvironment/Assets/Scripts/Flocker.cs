using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Flocker : MonoBehaviour {

	//TODO: CalcSteeringForce, LeaderFollow/Tunnel, Constraint controls

	gameManagerScript gManager;
	CharacterController characterController;

	GameObject player;

	float neighborhoodSize, maxSpeed;
	bool[] inNeighborhood;
	bool caught = false;

	float separationWgt;
	public float SeparationWgt {
		get {
			return separationWgt;
		}
		set {
			separationWgt = value;
		}
	}

	float cohesionWgt;
	public float CohesionWgt {
		get {
			return cohesionWgt;
		}
		set {
			cohesionWgt = value;
		}
	}

	float alignWgt;
	float seekWgt;
	public float SeekWgt {
		get {
			return seekWgt;
		}
		set {
			seekWgt = value;
		}
	}

	// Use this for initialization
	void Start () {
		gManager = GameObject.Find ("GM").GetComponent<gameManagerScript> ();
		characterController = gameObject.GetComponent<CharacterController> ();
		player = GameObject.Find ("Player");

		inNeighborhood = new bool[gManager.FlockCount];
	}

	public void Initialize(float sepW, float cohW, float alignW, float seekW) {
		separationWgt = sepW;
		cohesionWgt = cohW;
		alignWgt = alignW;
		seekWgt = seekW;

		neighborhoodSize = 12.5f;
		maxSpeed = 17.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, GetFlockCenter ()) < 65 && !caught) {
			caught = true;
		}
		BuildNeighborhood ();

		Vector3 velocity = Vector3.zero;

		velocity += Separation () * separationWgt;
		velocity += Cohesion () * cohesionWgt;
		//velocity += GetNeighborhoodAlignment () * alignWgt;   Was causing issues with flocking, removed for time
		if (caught) {
			velocity += Follow() * seekWgt;
		}

		velocity.y = 0;
		velocity = Vector3.ClampMagnitude (velocity, maxSpeed);
		velocity.y -= 1000.0f;
		characterController.Move (velocity * Time.deltaTime);
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
		avgVel.y = 0;
		return avgVel;
	}

	Vector3 GetNeighborhoodAlignment() {
		Vector3 avgAlign = Vector3.zero;
		int count = 0;
		for (int i = 0; i < gManager.Flockers.Count; i++) {
			if (inNeighborhood [i]) {
				avgAlign += gManager.Flockers [i].transform.position;
				count++;
			}

		}
		avgAlign.Normalize ();
		return avgAlign / count;
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

	Vector3 Follow()
	{
		Vector3 tv = player.transform.forward * -1;
		tv = Vector3.Normalize (tv) * 25.0f;
		Vector3 behind = player.transform.position + tv;
		return Seek(behind);
	}
}*/
