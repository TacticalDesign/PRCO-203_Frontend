using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyEditChallenge : MonoBehaviour {

	[SerializeField]
	private Text challengeTitle;
	[SerializeField]
	private Text challengerName;
	[SerializeField]
	private Text skill1;
	[SerializeField]
	private Text skill2;
	[SerializeField]
	private Text skill3;
	[SerializeField]
	private Text challengeDate;
	[SerializeField]
	private Text challengeDeadline;
	[SerializeField]
	private Text description;
	[SerializeField]
	private Image challengePic;

	[SerializeField]
	private InputField newChallengeTitle;
	[SerializeField]
	private InputField newSkill1;
	[SerializeField]
	private InputField newSkill2;
	[SerializeField]
	private InputField newSkill3;
	[SerializeField]
	private InputField newChallengeDate;
	[SerializeField]
	private InputField newChallengeDeadline;
	[SerializeField]
	private InputField newDescription;

	[SerializeField]
	private InputField[] everything;

	private string[] myData;

	[SerializeField]
	private DummyChallengeInfo challengePage;

	public void FillData(string[] _resource){
		myData = _resource;

		ClearEverything ();

		challengeTitle.text = _resource[3];
		challengerName.text = _resource[10];
		skill1.text = _resource[4];
		skill2.text = _resource[5];
		skill3.text = _resource[6];
		challengeDate.text = _resource[8];
		challengeDeadline.text = _resource[9];
		description.text = _resource[7];
		challengePic.sprite = DummyPullDataFromID.GetChallengeImage (_resource [0]);
	}

	public void SaveData(){
		List<string> newData = new List<string> ();

		newData.Add (myData [0]);
		newData.Add ("false");
		newData.Add ("false");

		if (newChallengeTitle.text == "" || newChallengeTitle.text == null) {
			newData.Add (myData [3]);
		} else {
			newData.Add (newChallengeTitle.text);
		}

		if (newSkill1.text == "" || newSkill1.text == null) {
			newData.Add (myData [4]);
		} else {
			newData.Add (newSkill1.text);
		}

		if (newSkill2.text == "" || newSkill2.text == null) {
			newData.Add (myData [5]);
		} else {
			newData.Add (newSkill2.text);
		}

		if (newSkill3.text == "" || newSkill3.text == null) {
			newData.Add (myData [6]);
		} else {
			newData.Add (newSkill3.text);
		}

		if (newDescription.text == "" || newDescription.text == null) {
			newData.Add (myData [7]);
		} else {
			newData.Add (newDescription.text);
		}

		if (newChallengeDate.text == "" || newChallengeDate.text == null) {
			newData.Add (myData [8]);
		} else {
			newData.Add (newChallengeDate.text);
		}

		if (newChallengeDeadline.text == "" || newChallengeDeadline.text == null) {
			newData.Add (myData [9]);
		} else {
			newData.Add (newChallengeDeadline.text);
		}

		newData.Add (myData [10]);
		newData.Add (myData [11]);
		newData.Add (myData [12]);
		newData.Add (myData [13]);

		DummyPullDataFromID.UpdateChallengeInfo (newData.ToArray ());
		GetComponent<OnPopupPageOpen> ().ForceExit ();
	}

	public void ClearEverything(){
		for (int i = 0; i < everything.Length; i++) {
			everything [i].text = null;
		}
	}
}
