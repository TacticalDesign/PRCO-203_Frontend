using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAcceptChallenge : MonoBehaviour {

	[SerializeField]
	private DummyChallengeInfo resetPage;

	private string[] resource;

	public void AcceptChallenge(){
		if (resource != null) {
			DummyPullDataFromID.UpdateData (resource [0], 1, "true");
		} else {
			Debug.Log ("Resource empty @ DummyAcceptChallenge");
		}
	}

	public void SetResource(string[] _resource){
		resource = _resource;
	}

	public void DialogueAccepted(){
		AcceptChallenge ();
		resetPage.ResetPage ();
	}
}
