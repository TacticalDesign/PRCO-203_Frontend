using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackItem : MonoBehaviour {

	[SerializeField]
	private Text youthName;

	[SerializeField]
	private InputField ratingInput;

	[SerializeField]
	private InputField textFeedbackInput;

	private string youthID;

	private string[] challengeInfo;

	public void SetupItem(string _youthID, string[] _challengeInfo){
		youthID = _youthID;
		challengeInfo = _challengeInfo;
		youthName.text = DummyPullDataFromID.PullYouthInfoByID (_youthID)[1];
	}

	public bool VerifyItem(){
		bool verified = true;

		if (ratingInput.text == "" || ratingInput.text == null) {
			ErrorInField (ratingInput, "Please enter a valid number");
			verified = false;
		} else if (int.Parse (ratingInput.text) <= 0 || int.Parse (ratingInput.text) > 5) {
			ErrorInField (ratingInput, "Please enter a number between 1 and 5");
			verified = false;
		}

		if (textFeedbackInput.text == "" || textFeedbackInput.text == null) {
			ErrorInField (textFeedbackInput, "Please leave a comment for the youth");
			verified = false;
		}

		return verified;
	}

	public string[] GetFeedbackData(){
		string[] feedbackData = new string[] {
			challengeInfo[0],
			youthID,
			textFeedbackInput.text,
			ratingInput.text,
			DummyPullDataFromID.PullMyChallengerInfo()[0],
			challengeInfo[3]
		};
		return feedbackData;
	}

	public void ErrorInField(InputField _fieldWithError, string _messageToDisplay){
		_fieldWithError.text = "";
		_fieldWithError.placeholder.GetComponent<Text> ().color = Color.red;
		_fieldWithError.placeholder.GetComponent<Text> ().text = _messageToDisplay;
	}
}
