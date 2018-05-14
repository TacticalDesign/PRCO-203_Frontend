using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySetImages : MonoBehaviour {

	[Header ("Challenges")]
	[SerializeField]
	private Sprite[] challengeImages;

	[SerializeField]
	private string[] IDsForChallengeImages;


	[Header ("Challenger Profiles")]
	[SerializeField]
	private Sprite[] challengerProfileImages;

	[SerializeField]
	private string[] IDsForChallengerProfileImages;


	[Header ("Rewards")]
	[SerializeField]
	private Sprite[] rewardImages;

	[SerializeField]
	private string[] IDsForRewardImages;

	void Start(){
		for (int s = 0; s < challengeImages.Length; s++) {
			DummyPullDataFromID.SetChallengeImage (challengeImages [s], IDsForChallengeImages [s]);
		}

		for (int s = 0; s < challengerProfileImages.Length; s++) {
			DummyPullDataFromID.SetChallengerProfileImage (challengerProfileImages [s], IDsForChallengerProfileImages [s]);
		}

		for (int s = 0; s < rewardImages.Length; s++) {
			Debug.Log (s);
			DummyPullDataFromID.SetRewardImage (rewardImages [s], IDsForRewardImages [s]);
		}
	}
}
