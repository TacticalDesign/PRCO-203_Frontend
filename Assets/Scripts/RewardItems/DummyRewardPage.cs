using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyRewardPage : MonoBehaviour {

	[SerializeField]
	private Text rewardPoints;

	public void UpdatePoints(){
		rewardPoints.text = "Reward points: " + DummyPullDataFromID.PullPersonalRewardPoints ();
	}
}
