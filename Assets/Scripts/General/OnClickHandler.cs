using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnClickHandler : MonoBehaviour, IPointerDownHandler, IPointerClickHandler {

	private ScrollRect parent;

	private ClickForPopupPage toBeTriggered;
	private bool canClick = true;

	void Start(){
		toBeTriggered = gameObject.GetComponent<ClickForPopupPage> ();
	}

	public void OnPointerDown (PointerEventData ev){
		if (parent.velocity.magnitude > 0) {
			canClick = false;
		}
	}

	public void OnPointerClick (PointerEventData ev){
		if (canClick) {
			toBeTriggered.PopupNewPage ();
		}
		canClick = true;
	}

	public void SetParentScrollRect(GameObject _parent){
		parent = _parent.GetComponent<ScrollRect> ();
	}
}
