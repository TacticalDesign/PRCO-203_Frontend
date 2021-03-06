﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillRewardItems : MonoBehaviour {

	[SerializeField]
	private Text rewardTitle;
	[SerializeField]
	private Text rewardDescription;
	[SerializeField]
	private Text rewardPoints;
	[SerializeField]
	private Image rewardImage;

	private string rewardID;
	private int rewardCost;

	private Font themeFont;

	public void FillItems(string[] _rewardData, GameObject _parentScrollRect){
		themeFont = ChangeColourScheme.GetCurrentFont ();
		foreach(FontChanger f in GetComponentsInChildren<FontChanger> ()){
			f.ChangeMyFont (themeFont);
		}

		rewardID = _rewardData [0];
		rewardTitle.text = _rewardData [1];
		rewardDescription.text = _rewardData [2];
		rewardPoints.text = _rewardData [3];
		rewardCost = int.Parse(_rewardData [3]);

		rewardImage.sprite = DummyPullDataFromID.GetRewardImage (_rewardData [0]);

		GetComponent<OnClickHandler> ().SetParentScrollRect (_parentScrollRect);
	}

	public string GetID(){
		return rewardID;
	}

	public void CanRedeem(){
		int tempRewardPoints = int.Parse (DummyPullDataFromID.PullPersonalInformation() [8]);
		Debug.Log ("Mine: " + tempRewardPoints + ", target: " + rewardCost);
		if (tempRewardPoints >= rewardCost) {
			GetComponent<ClickForDialogueBox> ().SetupDialogue ();
		} else {
			GetComponent<ClickForInformationBox> ().SetupInfo ();
		}
	}

	public string[] GetSearchData(){
		return new string[] { rewardTitle.text, rewardPoints.text, rewardDescription.text};
	}
}
