using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class TriggerEnd : MonoBehaviour {
	
    Text enemiesDestroyedVal;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("triggered");

        FirstPersonController fpsc = other.gameObject.GetComponent<FirstPersonController> ();
		UIMgr ePanel = UIMgr.instance;
		if (fpsc != null && ePanel != null)
		{		
			ePanel.enableEndUI();
//			enemiesDestroyedVal = GameObject.Find ("EnemiesDestroyedVal").GetComponentInChildren<Text>(true);
//            enemiesDestroyedVal.text = GAMEMgr.instance.score.ToString();
        }
	}

	// Update is called once per frame
	void Update () {
		
	}
}
