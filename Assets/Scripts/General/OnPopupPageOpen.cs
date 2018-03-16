using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPopupPageOpen : MonoBehaviour {

	[SerializeField]
	private MainBackButton mainBackButton;

	private Animator anim;

	private string[] resource;
	private PageType pageType;

	private GameObject parent;

	void Start(){
		anim = gameObject.GetComponent<Animator> ();
	}

	public void OnEnter(){
		EnableBackButton ();
		FillData ();
	}

	public void OnEnter(string[] _resource, PageType _pageType, GameObject _parent){
		resource = _resource;
		parent = _parent;
		pageType = _pageType;
		EnableBackButton ();
		FillData ();
	}

	public void OnExit(){
		if (parent != null)
			mainBackButton.SetActiveScreen (parent);

		anim.SetInteger ("Show", 0);
	}

	private void FillData(){
		switch (pageType) {
		case PageType.CHALLENGER_PROFILE:
			gameObject.GetComponent<DummyChallengerProfile> ().FillData (resource);
			break;
		case PageType.CHALLENGE_INFO:
			gameObject.GetComponent<DummyChallengeInfo> ().FillData(resource);
			break;
		case PageType.EDIT_PROFILE:
			gameObject.GetComponent<DummyEditInformation> ().FillData (resource);
			break;
		}
		anim.SetInteger ("Show", 1);
	}

	private void EnableBackButton(){
		mainBackButton.SetActiveScreen (gameObject);
	}
}
