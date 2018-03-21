using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DummyPullDataFromID {

	private static string[] challenge1 = new string[] {
		"challenge1",
		"false",
		"false",
		"Devon Life Article",
		"Photography",
		"Informative Writing",
		"Good Spelling",
		"Write an article for the Devon Life magazine detailing some beatuiful parks, lakes, or other natural areas, for people to visit and relax.",
		"25/05/2018",
		"Friday 1st June 2018",
		"DevonLife Magazine",
		"500"
	};

	private static string[] challenge2 = new string[] {
		"challenge2",
		"false",
		"false",
		"Co-op Flower Fayre",
		"Flower Arranging",
		"Photography",
		"Energetic",
		"We're looking for individuals who can help out with the Torbay Flower Fayre. This includes helping set up the arrangements, guiding people around the Fayre and taking pictures for our Co-op Magazine.",
		"02/04/2018",
		"12.30 PM till 4.30 PM",
		"The Co-operative Group",
		"250"
	};

	private static string[] challenge3 = new string[] {
		"challenge3",
		"false",
		"false",
		"Entertaining the Elderly",
		"Musical",
		"Dancing",
		"Energetic",
		"Help us put on a show for the residents of Torbay Residential! We're looking for a small band to play at our monthly FunFest and help bring a smile to our residents faces.",
		"15/04/2018",
		"4PM till 6PM",
		"Mr. Jones, Torbay Residential",
		"60"
	};

	private static string[] challenge4 = new string[] {
		"challenge4",
		"true",
		"false",
		"Video game Competition",
		"Artistic",
		"Knowledge of Games",
		"Inventive",
		"We're putting on a small Games Convention and are looking for people to help design the banners and flyers we will be posting.",
		"22/03/2018",
		"24/03/2018",
		"Bob Weeve, Manager at Game Workshop, Torbay",
		"150"
	};

	private static string[] challenge5 = new string[] {
		"challenge5",
		"true",
		"true",
		"Entertaining the Elderly",
		"Musical",
		"Dancing",
		"Energetic",
		"Help us put on a show for the residents of Torbay Residential! We're looking for a small band to play at our monthly FunFest and help bring a smile to our residents faces.",
		"17/03/2018",
		"4PM till 6PM",
		"Mr. Jones, Torbay Residential",
		"60"
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

	private static string[] personalInformation = new string[]{
		"jm12345",
		"Jesse McDonald",
		"Artistic",
		"Musical",
		"Creative",
		"Football",
		"Rugby",
		"Video Games",
		"650",
		"4.2"
	};

	public static string[] PullPersonalInformation(){
		return personalInformation;
	}

	public static string PullPersonalRewardPoints(){
		return personalInformation [7];
	}

	public static void UpdatePersonalInfo(string[] _newInfoArray){
		personalInformation = _newInfoArray;
	}

	private static string[] reward1 = new string[] {
		"amazon10",
		"£10 Amazon Voucher",
		"Redeemable at any valid Amazon outlet",
		"1000"
	};

	private static string[] reward2 = new string[] {
		"amazon20",
		"£20 Amazon Voucher",
		"Redeemable at any valid Amazon outlet",
		"1800"
	};

	private static string[] reward3 = new string[] {
		"game10",
		"£10 Game.co.uk Voucher",
		"Redeemable in Game.co.uk stores or on the website",
		"1000"
	};

	private static string[] reward4 = new string[] {
		"tesco50off",
		"50% Off at Tescos",
		"50% off your next £30 shop, only valid in-store",
		"1200"
	};

	private static string[] reward5 = new string[] {
		"audible1",
		"Free Audible E-Book",
		"Claim any book in our vast library for free",
		"800"
	};

	private static string[] reward6 = new string[] {
		"ph1",
		"PrawnHub Premium Membership",
		"Premium access to our site for 30 days, no ads, no limits",
		"999,999"
	};

	private static string[][] rewards = new string[][]{
		reward1,
		reward2,
		reward3,
		reward4,
		reward5,
		reward6
	};

	public static string[][] PullRewards (){
		return rewards;
	}

	private static string[] feedback1 = new string[] {
		"challenge5",
		"jm12345",
		"Hello Jesse my old friend. I've come to review you again. Because the old folk softly creeping, left good reviews while I was sleeping. And the average, of all those voices shared, when prepared, was 4/5.",
		"4",
		"FeedbackGiver",
		"ChallengeName"
	};

	private static string[][] allFeedback = new string[][]{
		feedback1
	};

	public static string[][] PullFeedback (){
		List<string[]> returnables = new List<string[]> ();

		foreach (string[] f in allFeedback) {
			if (f [1] == personalInformation [0]) {
				f [4] = PullArrayByID (f [0]) [10];
				f [5] = PullArrayByID (f [0]) [3];
				returnables.Add (f);
			}
		}

		return returnables.ToArray();
	}

	public static string[] PullFeedbackByChallenge(string _challengeID){
		foreach (string[] f in allFeedback) {
			if (f [0] == _challengeID) {
				if (f [1] == personalInformation [0]) {
					f [4] = PullArrayByID (f [0]) [10];
					f [5] = PullArrayByID (f [0]) [3];
					return f;
				}
			}
		}
		string[] emptyArray = new string[]{ };
		return emptyArray;
	}
}
