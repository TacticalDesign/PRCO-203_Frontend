using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupChallengeTestImages : MonoBehaviour {

	[SerializeField]
	private Sprite testImage;

	void Start () {
		DummyPullDataFromID.SetTestImage (testImage);
		DummyPullDataFromID.FillChallengeImagesWithTest ();
	}
}
