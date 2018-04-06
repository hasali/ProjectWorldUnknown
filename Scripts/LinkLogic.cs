using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LinkLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	public Text createAcct;
	//public Text underline;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
 
	public void OnPointerEnter(PointerEventData eventData) {
		createAcct.color = new Color(130.0f/255, 162.0f/255, 255.0f/255);
		//underline.color = new Color(130.0f/255, 162.0f/255, 255.0f/255);
	}
 
	public void OnPointerExit(PointerEventData eventData) {
		createAcct.color = new Color(51.0f/255, 102.0f/255, 255.0f/255);
		//underline.color = new Color(51.0f/255, 102.0f/255, 255.0f/255);
	}

	public void OnPointerClick(PointerEventData eventData) {
		createAcct.color = new Color(51.0f/255, 102.0f/255, 255.0f/255);
		//underline.color = new Color(51.0f/255, 102.0f/255, 255.0f/255);
	}
}
