using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAcceptReward : MonoBehaviour {

	private DummyRewardPage refreshScript;

	public void AcceptReward(){
		string ID = GetComponent<FillRewardItems> ().GetID ();
		DummyPullDataFromID.RemoveReward (ID);
		refreshScript.UpdatePoints ();
	}

	public void DialogueAccepted(){
		AcceptReward ();
		Destroy (gameObject);
	}	 

	public void SetRefreshScript(DummyRewardPage _refScript){
		refreshScript = _refScript;
	}
}
