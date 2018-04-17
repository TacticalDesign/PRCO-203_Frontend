using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SearchTerms : MonoBehaviour {

	[SerializeField]
	private GameObject contentHolder;

	[SerializeField]
	private Text searchBoxText;

	private List<GameObject> hiddenObjects = new List<GameObject>();
	private List<string[]> hiddenObjectData = new List<string[]>();

	public void FilterData(){
		Invoke ("DelayFilter", 0.2f);
	}

	public void FilterRewards(){
		Invoke ("DelayRewards", 0.2f);
	}

	private void DelayFilter(){
		FillFeedItems[] hideFeed = contentHolder.GetComponentsInChildren<FillFeedItems> ();

		string temp = searchBoxText.text;

		Debug.Log (temp);

		if (temp == "" || temp == null) {
			if (hiddenObjects.Count () > 0) {
				foreach (GameObject g in hiddenObjects) {
					g.gameObject.SetActive (true);
				}
				hiddenObjects.Clear ();
				hiddenObjectData.Clear ();
			}
			return;
		}

		hideFeed = hideFeed.Where (data => 
			!data.GetSearchData() [0].ToLower().Contains (temp.ToLower()) &&
			!data.GetSearchData() [1].ToLower().Contains (temp.ToLower()) &&
			!data.GetSearchData() [2].ToLower().Contains (temp.ToLower()) &&
			!data.GetSearchData() [3].ToLower().Contains (temp.ToLower())
		).ToArray();

		List<GameObject> displayList = new List<GameObject> ();
		List<string[]> toRemove = new List<string[]> ();

		for (int i = 0; i < hiddenObjectData.Count (); i++) {
			if (hiddenObjectData.ElementAt (i) [0].ToLower().Contains (temp.ToLower ()) ||
				hiddenObjectData.ElementAt (i) [1].ToLower().Contains (temp.ToLower ()) ||
				hiddenObjectData.ElementAt (i) [2].ToLower().Contains (temp.ToLower ()) ||
				hiddenObjectData.ElementAt (i) [3].ToLower().Contains (temp.ToLower ())
			){
				displayList.Add (hiddenObjects [i]);
				toRemove.Add(hiddenObjectData.ElementAt(i));
			}
		}

		GameObject[] displayFeed = displayList.ToArray();

		foreach (FillFeedItems f in hideFeed) {
			hiddenObjects.Add (f.gameObject);
			hiddenObjectData.Add (f.GetSearchData ());
			f.gameObject.SetActive (false);
		}

		foreach (GameObject g in displayFeed) {
			g.gameObject.SetActive (true);
			hiddenObjects.Remove(g);
		}

		foreach (string[] s in toRemove) {
			hiddenObjectData.Remove (s);
		}
	}

	private void DelayRewards(){
		FillRewardItems[] hideFeed = contentHolder.GetComponentsInChildren<FillRewardItems> ();

		string temp = searchBoxText.text;

		Debug.Log (temp);

		if (temp == "" || temp == null) {
			if (hiddenObjects.Count () > 0) {
				foreach (GameObject g in hiddenObjects) {
					g.gameObject.SetActive (true);
				}
				hiddenObjects.Clear ();
				hiddenObjectData.Clear ();
			}
			return;
		}

		hideFeed = hideFeed.Where (data => 
			!data.GetSearchData() [0].ToLower().Contains (temp.ToLower()) &&
			!data.GetSearchData() [1].ToLower().Contains (temp.ToLower()) &&
			!data.GetSearchData() [2].ToLower().Contains (temp.ToLower())
		).ToArray();

		List<GameObject> displayList = new List<GameObject> ();
		List<string[]> toRemove = new List<string[]> ();

		for (int i = 0; i < hiddenObjectData.Count (); i++) {
			if (hiddenObjectData.ElementAt (i) [0].ToLower().Contains (temp.ToLower ()) ||
				hiddenObjectData.ElementAt (i) [1].ToLower().Contains (temp.ToLower ()) ||
				hiddenObjectData.ElementAt (i) [2].ToLower().Contains (temp.ToLower ())
			){
				displayList.Add (hiddenObjects [i]);
				toRemove.Add(hiddenObjectData.ElementAt(i));
			}
		}

		GameObject[] displayFeed = displayList.ToArray();

		foreach (FillRewardItems f in hideFeed) {
			hiddenObjects.Add (f.gameObject);
			hiddenObjectData.Add (f.GetSearchData ());
			f.gameObject.SetActive (false);
		}

		foreach (GameObject g in displayFeed) {
			g.gameObject.SetActive (true);
			hiddenObjects.Remove(g);
		}

		foreach (string[] s in toRemove) {
			hiddenObjectData.Remove (s);
		}
	}
}
