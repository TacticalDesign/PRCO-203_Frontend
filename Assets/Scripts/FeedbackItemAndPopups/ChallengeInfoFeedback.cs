using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeInfoFeedback : MonoBehaviour {

	[SerializeField]
	private FillFeedbackItems feedbackPanel;

	public void FillFeedbackPanel(string _challengeID){
		feedbackPanel.FillItems (DummyPullDataFromID.PullFeedbackByChallenge (_challengeID));
	}

	public void CloseFeedbackPanel(){
		gameObject.SetActive (false);
	}
}
