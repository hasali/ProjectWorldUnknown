using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public int dmg;
    public AudioClip atkClip;
    private AudioSource atkSrc;

	// Use this for initialization
	void Start () {
        atkSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnAttack()
    {
        if(PlayerHealth.currentHealth > 0)
        {
            atkSrc.PlayOneShot(atkClip);
            CameraShake.instance.Shake();
            PlayerHealth.TakeDamage(dmg);
            Debug.Log("i've been hit");
        }
    }
}
