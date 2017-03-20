using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerScript : MonoBehaviour {

	[SerializeField]
	List<GameObject> nodes;

	[SerializeField]
	GameObject agent;

	[SerializeField]
	PriorityQueue q;

	List<Flocker> flockers;
	public List<Flocker> Flockers {
		get {
			return flockers;
		}
	}

	Vector3 flockCenter;
	public Vector3 FlockCenter {
		get {
			return flockCenter;
		}
	}

	// Use this for initialization
	void Start () {
		q = new PriorityQueue ();
		q.Setup ();

		GameObject o = GameObject.Instantiate(agent, new Vector3(0, 0, 0), Quaternion.identity);
		o.name = "1";

		q.push (44.0f , o);

		GameObject o2 = GameObject.Instantiate(agent, new Vector3(0, 0, 0), Quaternion.identity);
		o2.name = "2";

		q.push (20,o2);

		GameObject o3 =GameObject.Instantiate(agent, new Vector3(0, 0, 0), Quaternion.identity);
		o3.name = "3";

		q.push (70, o3);

		GameObject o4 =GameObject.Instantiate(agent, new Vector3(0, 0, 0), Quaternion.identity);
		o4.name = "4";

		q.push (5, o4);


		GameObject o5 = GameObject.Instantiate(agent, new Vector3(0, 0, 0), Quaternion.identity);
		o5.name = "5";

		q.push (100, o5);


		q.pop ();
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.Escape)) {
			quitGame ();
		}
		if(Input.GetKeyDown(KeyCode.P))
		{
			pauseGame ();
		}
	}

	void GetFlockCenter() {
		Vector3 center = Vector3.zero;
		foreach (Flocker f in flockers) {
			center += f.transform.position;
		}

		center = center / flockers.Count;
		flockCenter = center;
	}


	public void quitGame()
	{
		//If we are running in a standalone build of the game
		#if UNITY_STANDALONE
		//Quit the application
		Application.Quit();
		#endif

		//If we are running in the editor
		#if UNITY_EDITOR
		//Stop playing the scene
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}

	public void pauseGame()
	{
		//If we are running in a standalone build of the game
		#if UNITY_STANDALONE
		//Quit the application
		//
		#endif

		//If we are running in the editor
		#if UNITY_EDITOR
		//Stop playing the scene
		Debug.Break();
		#endif
	}

}
