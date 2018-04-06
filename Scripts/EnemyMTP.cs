using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.ThirdPerson
{
	//[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
	//[RequireComponent(typeof (ThirdPersonCharacter))]
	public class EnemyMTP : MonoBehaviour {
		
		//Control Enemy behavior

		float freezeTime = 10;
		// Use this for initialization
		public bool isStun = false;
		public bool isDestroyable=false;
		public Animator anim;

		void Start () {
		}
		public void move()
		{
			//Animator anim2 = GetComponent<Animator> ();
			ThirdPersonCharacter moveSpeed = GetComponentInChildren<ThirdPersonCharacter> ();

			if (isStun)
			{
				//anim2.SetBool ("isStun", isStun);

				moveSpeed.m_MoveSpeedMultiplier = 0.0f;
				moveSpeed.m_AnimSpeedMultiplier = 0.3f;
				//moveSpeed.m_Rigidbody.velocity = Vector3.zero;	

				freezeTime -= Time.deltaTime;


				isDestroyable = true;
				Debug.Log ("Destroyable");
				if (freezeTime <= 0)
				{

					moveSpeed.m_MoveSpeedMultiplier = 1.0f;
					moveSpeed.m_AnimSpeedMultiplier = 1.0f;
					freezeTime = 10;
					isStun = false;
					//anim2.SetBool ("isStun", isStun);
					isDestroyable = false;
				}
			}






		}
		// Update is called once per frame
		void Update () {
			move ();

		}
	}
}
