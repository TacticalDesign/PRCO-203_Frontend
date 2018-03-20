using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForPopupPage : MonoBehaviour {

	private string[] resource;

	[SerializeField]
	private PageType pageType;

    [SerializeField]
	private OnPopupPageOpen pageToOpen;

	[SerializeField]
	private GameObject parentPage = null;

	public void PopupNewPage(){
		pageToOpen.OnEnter (resource, pageType, parentPage);
	}

	public void SetResource(string[] _resource){
		resource = _resource;
	}

	public void SetPageToOpen(OnPopupPageOpen _pageToOpen){
		pageToOpen = _pageToOpen;
	}

	public void SetParentPage(GameObject _parent){
		parentPage = _parent;
	}
}
