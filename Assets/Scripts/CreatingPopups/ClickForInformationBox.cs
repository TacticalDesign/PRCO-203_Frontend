using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForInformationBox : MonoBehaviour {

	[SerializeField]
	private GameObject informationBoxPrefab;

	[SerializeField]
	private InformationBoxType myInfoType;

	private InformationBox myInfoBox;
	private int responseFlag;

	public void SetupInfo(){
		myInfoBox = Instantiate (informationBoxPrefab, GameObject.FindGameObjectWithTag("MainCanvas").transform).GetComponent<InformationBox>();
		myInfoBox.SetupInformationBox (myInfoType, GetComponent<ClickForInformationBox>());
		StartCoroutine (WaitForResponse ());
	}

	private IEnumerator WaitForResponse(){
		while (responseFlag == 0) {
			yield return new WaitForSeconds (0.2f);
		}

		Destroy (myInfoBox.gameObject);
		responseFlag = 0;
		yield return null;
	}

	public void FlagResponse(DialogueResponses _response){
		responseFlag = (int)_response;
	}
}
