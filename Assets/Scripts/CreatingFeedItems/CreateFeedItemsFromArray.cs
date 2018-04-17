using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFeedItemsFromArray : MonoBehaviour {

	[SerializeField]
	private GameObject itemFeedContainer;

	[SerializeField]
	private OnPopupPageOpen pageToOpen;

	[SerializeField]
	private GameObject objectToInstantiate;

	[SerializeField]
	private GameObject parentScrollRect;

	[SerializeField]
	private GeneratorType whichItemsToPull;

	private string[][] displayedItems;


	void Start(){
		ChangeFeedDisplay (whichItemsToPull);
	}

	public void ChangeFeedDisplay(GeneratorType _newFeedType){
		ResetFeed ();
		whichItemsToPull = _newFeedType;

		switch (whichItemsToPull) {
		case GeneratorType.CHALLENGE_FEED:
			PullAllChallenges ();
			FillChallengeFeed ();
			break;
		case GeneratorType.COMPLETED_FEED:
			PullCompleted ();
			FillChallengeFeed ();
			break;
		case GeneratorType.UPCOMING_FEED:
			PullUpcoming ();
			FillChallengeFeed ();
			break;
		case GeneratorType.REWARD_PAGE:
			PullRewards ();
			FillRewardFeed ();
			break;
		case GeneratorType.FEEDBACK_PAGE:
			PullFeedback ();
			FillFeedbackFeed ();
			break;
		case GeneratorType.CHALLENGER_UPCOMING:
			PullChallengerUpcoming ();
			FillChallengerFeed ();
			break;
		}


	}

	public void ResetFeed(){
		foreach (Transform child in itemFeedContainer.transform) {
			Destroy (child.gameObject);
		}
	}

	public void RefreshFeed(){
		ChangeFeedDisplay (whichItemsToPull);
	}

	public void FillChallengeFeed(){
		foreach (string[] s in displayedItems) {
			if(s[13] == "true")
				MakeNewChallengeFeedItem (s);
		}
	} 

	public void FillChallengerFeed(){
		foreach (string[] s in displayedItems) {
			if(s[12] == "true")
				MakeNewChallengeFeedItem (s);
		}
	} 

	private void PullAllChallenges(){
		displayedItems = DummyPullDataFromID.PullFeedChallenges ();
	}

	private void PullUpcoming(){
		displayedItems = DummyPullDataFromID.PullUpcoming ();
	}

	private void PullCompleted(){
		displayedItems = DummyPullDataFromID.PullCompleted ();
	}

	private void MakeNewChallengeFeedItem(string[] resource){
		GameObject newChallenge = Instantiate (objectToInstantiate, itemFeedContainer.transform);
		newChallenge.GetComponent<FillFeedItems> ().SetupFeedItem (resource, pageToOpen);
		newChallenge.GetComponent<FillFeedItems> ().SetListenerParent (gameObject);
		newChallenge.GetComponent<OnClickHandler> ().SetParentScrollRect (parentScrollRect);
	}

	public void FillRewardFeed(){
		foreach (string[] s in displayedItems) {
			MakeRewardFeedItem (s);
		}
	} 

	private void PullRewards(){
		displayedItems = DummyPullDataFromID.PullRewards ();
	}

	private void MakeRewardFeedItem(string[] resource){
		GameObject newReward = Instantiate (objectToInstantiate, itemFeedContainer.transform);
		newReward.GetComponent<FillRewardItems> ().FillItems (resource, parentScrollRect);
		newReward.GetComponent<DummyAcceptReward>().SetRefreshScript(GetComponent<DummyRewardPage>());
	}

	public void FillFeedbackFeed(){
		foreach (string[] s in displayedItems) {
			MakeFeedbackItem (s);
		}
	} 

	private void PullFeedback(){
		displayedItems = DummyPullDataFromID.PullFeedback ();
	}

	private void MakeFeedbackItem(string[] resource){
		GameObject newFeedback = Instantiate (objectToInstantiate, itemFeedContainer.transform);
		newFeedback.GetComponent<FillFeedbackItems> ().FillItems (resource);
	}

	private void PullChallengerUpcoming(){

	}
}
