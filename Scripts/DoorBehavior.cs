using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class DoorBehavior : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("something is entering me");
		FirstPersonController fpsc = other.gameObject.GetComponent<FirstPersonController> ();
		if (fpsc != null) {
			anim.SetTrigger ("Open");
		} 
		anim.SetTrigger ("Open");
	}
	void PauseAnim()
	{
		anim.enabled = false;
	}

	void OnTriggerExit(Collider other)
	{
		anim.enabled = true;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
