using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeViewFeedbackButton : MonoBehaviour {

	private string ID;

	[SerializeField]
	private GameObject feedbackPanel;

    [SerializeField]
    private Coins coins;

	public void SetChallengeID(string _ID){
		ID = _ID;
	}

	public void DisplayFeedback(){
		feedbackPanel.SetActive (true);
		feedbackPanel.GetComponent<ChallengeInfoFeedback> ().FillFeedbackPanel (ID);
        coins.Fire();
	}
}
