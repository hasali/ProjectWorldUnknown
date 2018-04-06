using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour 
{
    public static UIMgr instance;

	public List<GameObject> panels;

    public AudioClip gameMenuClip;

    public AudioClip gameplayClip;

    //public enum UINames {START, PLAYERMODE, HUD, PAUSE, CREATEACCT, LOGIN};
	public enum UINames { START, PLAYERMODE, LOADING, HUD, PAUSE, END};

    public UINames gameState;

	GameObject loader;

	LoaderMgr lMgrScript;

	EndPanelLogic myEpl;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}
		Time.timeScale = 0.0f;
		loader = GameObject.Find("Loader");
		if(loader != null) {
			lMgrScript = loader.GetComponent<LoaderMgr>();

			if(lMgrScript.restartPressed) {
				enableHudUI();
				lMgrScript.restartPressed = false;
			}
			else {
				enableStartUI();
			}
		}
		foreach (GameObject obj in panels) {
			EndPanelLogic epl = obj.GetComponent<EndPanelLogic> ();
			if (epl != null) {
				myEpl = epl;
			}
		}
	}

	public void disableAll() {
		foreach(GameObject obj in panels) {
			myEpl.resetEndPanelLogic ();
			obj.SetActive(false);
		}
	}

	public void enableStartUI() {
		enableUI(UINames.START);
	}

	public void enableLoadingUI() {
		enableUI(UINames.LOADING);
	}

	public void enableEndUI()
	{
		enableUI (UINames.END);
		myEpl.fade ();
	}
	public void enablePlayerModeUI() {
		enableUI(UINames.PLAYERMODE);
	}

	public void enableHudUI() {
		enableUI(UINames.HUD);
		Time.timeScale = 1.0f;
	}

	public void enablePauseUI() {
		enableUI(UINames.PAUSE);
		Time.timeScale = 0.0f;
	}

	//public void enableCreateAcctUI() {
	//	enableUI(UINames.CREATEACCT);
	//}

	//public void enableLoginUI() {
	//	enableUI(UINames.LOGIN);
	//}

	public void enableUI(UINames name) {
		disableAll();
		panels[(int)name].SetActive(true);
		gameState = name;
	}


	public void UIMgrUpdate() {
		if(Input.GetKeyDown(KeyCode.P)||Input.GetKeyDown(KeyCode.JoystickButton9)) {
			if(gameState == UINames.HUD) {
				enablePauseUI();
			}
			else if(gameState == UINames.PAUSE) {
				enableHudUI();
			}
		}

		Cursor.visible = gameState == UINames.HUD ? false : true;
	}

    public void SoundUpdate()
    {
        switch (gameState)
        {
            case UINames.START:
            case UINames.PLAYERMODE:
                //this.gameObject.GetComponent<AudioSource>().Stop();
                this.gameObject.GetComponent<AudioSource>().clip = gameMenuClip;              
               break;
            case UINames.HUD:
            case UINames.PAUSE:
                //this.gameObject.GetComponent<AudioSource>().Stop();
                this.gameObject.GetComponent<AudioSource>().clip = gameplayClip;
                break;         
        }

        if (this.gameObject.GetComponent<AudioSource>().isPlaying == false)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
        }
        


    }

	public void restartGame() {
		lMgrScript.restartPressed = true;
		SceneManager.LoadScene("DemoSceneMain");
	}


	// Update is called once per frame
	void Update () {
		UIMgrUpdate();
        SoundUpdate();
	}
}
