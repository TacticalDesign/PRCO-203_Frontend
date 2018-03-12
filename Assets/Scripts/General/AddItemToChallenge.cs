using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemToChallenge : MonoBehaviour {

	[SerializeField]
	GameObject challengePrefab;

	[SerializeField]
	GameObject contentContainer;


	public void addChallengeItem(){
		Instantiate (challengePrefab, contentContainer.transform);
	}

}
