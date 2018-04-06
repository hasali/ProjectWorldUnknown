using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TriggerJill : MonoBehaviour {
	public GameObject jill;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other) {
		
		FirstPersonController fpsc = other.gameObject.GetComponent<FirstPersonController> ();
		if (fpsc != null && jill != null && !jill.activeSelf) {
			jill.SetActive(true);
            this.gameObject.SetActive(false);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
