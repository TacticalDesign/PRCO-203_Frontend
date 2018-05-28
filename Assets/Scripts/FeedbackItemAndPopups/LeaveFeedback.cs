using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveFeedback : MonoBehaviour {

	[SerializeField]
	private GameObject FeedbackItemPrefab;

	[SerializeField]
	private Transform feedbackItemContainer;

	private List<FeedbackItem> feedbackItems = new List<FeedbackItem> ();

	private string challengeID;

	public void FillData(string[] _challengeResource, string _youthIDsAssignedToChallenge){ //Will be an array with all youth ID's assigned to the challenge after backend implementation
		challengeID = _challengeResource[0];

		//foreach (string ID in _youthIDsAssignedToChallenge) {
			GameObject newFeedbackItem = Instantiate (FeedbackItemPrefab, feedbackItemContainer);
		newFeedbackItem.GetComponent<FeedbackItem> ().SetupItem (_youthIDsAssignedToChallenge, _challengeResource);
			feedbackItems.Add (newFeedbackItem.GetComponent<FeedbackItem> ());
		//}
	}

	public void SaveFeedback(){
		bool allVerified = true;

		foreach (FeedbackItem f in feedbackItems) {
			if (f.VerifyItem() == false) {
				allVerified = false;
			}
		}

		if (allVerified == false) {
			return;
		}

		foreach (FeedbackItem f in feedbackItems) {
			DummyPullDataFromID.AddFeedback (f.GetFeedbackData());
		}

		DummyPullDataFromID.MarkChallengeAsComplete (challengeID);
		GetComponent<OnPopupPageOpen> ().ForceExit ();
	}
}
