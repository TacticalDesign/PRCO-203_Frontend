using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyYouthLogin : MonoBehaviour {

	[SerializeField]
	private DummyFillInformation profilePage;

	[SerializeField]
	private CreateFeedItemsFromArray splashPage;

	public void SendID(string _youthID){
		profilePage.SetInformationID (_youthID);
		splashPage.RefreshFeed ();
		DummyPullDataFromID.SetActiveAccountType (AccountType.Youth);
	}
}
