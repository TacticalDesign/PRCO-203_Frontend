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
	private Image bgColour;

	[SerializeField]
	private Image challengeIcon;

	[SerializeField]
	private ClickForPopupPage listener;

	private Font themeFont;

	public void SetupFeedItem(string[] _itemData, OnPopupPageOpen _pageToOpen){
		themeFont = ChangeColourScheme.GetCurrentFont ();
		foreach(FontChanger f in GetComponentsInChildren<FontChanger> ()){
			f.ChangeMyFont (themeFont);
		}
			
		challengeName.text = _itemData [3];
		skill1.text = _itemData [4];
		skill2.text = _itemData [5];
		skill3.text = _itemData [6];
		rewardPoints.text = _itemData [11] + " points";

		challengeIcon.sprite = DummyPullDataFromID.GetChallengeImage (_itemData [0]);

		if (_itemData [13] == "true") {
			bgColour.color = Color.white;
		} else {
			bgColour.color = new Color32 (255, 174, 174, 255);
		}

		listener.SetResource (_itemData);
		listener.SetPageToOpen (_pageToOpen);
	}

	public void SetListenerParent(GameObject _parent){
		listener.SetParentPage (_parent);
	}

	public string[] GetSearchData(){
		return new string[] { challengeName.text, skill1.text, skill2.text, skill3.text };
	}
}
