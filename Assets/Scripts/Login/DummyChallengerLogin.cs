using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyChallengerLogin : MonoBehaviour {

	[SerializeField]
	private CreateFeedItemsFromArray splashPage;

	public void SetChallengerID(string _ID){
		DummyPullDataFromID.SetChallengerID (_ID);
		splashPage.RefreshFeed ();
		DummyPullDataFromID.SetActiveAccountType (AccountType.Challenger);
	}
}
