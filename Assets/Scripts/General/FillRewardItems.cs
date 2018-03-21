using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillRewardItems : MonoBehaviour {

	[SerializeField]
	private Text rewardTitle;
	[SerializeField]
	private Text rewardDescription;
	[SerializeField]
	private Text rewardPoints;

	private string rewardID;

	public void FillItems(string[] _rewardData){
		rewardID = _rewardData [0];
		rewardTitle.text = _rewardData [1];
		rewardDescription.text = _rewardData [2];
		rewardPoints.text = _rewardData [3];
	}
}
