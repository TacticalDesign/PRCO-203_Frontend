using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForPopupPage : MonoBehaviour {

	[SerializeField]
	private string resourceID;

	[SerializeField]
	private PageType pageType;

	[SerializeField]
	private OnPopupPageOpen pageToOpen;

	[SerializeField]
	private GameObject parentPage = null;

	void Start(){
		if (parentPage == null) {
			parentPage = gameObject;
		}
	}

	public void PopupNewPage(){
		pageToOpen.OnEnter (resourceID, pageType, parentPage);
	}

	public void SetResourceID(string _resourceID){
		resourceID = _resourceID;
	}

	public void SetPageToOpen(OnPopupPageOpen _pageToOpen){
		pageToOpen = _pageToOpen;
	}
}
