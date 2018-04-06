using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPanelLogic : MonoBehaviour {
	const float fadeLength = 1.5f;
	float fadeTime = fadeLength;
	// Use this for initialization

	void Start () {
	}

	public void resetEndPanelLogic() {
		fadeTime = fadeLength;
		Text[] txtObj = GetComponentsInChildren<Text> (true);
		Button[] btnObj = GetComponentsInChildren<Button> (true);
//		Image imgObj = GetComponent<Image> ();
//		Color transparent = imgObj.color;
//		transparent.a = 0.0f;
//		imgObj.color = transparent;
		foreach (Text txt in txtObj)
		{
			txt.gameObject.SetActive(false);
		}
		foreach (Button btn in btnObj)
		{
			btn.gameObject.SetActive(false);
		}
	}

	public void fade()
	{
		Image imgObj = GetComponent<Image> ();

		imgObj.CrossFadeAlpha (0.0f, 0.0f, false);
		imgObj.CrossFadeAlpha (1.0f, fadeTime, false);
		Debug.Log ("Game Ending");
		GAMEMgr.instance.isEnding = true;
	}
	void showText()
	{
		fadeTime -= Time.deltaTime;

		if (fadeTime <= 0)
		{
			Text[] txtObj = GetComponentsInChildren<Text> (true);
			Button[] btnObj = GetComponentsInChildren<Button> (true);
			foreach (Text txt in txtObj)
			{
				txt.gameObject.SetActive(true);
				if (txt.gameObject.name == "EnemiesDestroyedVal") {
					txt.text = GAMEMgr.instance.score.ToString();
				}
			}
			btnObj [0].gameObject.SetActive (true);
			if (GAMEMgr.instance.gameMode == GAMEMgr.eGameMode.SURVIVAL 
				&& !GAMEMgr.instance.isPlayerDead) {
				Debug.Log ("Survival Game Mode Ending");
				btnObj[1].gameObject.SetActive (true);
			}
		}
	}
	// Update is called once per frame
	void Update () {
		showText ();
	}
}