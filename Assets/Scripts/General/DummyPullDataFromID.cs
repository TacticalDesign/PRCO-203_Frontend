using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class DummyPullDataFromID {


	//////////////////////////////////////////////////////// Challenges //////////////////////////////////////////////






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
		"500",
		"tsmith1234",
		"true"
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
		"250",
		"tsmith1234",
		"true"
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
		"60",
		"alee1234",
		"true"
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
		"150",
		"alee1234",
		"true"
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
		"60",
		"alee1234",
		"true"
	};

	private static string[] challenge6 = new string[] {
		"challenge6",
		"false",
		"false",
		"Tapdancing 101",
		"Musical",
		"Dancing",
		"Energetic",
		"Try out a basic course in tapdancing and give us some feedback, to help make sure our course is set up appropriately.",
		"17/03/2018",
		"12PM till 3PM",
		"Adam Lee, Tap-Dance Extrodinare",
		"1500",
		"alee1234",
		"false"
	};

	private static List<string[]> challenges = new List<string[]>{
		challenge1,
		challenge2,
		challenge3,
		challenge4,
		challenge5,
		challenge6
	};

	private static List<Sprite> challengeImages = new List<Sprite> ();

	private static Sprite testImage;

	public static void SetTestImage(Sprite _newTestImage){
		testImage = _newTestImage;
	}

	public static Sprite GetTestImage(){
		return testImage;
	}

	public static void FillChallengeImagesWithTest(){
		foreach (string[] s in challenges) {
			challengeImages.Add (GetTestImage ());
		}
	}

	private static string[][] returnables = new string[][]{};

	public static void AddChallenge(string[] _newChallengeData, Sprite _challengeImage){
		challenges.Add (_newChallengeData);
		challengeImages.Add (_challengeImage);
	}

	public static string[] PullArrayByID(string challengeID){
		for (int i = 0; i < challenges.Count; i++) {
			if (challenges [i] [0] == challengeID)
				return challenges [i];
		}
		string[] emptyArray = new string[]{};
		return emptyArray;
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
		string[] temp = new string[0];

		foreach (string[] s in challenges) {
			if (s [0] == _resID) {
				temp = s;
			}
		}

		temp [_arrayPos] = _newValue;
	}

	public static string GenerateNewChallengeID(){
		return "challenge" + (challenges.Count + 1).ToString ();
	}

	public static void MarkChallengeAsComplete(string _challengeID){
		foreach (string[] s in challenges) {
			if (s [0] == _challengeID)
				s [2] = "true";
		}
	}




	//////////////////////////////////////////////////////// Personal Information //////////////////////////////////////////////




	private static string[] personalInformation = new string[]{
		"jm12345",
		"Jake Morgan",
		"'Pro-Grammin",
		"Creeaytuve Raitin",
		"Engrish",
		"Vudio Geims",
		"Su'er 'Ero's",
		"Moosick",
		"2500",
		"4"
	};

	private static List<string> acceptedChallenges = new List<string>{
		challenge4[0]
	};

	private static string[][] allUsers = new string[][]{
		personalInformation
	};

	public static string[] PullPersonalInformation(){
		return personalInformation;
	}

	public static string PullPersonalRewardPoints(){
		return personalInformation [8];
	}

	public static void UpdatePersonalInfo(string[] _newInfoArray){
		personalInformation = _newInfoArray;
	}

	public static string[] PullYouthInfoByID(string _ID){
		foreach (string[] s in allUsers) {
			if (s [0] == _ID) {
				return s;
			}
		}
		string[] emptyString = new string[0];
		return emptyString;
	}

	public static void AddToAcceptedChallenges(string _challengeID){
		acceptedChallenges.Add (_challengeID);
	}

	public static void RemoveFromAcceptedChallenges(string _challengeID){
		acceptedChallenges.Remove (_challengeID);
	}

	public static bool HasChallengeBeenAccepted(string _challengeID){
		foreach (string s in acceptedChallenges) {
			if (s == _challengeID)
				return true;
		}
		return false;
	}

	public static string[] GetAcceptedChallenges(){
		return acceptedChallenges.ToArray();
	}


	//////////////////////////////////////////////////////// Rewards //////////////////////////////////////////////




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
		"999999"
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

	public static void RemoveReward(string _rewardID){
		List<string[]> newRewards = new List<string[]>();
		foreach (string[] r in rewards) {
			if (r [0] != _rewardID) {
				newRewards.Add (r);
			} else {
				try{
					int tempPoints = int.Parse (personalInformation [8]);
					int removingPoints = int.Parse(r[3]);
					tempPoints -= removingPoints;
					personalInformation[8] = tempPoints.ToString();
				} catch(UnityException ex){}
			}
		}
		rewards = newRewards.ToArray ();
	}


	//////////////////////////////////////////////////////// Feedback //////////////////////////////////////////////





	private static string[] feedback1 = new string[] {
		"challenge5",
		"jm12345",
		"Hello Jesse my old friend. I've come to review you again. Because the old folk softly creeping, left good reviews while I was sleeping. And the average, of all those voices shared, when prepared, was 4/5.",
		"4",
		"FeedbackGiver",
		"ChallengeName"
	};

	private static List<string[]> allFeedback = new List<string[]>{
		feedback1
	};

	public static void AddFeedback(string[] _newFeedback){
		allFeedback.Add (_newFeedback);

		Debug.Log ("allFeedback");
		foreach(string[] s in allFeedback)
			Debug.Log (s);
	}

	public static string[][] PullFeedback (){
		List<string[]> returnables = new List<string[]> ();

		foreach (string[] f in allFeedback) {
			if (f [1] == personalInformation [0]) {
				f [4] = PullArrayByID (f [0]) [10];
				f [5] = PullArrayByID (f [0]) [3];
				returnables.Add (f);
			}
		}

		Debug.Log ("allFeedback");
		foreach(string[] s in allFeedback)
			Debug.Log (s);

		Debug.Log ("returnables");
		foreach(string[] s in returnables)
			Debug.Log (s);

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


	//////////////////////////////////////////////////////// Challenger //////////////////////////////////////////////






	private static string challengerID = "";

	private static string[] challenger1 = new string[] {
		"alee1234",
		"Adam Lee",
		"alee@test.com",
		"01245789104",
		"For the last time, I don't give A Dam, Lee."
	};

	private static string[] challenger2 = new string[] {
		"tsmith1234",
		"Toby Smith",
		"tsmythe@test.com",
		"07177171771",
		"To By a Smith, or not To By a Smith, that is the question."
	};

	private static string[][] challengers = new string[][]{
		challenger1,
		challenger2
	};

	public static void SetChallengerID(string _ID){
		challengerID = _ID;
	}

	public static string[][] GetChallengerUpcoming(){
		List<string[]> returnList = new List<string[]> ();

		foreach (string[] challenge in challenges) {
			if (challenge [12] == challengerID && challenge[2] == "false") {
				returnList.Add (challenge);
			}
		}

		return returnList.ToArray ();
	}

	public static string[][] GetChallengerCompleted(){
		List<string[]> returnList = new List<string[]> ();

		foreach (string[] challenge in challenges) {
			if (challenge [12] == challengerID && challenge[2] == "true") {
				returnList.Add (challenge);
			}
		}

		return returnList.ToArray ();
	}

	public static string[] PullMyChallengerInfo(){
		foreach (string[] s in challengers) {
			if (s [0] == challengerID)
				return s;
		}
		return new string[0];
	}

	public static string[] PullChallengerInfoByString(string _ID){
		foreach (string[] s in challengers) {
			if (s [0] == _ID)
				return s;
		}
		return new string[0];
	}

	public static void UpdateChallengerInfo(string _ID, string[] _newDataArray){
		for (int i = 0; i < challengers.Length; i++) {
			if (challengers [i] [0] == _ID) {
				challengers [i] = _newDataArray;
			}
		}
	}

	public static void UpdateChallengeInfo(string[] _newData){
		for (int i = 0; i < challenges.Count; i++) {
			if (challenges [i] [0] == _newData [0]) {
				challenges [i] = _newData;
				foreach (string s in challenges[i]) {
					Debug.Log (s);
				}
				return;
			}
		}
	}


	//////////////////////////////////////////////////////// Active Account Type //////////////////////////////////////////////






	private static AccountType activeAccount;

	public static void SetActiveAccountType(AccountType _active){
		activeAccount = _active;
	}

	public static AccountType GetActiveAccountType(){
		return activeAccount;
	}
}
