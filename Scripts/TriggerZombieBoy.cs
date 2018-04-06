using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class TriggerZombieBoy : MonoBehaviour {

   // public AudioClip bangingClip;
    public AudioClip runningClip;
    private AudioSource src;
    private AudioSource triggerSrc;
    public GameObject hud;
    public Animator zombieBoyAnim;
    bool bangingIsOn = false;
    bool runningIsOn = false;

    // Use this for initialization
    void Start()
    {
		if (hud == null) {
			hud = UIMgr.instance.panels [(int)UIMgr.UINames.HUD];
		}
        triggerSrc = GetComponent<AudioSource>();
        src = zombieBoyAnim.GetComponent<AudioSource>();
        zombieBoyAnim.GetComponent<CapsuleCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        TriggerZombieBoyUpdate();
		if (hud != null) {
			if (hud.activeSelf && src != null && !bangingIsOn) {
				bangingIsOn = true;
				src.Play ();
				Debug.Log ("should be playing");
			}
		}
    }

    void TriggerZombieBoyUpdate()
    {
        // zombie still alive
        // Grounded animation started playing
        // which means Zombie Biting Then Standing animation finished playing
        if(zombieBoyAnim != null)
        {
            if (zombieBoyAnim.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
            {
                // activate AI Character Control script on zombieGirlAnim
                // so she runs at the player
                zombieBoyAnim.GetComponent<AICharacterControl>().enabled = true;
                //zombieBoyAnim.GetComponent<NavMeshAgent>().enabled = true;
                if (!runningIsOn)
                {
                    triggerSrc.PlayOneShot(runningClip);
                    runningIsOn = true;
                    zombieBoyAnim.GetComponent<CapsuleCollider>().enabled = true;
                }
            }
            else
            {
                zombieBoyAnim.GetComponent<AICharacterControl>().enabled = false;
                //zombieBoyAnim.GetComponent<NavMeshAgent>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // fps touched the trigger
        if (other.gameObject == GameObject.Find("FPSControllerWShooting"))
        {
            // set trigger to play Zombie Biting Then Standing anim
            zombieBoyAnim.SetTrigger("TurnLeft");
            src.Stop();
        }
    }
}
