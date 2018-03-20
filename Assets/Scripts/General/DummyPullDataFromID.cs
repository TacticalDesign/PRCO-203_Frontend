using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DummyPullDataFromID {

	private static string[] challenge1 = new string[] {
		"challenge1",
		"false",
		"false",
		"Devon Life Article (500 points)",
		"Photography",
		"Informative Writing",
		"Good Spelling",
		"Write an article for the Devon Life magazine detailing some beatuiful parks, lakes, or other natural areas, for people to visit and relax.",
		"25/05/2018",
		"Friday 1st June 2018",
		"DevonLife Magazine"
	};

	private static string[] challenge2 = new string[] {
		"challenge2",
		"false",
		"false",
		"Co-op Flower Fayre (250 Points)",
		"Flower Arranging",
		"Photography",
		"Energetic",
		"We're looking for individuals who can help out with the Torbay Flower Fayre. This includes helping set up the arrangements, guiding people around the Fayre and taking pictures for our Co-op Magazine.",
		"02/04/2018",
		"12.30 PM till 4.30 PM",
		"The Co-operative Group"
	};

	private static string[] challenge3 = new string[] {
		"challenge3",
		"false",
		"false",
		"Entertaining the Elderly (60 Points)",
		"Musical",
		"Dancing",
		"Energetic",
		"Help us put on a show for the residents of Torbay Residential! We're looking for a small band to play at our monthly FunFest and help bring a smile to our residents faces.",
		"15/04/2018",
		"4PM till 6PM",
		"Mr. Jones, Torbay Residential"
	};

	private static string[] challenge4 = new string[] {
		"challenge4",
		"true",
		"false",
		"Video game Competition (100 Points)",
		"Artistic",
		"Knowledge of Games",
		"Inventive",
		"We're putting on a small Games Convention and are looking for people to help design the banners and flyers we will be posting.",
		"22/03/2018",
		"24/03/2018",
		"Bob Weeve, Manager at Game Workshop, Torbay"
	};

	private static string[] challenge5 = new string[] {
		"challenge5",
		"true",
		"true",
		"Entertaining the Elderly (60 Points)",
		"Musical",
		"Dancing",
		"Energetic",
		"Help us put on a show for the residents of Torbay Residential! We're looking for a small band to play at our monthly FunFest and help bring a smile to our residents faces.",
		"17/03/2018",
		"4PM till 6PM",
		"Mr. Jones, Torbay Residential"
	};

	private static string[][] challenges = new string[][]{
		challenge1,
		challenge2,
		challenge3,
		challenge4,
		challenge5
	};

	private static string[][] returnables = new string[][]{};


	public static string[] PullArrayByID(string challengeID){
		for (int i = 0; i < challenges.Length; i++) {
			if (challenges [i] [0] == challengeID)
				return challenges [i];
		}
		string[] bob = new string[]{};
		return bob;
	}

	public static string[][] PullFeedChallenges(){
		List<string[]> tempReturn = new List<string[]> ();

		foreach (string[] c in challenges) {
			if (c [1] == "false" && c [2] == "false") {
				tempReturn.Add (c);
			}
		}

		returnables = new string[tempReturn.Count][];

		for (int i = 0; i < tempReturn.Count; i++) {
			returnables [i] = tempReturn [i];
		}

		return returnables;
	}

	public static string[][] PullCompleted(){
		List<string[]> tempReturn = new List<string[]> ();

		foreach (string[] c in challenges) {
			if (c [2] == "true") {
				tempReturn.Add (c);
			}
		}

		returnables = new string[tempReturn.Count][];

		for (int i = 0; i < tempReturn.Count; i++) {
			returnables [i] = tempReturn [i];
		}

		return returnables;
	}

	public static string[][] PullUpcoming(){
		List<string[]> tempReturn = new List<string[]> ();

		foreach (string[] c in challenges) {
			if (c [1] == "true" && c [2] == "false") {
				tempReturn.Add (c);
			}
		}

		returnables = new string[tempReturn.Count][];

		for (int i = 0; i < tempReturn.Count; i++) {
			returnables [i] = tempReturn [i];
		}

		return returnables;
	}

	public static void UpdateData(string _resID, int _arrayPos, string _newValue){
		string[] temp = new string[11];

		foreach (string[] s in challenges) {
			if (s [0] == _resID) {
				temp = s;
			}
		}

		temp [_arrayPos] = _newValue;
	}
}
