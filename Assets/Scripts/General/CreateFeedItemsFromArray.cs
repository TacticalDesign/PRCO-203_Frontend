using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFeedItemsFromArray : MonoBehaviour {

	[SerializeField]
	private GameObject ChallengeFeedContainer;

	[SerializeField]
	private OnPopupPageOpen pageToOpen;

	[SerializeField]
	private GameObject objectToInstantiate;

	[SerializeField]
	private GameObject parentScrollRect;

	private string[][] allChallenges;


	void Start(){
		PullAllChallenges ();
		FillChallengeFeed ();
	}

	public void FillChallengeFeed(){
		foreach (string[] s in allChallenges) {
			MakeNewChallengeFeedItem (s);
		}
	} 

	private void PullAllChallenges(){
		allChallenges = DummyPullDataFromID.PullAllChallenges ();
	}

	private void MakeNewChallengeFeedItem(string[] resource){
		GameObject newChallenge = Instantiate (objectToInstantiate, ChallengeFeedContainer.transform);
		newChallenge.GetComponent<FillFeedItems> ().SetupFeedItem (resource, pageToOpen);
		newChallenge.GetComponent<OnClickHandler> ().SetParentScrollRect (parentScrollRect);
	}
}
