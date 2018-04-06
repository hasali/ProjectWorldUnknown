using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class ProjectileLogic : MonoBehaviour {

	private Vector3 velocity; 
	public float speed;
    EnemyMTP enemyMTP;
	public GameObject flames;
    //private int n = 0;

    void Awake()
	{  
		velocity = transform.forward;
        
		//speed = 30;
	}
	public void OnCollisionEnter(Collision other){
		Animator anim = other.gameObject.GetComponent<Animator> ();
        enemyMTP = other.gameObject.GetComponent<EnemyMTP>();
        Debug.Log(this.gameObject.name);
        if (enemyMTP != null)
        {
            if (enemyMTP.isDestroyable && this.gameObject.name == "ProjectileDestroy(Clone)")
            {
				Transform TF = other.gameObject.GetComponent<Transform> ();

                GAMEMgr.instance.score++;


			
				Instantiate(flames, TF.position + new Vector3(0.5f,1,0), TF.rotation);
                
				anim.SetTrigger("isHit");
				other.gameObject.GetComponent<AICharacterControl> ().enabled = false;

            }
            else if (!enemyMTP.isStun && this.gameObject.name == "Projectile(Clone)")
            {
                enemyMTP.isStun = true;
            }
        }
        SelfDestruct();
	}

	public void SelfDestruct(){
		Destroy (this.gameObject);
	}
	// Use this for initialization
	void Start () {
		Invoke ("SelfDestruct", 5.0f);
    }

	void projectileLogicUpdate(){
		
		this.GetComponent<Rigidbody>().velocity = velocity * speed;
        
    }

	// Update is called once per frame
	void Update () {
		projectileLogicUpdate ();
    }
}
