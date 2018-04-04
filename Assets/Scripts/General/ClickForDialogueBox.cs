using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForDialogueBox : MonoBehaviour {

	[SerializeField]
	private GameObject dialogueBoxPrefab;

	[SerializeField]
	private DialogueType myDialogueType;

	[SerializeField]
	private OnPopupPageOpen onPopupPageOpen;

	private DialogueChoices myDialogue;
	private int responseFlag;

	public void SetupDialogue(){
		myDialogue = Instantiate (dialogueBoxPrefab, GameObject.FindGameObjectWithTag("MainCanvas").transform).GetComponent<DialogueChoices>();
		myDialogue.SetupDialogue (myDialogueType, GetComponent<ClickForDialogueBox>());
		onPopupPageOpen.DisableBackButton ();
		StartCoroutine (WaitForResponse ());
	}

	private IEnumerator WaitForResponse(){
		while (responseFlag == 0) {
			yield return new WaitForSeconds (0.2f);
		}

		if (responseFlag == 1) {
			gameObject.SendMessage ("DialogueAccepted");
		}
		Destroy (myDialogue.gameObject);

		responseFlag = 0;
		onPopupPageOpen.EnableBackButton ();
		yield return null;
	}

	public void FlagResponse(DialogueResponses _response){
		responseFlag = (int)_response;
	}
}
