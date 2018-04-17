using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyChallengerProfile : MonoBehaviour {

	[SerializeField]
	private Text name;
	[SerializeField]
	private Text email;
	[SerializeField]
	private Text number;
	[SerializeField]
	private Text description;

	private string fillInformationID;

	private string[] myInformation;

	[SerializeField]
	private ClickForPopupPage editProfileButton;

	public void FillInformation(){
		myInformation = DummyPullDataFromID.PullMyChallengerInfo ();

		name.text = myInformation [1];
		email.text = myInformation [2];
		number.text = myInformation [3];
		description.text = myInformation [4];

		editProfileButton.SetResource (myInformation);
	}

	public void FillInformation(string _challengerID){
		string[] resource = DummyPullDataFromID.PullChallengerInfoByString (_challengerID);

		name.text = resource [1];
		email.text = resource [2];
		number.text = resource [3];
		description.text = resource [4];
	}
}
