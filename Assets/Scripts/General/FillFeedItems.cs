using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillFeedItems : MonoBehaviour {

	private string challengeID;

	[SerializeField]
	private Text challengeName;
	[SerializeField]
	private Text skill1;
	[SerializeField]
	private Text skill2;
	[SerializeField]
	private Text skill3;
	[SerializeField]
	private Text description;
	[SerializeField]
	private Text closeDate;
	[SerializeField]
	private Text deadline;
	[SerializeField]
	private Text challengerName;

	[SerializeField]
	private ClickForPopupPage listener;

	public void SetupFeedItem(string[] itemData, OnPopupPageOpen _pageToOpen){
		challengeID = itemData [0];
		challengeName.text = itemData [1];
		skill1.text = itemData [2];
		skill2.text = itemData [3];
		skill3.text = itemData [4];
		description.text = itemData [5];
		closeDate.text = itemData [6];
		deadline.text = itemData [7];
		challengerName.text = itemData [8];

		listener.SetResourceID (challengeID);
		listener.SetPageToOpen (_pageToOpen);
	}


}
