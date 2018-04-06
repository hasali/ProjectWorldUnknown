using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
	[RequireComponent(typeof (ThirdPersonCharacter))]
	public class Freeze : MonoBehaviour {

		public float rayDist;

		//float freezeTime = 3;
		//Rigidbody rb;
	//	public void OnCollisionEnter(Collision other)
	//	{
	//		if (other.gameObject.name == "Projectile")
	//		{
	//			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
	//			//rb.constraints=RigidbodyConstraints.FreezeAll;
	////			transform.Translate (new Vector3 (0, 0, 0));
	////			Destroy (this.gameObject);
	//			Debug.Log ("hit");
	//		}
	//	}
		public void stunEnemy()
		{
			RaycastHit hit;

			Ray ray = new Ray (transform.position, transform.forward);
			Debug.DrawRay (transform.position, transform.forward * rayDist, Color.red);

			if (Physics.Raycast (ray, out hit, rayDist))
			{
				GameObject objhit = hit.transform.gameObject;

				if (objhit != null)
				{
					EnemyMTP nme = objhit.GetComponentInChildren<EnemyMTP> ();
					if (nme != null) {
						nme.isStun = true;
					}
				}

					
			}
			
				
				
		}
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			stunEnemy ();
		}
	}
}
