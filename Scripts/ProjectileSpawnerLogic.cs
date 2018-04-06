using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerLogic : MonoBehaviour {

	public GameObject obj;
	public GameObject obj2;
	public float fireDelay;
	public float nextFire;
	public float myTime;
	public GameObject red;
	public GameObject blue;

    public AudioClip stunnerAudio;
    public AudioClip spearAudio;
    private AudioSource audioSrc;
	//bool stun = false;
	//public P1TankLogic p1; 
	//public P2TankLogic p2;
	// Use this for initialization
	void Start () {
		Init ();
        audioSrc = GetComponent<AudioSource>();
	}
	void Awake()
	{
		obj = Resources.Load("Projectile") as GameObject;
		obj2 = Resources.Load("ProjectileDestroy") as GameObject;
			
	}
	void Init(){
		fireDelay = 1.0f;
		nextFire = 1.0f;
		myTime = 1.0f;
	}
		

	void spawnerUpdate()
	{
		myTime += Time.deltaTime;
			// check for a key press, when it is down, spawn a obj copy
		if (Input.GetKeyUp(KeyCode.LeftShift) && myTime > nextFire == true) {
			//track time since last fire
				nextFire = myTime + fireDelay;
			// get the position from the Tform component on the gameobject we're are attached to
			Transform TF = this.gameObject.GetComponent<Transform> ();
			if (TF != null && obj != null) {
                audioSrc.PlayOneShot(stunnerAudio);
                Vector3 vPos = TF.position;
				Instantiate (obj, vPos, TF.rotation);                
            }

			nextFire = nextFire - myTime;
			myTime = 0.0f;
		}
		if (Input.GetKeyUp(KeyCode.Z) && myTime > nextFire == true) {
			//track time since last fire
			nextFire = myTime + fireDelay;
			// get the position from the Tform component on the gameobject we're are attached to
			Transform TF = this.gameObject.GetComponent<Transform> ();
			if (TF != null && obj2 != null) {
                audioSrc.PlayOneShot(spearAudio);
                Vector3 vPos = TF.position;
				Instantiate (obj2, vPos, TF.rotation);            
            }

			nextFire = nextFire - myTime;
			myTime = 0.0f;
		}
	}

	// Update is called once per frame
	void Update () {
		spawnerUpdate ();
	}
}
