using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class TriggerZombieGirl : MonoBehaviour {

   // public AudioClip bitingClip;
    public AudioClip runningClip;
    private AudioSource src;
    private AudioSource triggerSrc;
    public GameObject hud;
    public Animator zombieGirlAnim;
    bool bitingIsOn = false;
    bool runningIsOn = false;

	// Use this for initialization
	void Start () {
		if (hud == null) {
			hud = UIMgr.instance.panels [(int)UIMgr.UINames.HUD];
		}
        triggerSrc = GetComponent<AudioSource>();
        src = zombieGirlAnim.GetComponent<AudioSource>();
        zombieGirlAnim.GetComponent<CapsuleCollider>().enabled = false;
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update () {
        TriggerZombieGirlUpdate();
		if (hud != null) {
			if (hud.activeSelf && src != null && !bitingIsOn) {
				bitingIsOn = true;
				src.Play ();
				//Debug.Log("should be playing");
			}
		}
    }

    void TriggerZombieGirlUpdate()
    {
        // zombie still alive
        // Grounded animation started playing
        // which means Zombie Biting Then Standing animation finished playing
        if (zombieGirlAnim != null)
        {
            if (zombieGirlAnim.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
            {
                // activate AI Character Control script on zombieGirlAnim
                // so she runs at the player
                zombieGirlAnim.GetComponent<AICharacterControl>().enabled = true;
                if(!runningIsOn)
                {
                    triggerSrc.PlayOneShot(runningClip);
                    runningIsOn = true;
                    zombieGirlAnim.GetComponent<CapsuleCollider>().enabled = true;
                }                
            }
            else
            {
                zombieGirlAnim.GetComponent<AICharacterControl>().enabled = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // fps touched the trigger
        if(other.gameObject == GameObject.Find("FPSControllerWShooting"))
        {
            // set trigger to play Zombie Biting Then Standing anim
            zombieGirlAnim.SetTrigger("LookUp");
            src.Stop();  
        }       
    }
}
