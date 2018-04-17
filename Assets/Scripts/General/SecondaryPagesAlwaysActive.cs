using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryPagesAlwaysActive : MonoBehaviour {

	[SerializeField]
	private GameObject[] secondaryPages;

	// Use this for initialization
	void Start () {
		foreach (GameObject g in secondaryPages) {
			g.SetActive (true);
		}
	}
}
