using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPlayer : MonoBehaviour {

	public static isPlayer instance;
	public bool isWalking;

	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		isWalking = false;
	}

	void isPlayerUpdate(){
	}

	// Update is called once per frame
	void Update () {
		isPlayerUpdate ();
	}
}
