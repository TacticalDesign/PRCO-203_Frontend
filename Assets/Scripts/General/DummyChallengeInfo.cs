using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyChallengeInfo : MonoBehaviour {
	public void FillData(string _resourceID){
		string[] dataPulled = DummyPullDataFromID.PullArrayByID (_resourceID);
		foreach (string s in dataPulled) {
			Debug.Log (s);
		}
	}
}
