using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour {
	public static CameraMgr instance;
	public Camera main;
	public Camera prev;
	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}
		if (main == null) {
			main = Camera.main;
		}
	}

	public void SetMainCamera(Camera cam){
		main = cam;
	}

	void CameraUpdate() {
		if (main != prev) {
			prev.enabled = false;
		}

		prev = main;
	}
	// Update is called once per frame
	void Update () {
		CameraUpdate ();
	}
}
