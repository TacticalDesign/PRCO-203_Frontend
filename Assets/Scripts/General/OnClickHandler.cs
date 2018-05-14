using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnClickHandler : MonoBehaviour, IPointerDownHandler, IPointerClickHandler {

	private ScrollRect parent;

	private ClickForPopupPage toBeTriggered;
	private FillRewardItems toBeTriggeredReward;

	private bool canClick = true;

	void Start(){
		try{
		toBeTriggered = gameObject.GetComponent<ClickForPopupPage> ();
		} catch (UnityException ex){
		}

		try{
			toBeTriggeredReward = gameObject.GetComponent<FillRewardItems>();
		} catch (UnityException ex){
		}
	}

	public void OnPointerDown (PointerEventData ev){
		if (parent.velocity.magnitude > 0) {
			canClick = false;
		}
	}

	public void OnPointerClick (PointerEventData ev){
		if (canClick) {
			if (toBeTriggered != null)
				toBeTriggered.PopupNewPage ();
			else if (toBeTriggeredReward != null)
				toBeTriggeredReward.CanRedeem ();
		}
		canClick = true;
	}

	public void SetParentScrollRect(GameObject _parent){
		parent = _parent.GetComponent<ScrollRect> ();
	}
}
