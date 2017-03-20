using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {

	[SerializeField]
	public bool moving = false;

	[SerializeField]
	bool arrived = false;

	[SerializeField]
	float speed;

	
	public GameObject currentTarget;
	int index = 0;



	[SerializeField]
	List<GameObject> targets;

    public List<GameObject> Targets { set { targets = value; } get { return targets; } }

	CharacterController CC;

	// Use this for initialization
	void Start () {
		CC = gameObject.GetComponent<CharacterController> ();
		moving = false;
	}

	// Update is called once per frame
	void Update () {
	
		if (moving) {

			Vector3 tempDir = currentTarget.transform.position - gameObject.transform.position;
			float dist = tempDir.magnitude;
			tempDir.Normalize ();

			if(dist< 5){
				Debug.Log ("arrived!");
				index++ ;
                if (index >= targets.Count)
                {
                    index = targets.Count;
                    moving = false;
                    return;
                }
				currentTarget = targets [index];
			}

			CC.Move(tempDir * speed);

			transform.right = tempDir.normalized;
		}

	}
}
