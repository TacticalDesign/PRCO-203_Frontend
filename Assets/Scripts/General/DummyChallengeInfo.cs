using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyChallengeInfo : MonoBehaviour {

	//7 text boxes

	[SerializeField]
	private Text challengeTitle;
	[SerializeField]
	private Text challengeDescription;
	[SerializeField]
	private Text skillOne;
	[SerializeField]
	private Text skillTwo;
	[SerializeField]
	private Text SkillThree;
	[SerializeField]
	private Text challengerName;
	[SerializeField]
	private Text challengeDate;
	[SerializeField]
	private Text challengeDeadline;

	[SerializeField]
	private ClickForPopupPage listener;

	[SerializeField]
	private GameObject[] DisplayButtons;

	private string resID;

	public void FillData(string[] _resource){
		resID = _resource [0];

		challengeTitle.text = _resource [3];
		skillOne.text = _resource [4];
		skillTwo.text = _resource [5];
		SkillThree.text = _resource [6];
		challengeDescription.text = _resource [7];
		challengeDate.text = _resource [8];
		challengeDeadline.text = _resource [9];
		challengerName.text = _resource [10];

		listener.SetResource (_resource);

		SortButtons (_resource);
	}

	public void SortButtons(string[] _resource){
		foreach (GameObject g in DisplayButtons) {
			g.SetActive (false);
		}
		if (_resource [2] == "true") {
			DisplayButtons [2].SetActive (true);
		} else if (_resource [1] == "true") {
			DisplayButtons [1].SetActive (true);
			DisplayButtons [1].GetComponent<DummyOptOut> ().SetResource (_resource);
		} else {
			DisplayButtons [0].SetActive (true);
			DisplayButtons [0].GetComponent<DummyAcceptChallenge> ().SetResource (_resource);
		}
	}

	public void ResetPage(){
		string[] refresh = DummyPullDataFromID.PullArrayByID (resID);
		FillData (refresh);
	}
}
