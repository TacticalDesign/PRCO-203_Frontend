using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyEditChallengerProfile : MonoBehaviour {

	[SerializeField]
	private Text name;
	[SerializeField]
	private Text email;
	[SerializeField]
	private Text phone;
	[SerializeField]
	private Text description;
	[SerializeField]
	private Image profilePic;

	[SerializeField]
	private Text[] textInputBoxes;

	[SerializeField]
	private DummyChallengerProfile profile;

	[SerializeField]
	private GameObject saveButton;

	private string[] myData;

	public void FillData(string[] _myData){
		myData = _myData;
		name.text = _myData [1];
		email.text = _myData [2];
		phone.text = _myData [3];
		description.text = _myData [4];
		profilePic.sprite = DummyPullDataFromID.GetChallengerProfileImage (_myData [0]);
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

		DummyPullDataFromID.UpdateChallengerInfo (myData[0], returnList.ToArray());
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
