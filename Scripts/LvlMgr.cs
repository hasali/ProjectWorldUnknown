using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//
//	LvlMgr does the following
//		-keeps a ref to GLOBAL scene all the time
//		-load and unload addively the current transient/gameplay scene
//
public class LvlMgr : MonoBehaviour {

	public static LvlMgr	Instance;
	public Scene 			GlobalScene;
	public Scene 			CurrentScene;	// current transient gameplay scene

	public void LoadLevel(string levelname)
	{
		// once this is done, the OnSceneLoaded CB will fire
		SceneManager.LoadSceneAsync (levelname, LoadSceneMode.Additive);
	}

	public void UnloadCurrentLevel()
	{
		// once this is done, the OnSceneUnloaded CB will fire
		SceneManager.UnloadSceneAsync (CurrentScene);
	}

	public void ReloadCurrentLevel(){
		UnloadCurrentLevel();
		SceneManager.LoadSceneAsync (CurrentScene.name, LoadSceneMode.Additive);
		GAMEMgr.instance.isEnding = false;
	}

	public void OnSceneLoaded(Scene s, LoadSceneMode mode)
	{
		Debug.Log ("LvlMgr::OnSceneLoaded() - Scene Loaded: " + s.ToString ());
		Debug.Log (mode.ToString ());

		CurrentScene = s;
		SceneManager.SetActiveScene (CurrentScene); // so new objs will spawn in here
		UIMgr.instance.enableHudUI();
	}

	public void OnSceneUnLoaded(Scene s)
	{
		Debug.Log ("Unloaded Scene");
		SceneManager.SetActiveScene (GlobalScene);
	}

	// Use this for initialization
	void Start () {

		if (Instance == null)
			Instance = this;

		// connect some callback functions to call when load and unlaod are finished?
		SceneManager.sceneLoaded += OnSceneLoaded;
		SceneManager.sceneUnloaded += OnSceneUnLoaded;

		// keep this for later
		GlobalScene = SceneManager.GetSceneByName ("Lucas_scenemanager_main");
	}

	public void LvlMgrUpdate()
	{
	}

	// Update is called once per frame
	void Update () {
	
		LvlMgrUpdate ();
	}
}
