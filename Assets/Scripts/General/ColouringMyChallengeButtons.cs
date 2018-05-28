using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColouringMyChallengeButtons : MonoBehaviour {

	[SerializeField]
	private Image otherButton;

	public void ChangeMyColour(){
		GetComponent<Image> ().color = Color.white;
		otherButton.color = Color.grey;
	}
}
