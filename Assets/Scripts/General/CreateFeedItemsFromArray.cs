using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFeedItemsFromArray : MonoBehaviour {

	[SerializeField]
	private GameObject challengeFeedContainer;

	[SerializeField]
	private OnPopupPageOpen pageToOpen;

	[SerializeField]
	private GameObject objectToInstantiate;

	[SerializeField]
	private GameObject parentScrollRect;

	[SerializeField]
	private GeneratorType whichChallengesToPull;

	private string[][] displayedChallenges;


	void Start(){
		ChangeFeedDisplay (whichChallengesToPull);
	}

	public void ChangeFeedDisplay(GeneratorType _newFeedType){
		ResetFeed ();
		whichChallengesToPull = _newFeedType;

		switch (whichChallengesToPull) {
		case GeneratorType.CHALLENGE_FEED:
			PullAllChallenges ();
			break;
		case GeneratorType.COMPLETED_FEED:
			PullCompleted ();
			break;
		case GeneratorType.UPCOMING_FEED:
			PullUpcoming ();
			break;
		}

		FillChallengeFeed ();
	}

	public void ResetFeed(){
		foreach (Transform child in challengeFeedContainer.transform) {
			Destroy (child.gameObject);
		}
	}

	public void RefreshFeed(){
		ChangeFeedDisplay (whichChallengesToPull);
	}

	public void FillChallengeFeed(){
		foreach (string[] s in displayedChallenges) {
			MakeNewChallengeFeedItem (s);
		}
	} 

	private void PullAllChallenges(){
		displayedChallenges = DummyPullDataFromID.PullFeedChallenges ();
	}

	private void PullUpcoming(){
		displayedChallenges = DummyPullDataFromID.PullUpcoming ();
	}

	private void PullCompleted(){
		displayedChallenges = DummyPullDataFromID.PullCompleted ();
	}

	private void MakeNewChallengeFeedItem(string[] resource){
		GameObject newChallenge = Instantiate (objectToInstantiate, challengeFeedContainer.transform);
		newChallenge.GetComponent<FillFeedItems> ().SetupFeedItem (resource, pageToOpen);
		newChallenge.GetComponent<FillFeedItems> ().SetListenerParent (gameObject);
		newChallenge.GetComponent<OnClickHandler> ().SetParentScrollRect (parentScrollRect);
	}
}
