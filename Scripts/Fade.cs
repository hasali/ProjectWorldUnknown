using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	public bool canFade;
	MeshRenderer[] meshRenderers;
	float timeToFade = 1.0f;

	// Use this for initialization
	void Start () {
		meshRenderers = this.gameObject.GetComponentsInChildren<MeshRenderer>();
	}
	void FadeUpdate(){
		//slowly fade from solid to completely transparent
		if (canFade) {
			foreach (MeshRenderer mesh in meshRenderers) {
				Color alpha = mesh.material.color;
				alpha.a = 0;
				mesh.material.color = Color.Lerp (
					mesh.material.color, alpha, Time.deltaTime * timeToFade);
			}
		}
	}
	// Update is called once per frame
	void Update () {
		FadeUpdate ();
	}
}
