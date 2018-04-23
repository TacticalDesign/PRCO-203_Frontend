using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoutScript : MonoBehaviour {

	[SerializeField]
	private MainCanvas mainCanvas;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Color[] testColours;

	[SerializeField]
	private Font[] testFonts;

	private int customisationIndex = 0;

	public void Logout(){
		//animator.SetTrigger("Open");

		ColourChanger[] customisation = GameObject.FindObjectsOfType<ColourChanger> ();
		foreach (ColourChanger c in customisation) {
			c.ChangeMyColour (testColours [customisationIndex]);
		}

		FontChanger[] fontCust = GameObject.FindObjectsOfType<FontChanger> ();
		foreach (FontChanger f in fontCust) {
			f.ChangeMyFont (testFonts [customisationIndex]);
		}

		if (customisationIndex == testColours.Length - 1) {
			customisationIndex = 0;
		} else {
			customisationIndex++;
		}
	}

}
