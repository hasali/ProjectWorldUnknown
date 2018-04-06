using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogicController : MonoBehaviour {

	public GameObject view;
	public float viewSpeed = 100;
	public float walkSpeed = 2;
	// Use this for initialization
	void Start () {

	}

	public void PlayerLogicUpdate(){



		view.transform.Rotate(new Vector3(-Input.GetAxis("Controller Y"), 0, 0) * Time.deltaTime * viewSpeed);
		Quaternion rotation = Quaternion.identity;
		float angle = 0;
		if (view.transform.localEulerAngles.x < 280 && view.transform.localEulerAngles.x > 80){
			if (view.transform.localEulerAngles.x > 180){
				angle = 280.1f;
			}
			else {
				angle = 79.9f;
			}
			rotation.eulerAngles = new Vector3(angle, view.transform.rotation.eulerAngles.y, view.transform.rotation.eulerAngles.z);
			view.transform.rotation = rotation;
		}
		Debug.Log(view.transform.localEulerAngles.x);
		transform.Rotate(new Vector3(0,Input.GetAxis("Controller X"), 0) * Time.deltaTime * viewSpeed);
	}

	// Update is called once per frame
	void Update () {
		PlayerLogicUpdate();
	}
}
