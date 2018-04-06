using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRoll : MonoBehaviour {

	public float speed;
	Transform tf;

	// Use this for initialization
	void Start () {
		tf = this.gameObject.transform;
		if (speed <= 0.0) {
			speed = 1.0f;
		}
	}

	void BarrelRollUpdate () {
		if (tf != null) {
			tf.transform.Rotate(Vector3.forward, Time.deltaTime * speed);
		}
	}
	// Update is called once per frame
	void Update () {
		BarrelRollUpdate ();
	}
}
