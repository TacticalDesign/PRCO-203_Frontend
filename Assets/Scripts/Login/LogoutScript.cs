using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoutScript : MonoBehaviour {

	[SerializeField]
	private GameObject mainBackButton;

	[SerializeField]
	private LoginScreen loginScript;

	[SerializeField]
	private Animator animator;

	private int customisationIndex = 0;

	public void Logout(){
		loginScript.ClearFields ();

		if (mainBackButton.activeSelf == true) {
			mainBackButton.GetComponent<MainBackButton> ().BackToPrevPage ();
		}

		if (mainBackButton.activeSelf == true) {
			mainBackButton.GetComponent<MainBackButton> ().BackToPrevPage ();
		}

		animator.SetTrigger("Open");
	}

}
