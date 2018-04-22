using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourChanger : MonoBehaviour {

	private Image imageField;

	void Start(){
		imageField = GetComponent<Image> ();
	}

	public void ChangeMyColour(Color _newColour){
		imageField.color = _newColour;
	}
}
