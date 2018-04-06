using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastShoot : MonoBehaviour {

	// Use this for initialization
	public float hitForce = 1000f;

	public Camera myCam;

	public GameObject blast;

	//public GameObject explosion;

	void Update () 
	{
		//            GetComponent<AudioSource>().Play();
		RaycastHit hit;
		Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

		Debug.DrawRay (ray.origin, ray.direction * hitForce, Color.red);

		if (Physics.Raycast (ray, out hit, hitForce))
		{
		}
		if(Input.GetButtonDown("Fire1"))
		{
			Instantiate(blast, transform.position, Quaternion.LookRotation(ray.direction));

			if (hit.rigidbody != null)
			{
				hit.rigidbody.AddForceAtPosition (ray.direction * hitForce, hit.point);
				Debug.Log("Hit");

				//Instantiate(explosion, hit.point, Quaternion.identity);
				Destroy(hit.transform.gameObject);
			}

		}
	}
}
