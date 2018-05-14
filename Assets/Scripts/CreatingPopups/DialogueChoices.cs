using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChoices : MonoBehaviour {

    [SerializeField]
    private Text dialogueDesc;
    [SerializeField]
    private Text acceptText;
    [SerializeField]
    private Text cancelText;

    private ClickForDialogueBox parent;

    [SerializeField]
    private AudioSource acceptSound;
    [SerializeField]
    private AudioSource declineSound;

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ClickCancel ();
		}
	}

	public void SetupDialogue(DialogueType _fillType, ClickForDialogueBox _parent){
		parent = _parent;

		switch (_fillType) {
		case DialogueType.ACCEPT_CHALLENGE:
			dialogueDesc.text = "Are you sure you want to accept this challenge?";
			acceptText.text = "Bring it!";
			cancelText.text = "On second thoughts...";
			break;
		case DialogueType.OPT_OUT:
			dialogueDesc.text = "Are you really giving up on this challenge?";
			acceptText.text = "Count me out";
			cancelText.text = "No, I can do this!";
			break;
		case DialogueType.ACCEPT_REWARD:
			dialogueDesc.text = "Is this the reward you want?";
			acceptText.text = "Definately";
			cancelText.text = "Not really...";
			break;
		}
	}

	public void ClickAccept(){
		parent.FlagResponse (DialogueResponses.ACCEPT);
        AudioManager.GetAudioSource(SoundType.ACCEPT);

	}

	public void ClickCancel(){
		parent.FlagResponse (DialogueResponses.CANCEL);
        AudioManager.GetAudioSource(SoundType.DECLINE);
    }
}
