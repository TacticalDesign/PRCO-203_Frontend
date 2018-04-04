using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayNewFeed : MonoBehaviour {

	[SerializeField]
	private GeneratorType newFeedType;

	[SerializeField]
	private CreateFeedItemsFromArray feedMaker;

	public void SetNewFeed(){
		feedMaker.ChangeFeedDisplay (newFeedType);
	}
}
