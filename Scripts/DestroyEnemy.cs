using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.ThirdPerson
{
	//[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
	//[RequireComponent(typeof (EnemyMTP))]
	public class DestroyEnemy : MonoBehaviour 
	{
		public float rayDist;
		public int point;
		public void	destroyEnemy()
		{
			RaycastHit hit;


			Ray ray = new Ray (transform.position, transform.forward);
			Debug.DrawRay (transform.position, transform.forward * rayDist, Color.red);

			if (Physics.Raycast (ray, out hit, rayDist))
			{
				GameObject freezeObj = hit.transform.gameObject;

				Debug.Log ("true");
				if (freezeObj != null)
				{
					EnemyMTP frzNME = freezeObj.GetComponentInChildren<EnemyMTP> ();
					Animator anim = freezeObj.GetComponentInChildren<Animator> ();
					if (frzNME != null && frzNME.isDestroyable == true) {
						//Destroy (freezeObj);
						anim.SetBool ("isHit", frzNME.isDestroyable);
						point++; 

						//Destroy (this.gameObject);
					}
				}

			}



		}
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			destroyEnemy ();
		}
	}
}
