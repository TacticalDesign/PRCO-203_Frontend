using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyEditInformation : MonoBehaviour {

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
	private Text[] textInputBoxes;

	[SerializeField]
	private DummyFillInformation profile;

	[SerializeField]
	private GameObject saveButton;

	private string[] myData;

	public void FillData(string[] _myData){
		myData = _myData;
		name.text = _myData [1];
		skillOne.text = _myData [2];
		skillTwo.text = _myData [3];
		skillThree.text = _myData [4];
		interestOne.text = _myData [5];
		interestTwo.text = _myData [6];
		interestThree.text = _myData [7];
	}

	public void SaveChanges(){
		List<string> returnList = new List<string> ();
		returnList.Add (myData [0]);

		for (int i = 0; i < textInputBoxes.Length; i++) {
			if (textInputBoxes [i].text == null || textInputBoxes [i].text == "") {
				returnList.Add (myData [i + 1]);
			} else {
				returnList.Add (textInputBoxes [i].text);
			}
			textInputBoxes [i].text = "";
		}

		returnList.Add (myData [8]);
		returnList.Add (myData [9]);

		DummyPullDataFromID.UpdatePersonalInfo (returnList.ToArray());
		profile.FillInformation ();
		gameObject.GetComponent<OnPopupPageOpen> ().ForceExit ();
	}

	public void ToggleSavebutton(bool _state){
		saveButton.SetActive (_state);
	}

	public void CancelChanges(){
		for (int i = 0; i < textInputBoxes.Length; i++) {
			textInputBoxes [i].text = "";
		}
	}
}
