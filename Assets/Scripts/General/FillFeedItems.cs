using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillFeedItems : MonoBehaviour {

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
		challengeName.text = itemData [3];
		skill1.text = itemData [4];
		skill2.text = itemData [5];
		skill3.text = itemData [6];
		description.text = itemData [7];
		closeDate.text = itemData [8];
		deadline.text = itemData [9];
		challengerName.text = itemData [10];

		listener.SetResource (itemData);
		listener.SetPageToOpen (_pageToOpen);
	}

	public void SetListenerParent(GameObject _parent){
		listener.SetParentPage (_parent);
	}
}
