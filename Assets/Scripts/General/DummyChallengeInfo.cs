using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyChallengeInfo : MonoBehaviour {
	public void FillData(string[] _resource){
		foreach (string s in _resource) {
			Debug.Log (s);
		}
	}
}
