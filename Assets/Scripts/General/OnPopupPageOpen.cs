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

	private bool currentlyOpen;

	delegate void exitEvent();
	exitEvent triggerExitEvent;

	void Start(){
		anim = gameObject.GetComponent<Animator> ();
	}

	public void OnEnter(){
		currentlyOpen = true;
		EnableBackButton ();
		FillData ();
	}

	public void OnEnter(string[] _resource, PageType _pageType, GameObject _parent){
		currentlyOpen = true;
		resource = _resource;
		parent = _parent;
		pageType = _pageType;
		EnableBackButton ();
		FillData ();
	}

	public void OnExit(){
		if (parent != null) {
			mainBackButton.SetActiveScreen (parent);
			triggerExitEvent();
		}
		currentlyOpen = false;
		anim.SetInteger ("Show", 0);
	}

	public void ForceExit(){
		if(currentlyOpen)
			mainBackButton.backToPrevPage ();
	}

	private void FillData(){
		switch (pageType) {
		case PageType.CHALLENGER_PROFILE:
			gameObject.GetComponent<DummyChallengerProfile> ().FillInformation (resource[12]);
			triggerExitEvent = new exitEvent(RefreshSecondaryPage);
			break;
		case PageType.CHALLENGE_INFO:
			gameObject.GetComponent<DummyChallengeInfo> ().FillData(resource, DummyPullDataFromID.GetActiveAccountType());
			triggerExitEvent = new exitEvent(RefreshMasterPage);
			break;
		case PageType.EDIT_PROFILE:
			gameObject.GetComponent<DummyEditInformation> ().FillData (resource);
			gameObject.GetComponent<DummyEditInformation> ().ToggleSavebutton (true);
			triggerExitEvent = new exitEvent(ExitEditProfile);
			break;
		case PageType.CHALLENGER_EDIT_PROFILE:
			gameObject.GetComponent<DummyEditChallengerProfile> ().FillData (resource);
			gameObject.GetComponent<DummyEditChallengerProfile> ().ToggleSavebutton (true);
			triggerExitEvent = new exitEvent(ExitChallengerEditProfile);
			break;
		case PageType.CHALLENGER_EDIT_CHALLENGE:
			gameObject.GetComponent<DummyEditChallenge> ().FillData (resource);
			triggerExitEvent = new exitEvent (ExitChallengerEditChallenge);
			break;
		}
		anim.SetInteger ("Show", 1);
	}

	private void RefreshMasterPage(){
		parent.GetComponent<CreateFeedItemsFromArray> ().RefreshFeed ();
	}

	private void RefreshSecondaryPage(){
		parent.GetComponent<DummyChallengeInfo> ().ResetPage ();
	}

	private void ExitEditProfile(){
		gameObject.GetComponent<DummyEditInformation> ().ToggleSavebutton (false);
		gameObject.GetComponent<DummyEditInformation> ().CancelChanges ();
	}

	private void ExitChallengerEditProfile(){
		gameObject.GetComponent<DummyEditChallengerProfile> ().ToggleSavebutton (false);
		gameObject.GetComponent<DummyEditChallengerProfile> ().CancelChanges ();
	}

	private void ExitChallengerEditChallenge(){
		RefreshSecondaryPage ();
		gameObject.GetComponent<DummyEditChallenge> ().ClearEverything ();
	}

	public void EnableBackButton(){
		mainBackButton.SetActiveScreen (gameObject);
	}

	public void DisableBackButton(){
		mainBackButton.SetActiveScreen (null);
	}
}
