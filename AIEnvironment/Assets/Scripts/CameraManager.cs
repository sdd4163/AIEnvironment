using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public Camera[] cameras;
    private int currentCameraIndex;

	[SerializeField]
	float camMoveSpeed=1;

	// Use this for initialization
	void Start () {
        currentCameraIndex = 0;

        //Turn all cameras off, except the first default one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        //If any cameras were added to the controller, enable the first one
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
            //write to the console which camera is enabled
            Debug.Log("Camera with name: " + cameras[0].GetComponent<Camera>().name + ", is now enabled");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C)) //can be any key you want
        {
            currentCameraIndex++;
            Debug.Log("C button has been pressed. Switching to the next camera");
            if (currentCameraIndex < cameras.Length)
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                cameras[currentCameraIndex].gameObject.SetActive(true);
                Debug.Log("Camera with name: " + cameras[currentCameraIndex].GetComponent<Camera>().name + ", is now enabled");
            }
            else
            {
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                currentCameraIndex = 0;
                cameras[currentCameraIndex].gameObject.SetActive(true);
                Debug.Log("Camera with name: " + cameras[currentCameraIndex].GetComponent<Camera>().name + ", is now enabled");
            }
        }

		//if(cameras[currentCameraIndex].name == "TopDownCamera"){
		if(true){
			if (Input.GetKey (KeyCode.W)) {
				//Debug.Log ("move topdown up");
				cameras [currentCameraIndex].transform.position -= new Vector3 (camMoveSpeed,0,0);
			}
			if (Input.GetKey (KeyCode.S)) {
				//Debug.Log ("move topdown down");
				cameras [currentCameraIndex].transform.position +=new Vector3 (camMoveSpeed,0,0);
			}
			if (Input.GetKey (KeyCode.A)) {
				//Debug.Log ("move topdown left");
				cameras [currentCameraIndex].transform.position -= new Vector3 (0,0,camMoveSpeed);
			}
			if (Input.GetKey (KeyCode.D)) {
				//Debug.Log ("move topdown right");
				cameras [currentCameraIndex].transform.position += new Vector3 (0,0,camMoveSpeed);
			}
			if (Input.GetKey (KeyCode.E)) {
				//Debug.Log ("move topdown out");
				cameras [currentCameraIndex].transform.position += new Vector3 (0,camMoveSpeed,0);
			}
			if (Input.GetKey (KeyCode.Q)) {
				//Debug.Log ("move topdown in");
				cameras [currentCameraIndex].transform.position -= new Vector3 (0,camMoveSpeed,0);
			}
		
		}

    }
}
