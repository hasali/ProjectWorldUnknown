using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : MonoBehaviour {
	Vector3 velocity;
	Transform tf;
	public float speed;
	public float accuracy;
	public GameObject target;
	// Use this for initialization
	void Start () {
		tf = this.gameObject.transform;
		if (speed <= 0.0) {
			speed = 1.0f;
		}
		velocity = Vector3.zero;
		if (accuracy <= 0.0) {
			accuracy = 1.0f;
		}
	}

	void PursueUpdate() {
		if (tf != null && target != null) {

			//move towards target
			//accuracy of 0 will be a forward movement relative to this.gameobject
			//accuracy of 1 will be a direct movement toward target
			Vector3 heading = target.transform.position - tf.position;
			Vector3 direction = Vector3.Lerp(tf.forward, heading / heading.magnitude, accuracy);
			velocity = direction * speed;
			tf.Translate (velocity * Time.deltaTime, Space.World);
		}
	}

	// Update is called once per frame
	void Update () {
		PursueUpdate ();
	}
}
