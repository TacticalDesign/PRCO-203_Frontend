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
	private Text rewardPoints;

	[SerializeField]
	private ClickForPopupPage listener;

	public void SetupFeedItem(string[] itemData, OnPopupPageOpen _pageToOpen){
		challengeName.text = itemData [3];
		skill1.text = itemData [4];
		skill2.text = itemData [5];
		skill3.text = itemData [6];
		rewardPoints.text = itemData [11] + " points";

		listener.SetResource (itemData);
		listener.SetPageToOpen (_pageToOpen);
	}

	public void SetListenerParent(GameObject _parent){
		listener.SetParentPage (_parent);
	}

	public string[] GetSearchData(){
		return new string[] { challengeName.text, skill1.text, skill2.text, skill3.text };
	}
}
