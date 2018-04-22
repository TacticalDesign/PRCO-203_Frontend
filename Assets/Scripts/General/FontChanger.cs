using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontChanger : MonoBehaviour {

	private Text textField;

	void Start(){
		textField = GetComponent<Text> ();
	}

	public void ChangeMyFont(Font _newFont){
		textField.font = _newFont;
	}
}
