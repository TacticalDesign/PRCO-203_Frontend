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
		animator.SetTrigger("Open");
	}

}
