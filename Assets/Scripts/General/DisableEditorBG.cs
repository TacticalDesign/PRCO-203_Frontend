using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableEditorBG : MonoBehaviour {

	private Image myBG;

	void Start(){
		myBG = gameObject.GetComponent<Image> ();

		Color newBG = new Color (0f, 0f, 0f, 0.0f);

		myBG.color = newBG;
	}

}
