using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void StartMenuCameraUpdate () {
		if (Camera.allCamerasCount == 1) {
			Camera main = this.gameObject.GetComponent<Camera> ();
			if (main != null) {
				main.enabled = true;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		StartMenuCameraUpdate ();
	}
}
