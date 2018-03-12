using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBackButton : MonoBehaviour {
	
	private GameObject activeScreen = null;

	public void backToPrevPage(){
		activeScreen.GetComponent<OnPopupPageOpen>().OnExit ();

		try {
			activeScreen.GetComponent<OnPopupPageOpen> ().OnEnter ();
			return;
		} catch {}

		gameObject.SetActive (false);
	}

	public void SetActiveScreen(GameObject _screen){
		activeScreen = _screen;
		gameObject.SetActive (true);
	}
}
