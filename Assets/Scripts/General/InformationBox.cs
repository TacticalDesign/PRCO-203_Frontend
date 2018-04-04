using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationBox : MonoBehaviour {

	[SerializeField]
	private Text infoDesc;
	[SerializeField]
	private Text cancelText;

	private ClickForInformationBox parent;

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ClickCancel ();
		}
	}

	public void SetupInformationBox(InformationBoxType _boxType, ClickForInformationBox _parent){
		parent = _parent;

		switch (_boxType) {
		case InformationBoxType.INSUFFICIENT_REWARD_POINTS:
			infoDesc.text = "Sorry! Not enough reward points for this item. Go take on some more challenges and come back when you have more points!";
			cancelText.text = "Ok :(";
			break;
		}
	}

	public void ClickCancel(){
		parent.FlagResponse (DialogueResponses.CANCEL);
	}
}
