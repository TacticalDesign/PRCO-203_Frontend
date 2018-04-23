using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSelector : MonoBehaviour {

	[SerializeField]
	private ChangeColourScheme parent;

	public void SelectTheme(int _themeSelected){
		parent.ChangeTheme (_themeSelected);
		gameObject.SetActive (false);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			gameObject.SetActive (false);
		}
	}
}
