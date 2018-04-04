using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyOptOut : MonoBehaviour {

	[SerializeField]
	private DummyChallengeInfo resetPage;

	private string[] resource;

	public void OptOut(){
		if (resource != null) {
			DummyPullDataFromID.UpdateData (resource [0], 1, "false");
		} else {
			Debug.Log ("Resource empty @ DummyOptOut");
		}
	}

	public void SetResource(string[] _resource){
		resource = _resource;
	}

	public void DialogueAccepted(){
		OptOut ();
		resetPage.ResetPage ();
	}
}
