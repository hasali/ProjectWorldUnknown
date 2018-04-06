using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBox_Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void XBox_ControllerUpdate (){
		if (Input.GetButton ("Fire1")) {
			//Debug.Log ("'A' button pressed");
		}
	}

	// Update is called once per frame
	void Update () {
		XBox_ControllerUpdate ();
	}
}
