using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class TriggerGirlScout : MonoBehaviour {

    public AudioClip runningClip;
    //private AudioSource src;
    private AudioSource triggerSrc;
    //public GameObject hud;
    //public Animator girlScoutAnim;
    //bool bangingIsOn = false;
    bool runningIsOn = false;
    public Animator girlScoutAnim;

    // Use this for initialization
    void Start()
    {
        girlScoutAnim.GetComponent<CapsuleCollider>().enabled = false;
        triggerSrc = GetComponent<AudioSource>();
        //src = girlScoutAnim.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        TriggerGirlScoutUpdate();
        //if (hud.activeSelf && src != null && !bangingIsOn)
        //{
        //    bangingIsOn = true;
        //    src.Play();
        //    Debug.Log("should be playing");
        //}
    }

    void TriggerGirlScoutUpdate()
    {
        // zombie still alive
        // Grounded animation started playing
        // which means Lying To Standing animation finished playing
        if(girlScoutAnim != null)
        {
            if (girlScoutAnim.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
            {
                // activate AI Character Control script on girlScoutAnim
                // so she runs at the player
                girlScoutAnim.GetComponent<AICharacterControl>().enabled = true;
                if (!runningIsOn)
                {
                    triggerSrc.PlayOneShot(runningClip);
                    runningIsOn = true;
					girlScoutAnim.GetComponent<CapsuleCollider> ().enabled = true;
                }
            }
            else
            {
                girlScoutAnim.GetComponent<AICharacterControl>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // zombie girl touched the trigger
        if (other.gameObject == GameObject.Find("ZombieGirlThirdPersonController"))
        {
            // set trigger to play Lying To Standing anim
            girlScoutAnim.SetTrigger("StandUp");
            //src.Stop();
        }
    }
}
