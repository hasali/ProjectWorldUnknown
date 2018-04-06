using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSide : MonoBehaviour {
	
	float x;
	public float length;
	public float speed;
	Transform tf;

	// Use this for initialization
	void Start () {
		tf = this.gameObject.transform;
		if (tf != null) {
			x = tf.position.x;
		}
		length = 1.0f;
		speed = 1.0f;
	}

	void SideToSideUpdate() {
		if (tf != null) {
			tf.position = (new Vector3(x + (Mathf.Sin (Time.time * speed) * length), tf.position.y, tf.position.z));
		}
	}
	
	// Update is called once per frame
	void Update () {
		SideToSideUpdate ();
	}
}
