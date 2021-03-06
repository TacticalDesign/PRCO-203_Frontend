﻿using System.Collections;
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

	private Font themeFont;

	public void FillItems(string[] _resource){
		themeFont = ChangeColourScheme.GetCurrentFont ();
		foreach(FontChanger f in GetComponentsInChildren<FontChanger> ()){
			f.ChangeMyFont (themeFont);
		}

		feedbackData = _resource;

		feedbackDescription.text = feedbackData [2];
		feedbackValue.text = feedbackData [3] + " / 5";
		feedbackGiver.text = feedbackData [4];
	}
}
