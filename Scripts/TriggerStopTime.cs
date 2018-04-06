using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class TriggerStopTime : MonoBehaviour {
	public float time;
	public bool ready = false;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider other) {

		FirstPersonController fpsc = other.gameObject.GetComponent<FirstPersonController> ();
		if (fpsc != null) {
			ready = true;
		}        
	}
	// Update is called once per frame
	void Update () {
		
	}
}
