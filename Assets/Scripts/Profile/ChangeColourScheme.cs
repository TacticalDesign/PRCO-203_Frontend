﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColourScheme : MonoBehaviour {

	// Colours for themes:
	//
	// Splash: ff4949ff
	// Lavendar: a08ff9ff
	// Autumn: f2b262ff

	[SerializeField]
	private Image themeColour;

	[SerializeField]
	private Text themeTitle;

	private static Font s_currentFont;

	[SerializeField]
	private Color[] themeColours = new Color[]{};
		
	[SerializeField]
	private Font[] themeFonts = new Font[]{};

	[SerializeField]
	private string[] themeTitles = new string[]{};

	[SerializeField]
	private GameObject colourSelector;

	private int currentThemeIndex;

	void Awake(){
		s_currentFont = themeFonts[0];
	}

	public void SelectColour(){
		colourSelector.SetActive (true);
		colourSelector.GetComponent<ColourSelector> ().SetParent (this);
	}

	public void ChangeTheme(int _themeIndex){
		ColourChanger[] colourCust = GameObject.FindObjectsOfType<ColourChanger> ();
		foreach (ColourChanger c in colourCust) {
			c.ChangeMyColour (themeColours[_themeIndex]);
		}

		FontChanger[] fontCust = GameObject.FindObjectsOfType<FontChanger> ();
		foreach (FontChanger f in fontCust) {
			f.ChangeMyFont (themeFonts[_themeIndex]);
		}

		s_currentFont = themeFonts [_themeIndex];
		themeTitle.text = themeTitles [_themeIndex];
		themeColour.color = themeColours [_themeIndex];

		currentThemeIndex = _themeIndex;
	}

	public static Font GetCurrentFont(){
		return s_currentFont;
	}
}
