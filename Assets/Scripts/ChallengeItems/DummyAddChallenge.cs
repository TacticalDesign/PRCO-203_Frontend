using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DummyAddChallenge : MonoBehaviour {
	
	[SerializeField]
	private Text challengerName;

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

	public void SetupPage(){
		ClearEverything ();

		myData = DummyPullDataFromID.PullMyChallengerInfo ();

		challengerName.text = myData [1];
	}

	public void SaveNewChallenge(){
		List<string> newData = new List<string> ();

		newData.Add (DummyPullDataFromID.GenerateNewChallengeID());
		newData.Add ("false");
		newData.Add ("false");

		string[] challengeTitleBreakdown;
		string rewardPoints = "";

		if (newChallengeTitle.text == "" || newChallengeTitle.text == null) {
			ErrorInField (newChallengeTitle.GetComponentInParent<InputField> ());
			return;
		} else {
			try{
				String challengeTitle = newChallengeTitle.text;
				Char[] delimiter = new Char[]{'(', ')'};
				challengeTitleBreakdown = challengeTitle.Split(delimiter, 3);
				newData.Add (challengeTitleBreakdown[2].Trim());
				rewardPoints = challengeTitleBreakdown[1];
			} catch (UnityException ex) {
				Debug.Log(ex);
				ErrorInField (newChallengeTitle.GetComponentInParent<InputField> ());
				return;
			}
		}

		if (newSkill1.text == "" || newSkill1.text == null) {
			ErrorInField (newSkill1.GetComponentInParent<InputField> ());
			return;
		} else {
			newData.Add (newSkill1.text);
		}

		if (newSkill2.text == "" || newSkill2.text == null) {
			ErrorInField (newSkill2.GetComponentInParent<InputField> ());
			return;
		} else {
			newData.Add (newSkill2.text);
		}

		if (newSkill3.text == "" || newSkill3.text == null) {
			ErrorInField (newSkill3.GetComponentInParent<InputField> ());
			return;
		} else {
			newData.Add (newSkill3.text);
		}

		if (newDescription.text == "" || newDescription.text == null) {
			ErrorInField (newDescription.GetComponentInParent<InputField> ());
			return;
		} else {
			newData.Add (newDescription.text);
		}

		if (newChallengeDate.text == "" || newChallengeDate.text == null) {
			ErrorInField (newChallengeDate.GetComponentInParent<InputField> ());
			return;
		} else {
			newData.Add (newChallengeDate.text);
		}

		if (newChallengeDeadline.text == "" || newChallengeDeadline.text == null) {
			ErrorInField (newChallengeDeadline.GetComponentInParent<InputField> ());
			return;
		} else {
			newData.Add (newChallengeDeadline.text);
		}

		newData.Add (myData [1]);
		newData.Add (rewardPoints);
		newData.Add (myData [0]);

		if (challengeTitleBreakdown [0].Trim ().ToLower () == "true")
			newData.Add ("true");
		else
			newData.Add ("false");

		DummyPullDataFromID.AddChallenge (newData.ToArray (), DummyPullDataFromID.GetTestImage());
		GetComponent<OnPopupPageOpen> ().ForceExit ();
	}

	public void ClearEverything(){
		for (int i = 0; i < everything.Length; i++) {
			everything [i].text = null;
		}
	}

	public void ErrorInField(InputField _fieldWithError){
		_fieldWithError.placeholder.GetComponent<Text> ().color = Color.red;
		_fieldWithError.placeholder.GetComponent<Text> ().text = "Missing Data: Please Fill This Field";
	}
}
