using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillFeedbackItems : MonoBehaviour {

	[SerializeField]
	private Text feedbackDescription;
	[SerializeField]
	private Text feedbackValue;
	[SerializeField]
	private Text feedbackGiver;

	private string[] feedbackData;

	public void FillItems(string[] _resource){
		feedbackData = _resource;

		feedbackDescription.text = feedbackData [2];
		feedbackValue.text = feedbackData [3] + " / 5";
		feedbackGiver.text = feedbackData [4];
	}
}
