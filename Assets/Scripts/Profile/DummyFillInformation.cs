using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyFillInformation : MonoBehaviour {

	[SerializeField]
	private Text name;
	[SerializeField]
	private Text skillOne;
	[SerializeField]
	private Text skillTwo;
	[SerializeField]
	private Text skillThree;
	[SerializeField]
	private Text interestOne;
	[SerializeField]
	private Text interestTwo;
	[SerializeField]
	private Text interestThree;
	[SerializeField]
	private Text rewardPoints;
	[SerializeField]
	private Text avgFeedback;

	private string fillInformationID;

	private string[] myInformation;

	[SerializeField]
	private ClickForPopupPage editProfileButton;

	public void FillInformation(){
		myInformation = DummyPullDataFromID.PullPersonalInformation ();

		name.text = myInformation [1];
		skillOne.text = myInformation [2];
		skillTwo.text = myInformation [3];
		skillThree.text = myInformation [4];
		interestOne.text = myInformation [5];
		interestTwo.text = myInformation [6];
		interestThree.text = myInformation [7];
		rewardPoints.text = "Reward Points: " + myInformation [8];
		avgFeedback.text = "Average Rating: " + myInformation [9] + " / 5";

		editProfileButton.SetResource (myInformation);
	}

	public void SetInformationID(string _myID){
		fillInformationID = _myID;
	}
}
