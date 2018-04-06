using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMgr : MonoBehaviour {

	public static GAMEMgr instance;
	public int score;
	public eGameMode gameMode;
	public bool isEnding;
	public bool isPlayerDead;

	public enum eGameMode {
		INVALID = -1,
		STORY,
		SURVIVAL,
	};

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}
		score = 0;
		gameMode = eGameMode.INVALID;
		isEnding = false;
		isPlayerDead = false;
	}

	public void resetGame(){
		isPlayerDead = false;
		score = 0;
	}

	public void setGameMode(int gm){
		gameMode = (eGameMode)gm;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
