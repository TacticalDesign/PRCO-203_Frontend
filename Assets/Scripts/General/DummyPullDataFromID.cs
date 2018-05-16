using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class DummyPullDataFromID {


	//////////////////////////////////////////////////////// Challenges //////////////////////////////////////////////






	/*

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

*/

	private static string[] challenge1 = new string[] {
		"challenge1",
		"false",
		"false",
		"Produce An Event",
		"Organising",
		"Art",
		"Performing",
		"We're putting on an event for creative young people. Help us do it!",
		"Friday 7th September 2018",
		"All Day",
		"Ash, Annoshka & Lucas from Dead Pencils",
		"500",
		"thedeadpencils",
		"true"
	};

	private static string[] challenge2 = new string[] {
		"challenge2",
		"false",
		"false",
		"Big Music Festival",
		"Phototgraphy",
		"Writing",
		"Video",
		"We're looking for vloggers, writers and photographers for a massive festival in Plymouth.",
		"Friday 20th July 2018",
		"All Day",
		"Jenny Bishop; Marketing Manager at RIO",
		"1200",
		"rio",
		"true"
	};

	private static string[] challenge3 = new string[] {
		"challenge3",
		"false",
		"false",
		"Content For Magazine",
		"Photoshop",
		"Illustrations",
		"Video",
		"We want people to create cool content for our magazine.",
		"Every Month",
		"Repeats Monthly",
		"Lisa Gardner, Director at Wonder Associates",
		"1000",
		"wonderassociates",
		"true"
	};

	private static string[] challenge4 = new string[] {
		"challenge4",
		"false",
		"false",
		"Help Other Young People",
		"Coaching",
		"Artistic",
		"Friendly",
		"Can you help young people complete their Arts Award Cirtificate?.",
		"Every Month",
		"Repeats Monthly",
		"Carmen de Silva; Play Torbay",
		"800",
		"carmendesilva",
		"true"
	};

	private static List<string[]> challenges = new List<string[]>{
		challenge1,
		challenge2,
		challenge3,
		challenge4
	};

	private static List<Sprite> challengeImages = new List<Sprite> ();

	public static void AddNewChallengeImage(Sprite _newSprite){
		challengeImages.Add (_newSprite);
	}

	public static void SetChallengeImage(Sprite _newSprite, string _challengeID){
		for (int s = 0; s < challenges.Count; s++) {
			if (challenges [s] [0] == _challengeID) {
				if (challengeImages.Count - 1 >= s){
					challengeImages [s] = _newSprite;
				}
				else
					challengeImages.Add(_newSprite);
			}
		}
	}

	public static Sprite GetChallengeImage(string _challengeID){
		for (int s = 0; s < challenges.Count; s++) {
			if (challenges [s] [0] == _challengeID) {
				return challengeImages [s];
			}
		}
		return GetTestImage ();
	}

	private static Sprite testImage;

	public static void SetTestImage(Sprite _newTestImage){
		testImage = _newTestImage;
	}

	public static Sprite GetTestImage(){
		return testImage;
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
		"Programming",
		"Creative Writing",
		"Photography",
		"Video Games",
		"Music",
		"Computer Hardware",
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
		"artsSilver",
		"Silver Arts Award",
		"Counts as a GCSE! Only 1 of these awards redeemable per account.",
		"6000"
	};

	private static string[] reward2 = new string[] {
		"artsGold",
		"Gold Arts Award",
		"The same as an A-Level. Adds to your UCAS points! Only 1 of these awards redeemable per account.",
		"15000"
	};

	private static string[] reward3 = new string[] {
		"edenProjectFamily",
		"Eden Project Tickets",
		"Free Family Pass to the Eden Project. Have a nice family day out, and learn more about Eden.",
		"1200"
	};

	private static string[] reward4 = new string[] {
		"oceanCityBastille",
		"Bastille Tickets",
		"Free tickets to see Bastille in Plymouth! What are you waiting for!?",
		"2100"
	};

	private static string[] reward5 = new string[] {
		"rioQualification",
		"Business Qualification",
		"Qualification for Social Enterprise. Show the world the skills you've learnt with us!",
		"15000"
	};


	private static string[] reward6 = new string[] {
		"wonderGraphicClass",
		"Free Graphics Design Class",
		"Become a pro with training from Wonder's world-class designers!",
		"1250"
	};

	private static string[] reward7 = new string[] {
		"parkour3x1H",
		"Free Parkour Sessions",
		"Learn Freerunning with 3x 1 Hour Parkour sessions. Make the city yours!",
		"750"
	};

	private static string[][] rewards = new string[][]{
		reward1,
		reward2,
		reward3,
		reward4,
		reward5,
		reward6,
		reward7
	};

	private static List<Sprite> rewardImages = new List<Sprite> ();

	public static void AddNewRewardImage(Sprite _newSprite){
		rewardImages.Add (_newSprite);
	}

	public static void SetRewardImage(Sprite _newSprite, string _rewardID){
		for (int s = 0; s < rewards.Length; s++) {
			if (rewards [s] [0] == _rewardID) {
				if (rewardImages.Count - 1 >= s){
					rewardImages [s] = _newSprite;
				}
				else
					rewardImages.Add(_newSprite);
			}
		}
	}

	public static Sprite GetRewardImage(string _rewardsID){
		for (int s = 0; s < rewards.Length; s++) {
			if (rewards [s] [0] == _rewardsID) {
				return rewardImages [s];
			}
		}
		return GetTestImage ();
	}

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





	/*private static string[] feedback1 = new string[] {
		"challenge5",
		"jm12345",
		"Hello Jesse my old friend. I've come to review you again. Because the old folk softly creeping, left good reviews while I was sleeping. And the average, of all those voices shared, when prepared, was 4/5.",
		"4",
		"FeedbackGiver",
		"ChallengeName"
	};*/

	private static List<string[]> allFeedback = new List<string[]>{
		//feedback1
	};

	public static void AddFeedback(string[] _newFeedback){
		allFeedback.Add (_newFeedback);
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
		"thedeadpencils",
		"The Dead Pencils",
		"deadpencils@rio.org",
		"01245789104",
		"Do YOU have what it takes to take on the challenge of RUNNING \"Dead Pencils\"?\n" +
		"If You think you're up for it, whatch out for challenges from our group.\n" + 
		"If you kick butt on our challenges - you can be part of the Dead Pencils Managers."
	};

	private static string[] challenger2 = new string[] {
		"rio",
		"RIO - Real Ideas Organisation",
		"contact@rio.org",
		"012356473736",
		"RIO wants to make the world a much better place through Social Enterprise.\n" +
		"We believe that young people can change the world!\n" + 
		"Do you think you could run your own projects and even start your own business?\n" +
		"If you want to help us make a huge impact - watch this space!"
	};

	private static string[] challenger3 = new string[] {
		"katefarmery",
		"Kate Farmery",
		"Kate@Farmery.me",
		"07177171771",
		"Kate is the person in charge of Arts and Culture for the whole of Torbay!\n" +
		"If an opportunity with Torbay Culture ever comes up - it's a really big deal."
	};

	private static string[] challenger4 = new string[] {
		"theshorelymagazine",
		"The Shorely Magazine",
		"contactus@shorely.com",
		"0121565783",
		"The Shorely Magazine is Torbay's own insiders guide to cool creative events in Torbay.\n" +
		"If you like gigs, performances and art in general, you need to be involved!\n" +
		"The Shorely has loads of challenges for you to create vlogs, take photos, write articles, or review shows."
	};

	private static string[] challenger5 = new string[] {
		"jacobbrandon",
		"Jacob Brandon",
		"jacob@artizangallery.co.uk",
		"0783546374",
		"Jacob is a young person - but he already runs his own art gallery!\n" +
		"He's got lots of projects coming up to help create a space for young artists in Torbay."
	};

	private static string[] challenger6 = new string[] {
		"carmendesilva",
		"Carmen De Silva",
		"carmen@playtorbay.org",
		"0783374836",
		"Carmen is Comms and Liason Officer at Play Torbay.\n" +
		"Play Torbay runs the Play Parks at Fort Appache (Torquay), Indigos Go Wild (Brixham) and Wild Foxes (Paignton).\n" +
		"She Knows loads about marketing and loads of people around Torbay.\n" +
		"Carmen is always looking out for opportunities for young people to shine."
	};

	private static string[] challenger7 = new string[] {
		"wonderassociates",
		"Wonder Associates",
		"Lisa.Gardiner@wonderassociates.com",
		"0783736908",
		"Wonder is one of the coolest creative companies in the whole of Torbay!\n" +
		"They've done amazing work for some of the biggest brands in the world, like Reebok!\n" +
		"If you're into graphic design, branding, fashion, photography, or Film - Contact Lisa!"
	};

	private static string[][] challengers = new string[][]{
		challenger1,
		challenger2,
		challenger3,
		challenger4,
		challenger5,
		challenger6,
		challenger7
	};

	private static List<Sprite> challengerProfileImages = new List<Sprite> ();

	public static void AddNewChallengerProfileImage(Sprite _newSprite){
		challengerProfileImages.Add (_newSprite);
	}

	public static void SetChallengerProfileImage(Sprite _newSprite, string _challengerID){
		for (int s = 0; s < challengers.Length; s++) {
			if (challengers [s] [0] == _challengerID) {
				if (challengerProfileImages.Count - 1 >= s){
					challengerProfileImages [s] = _newSprite;
				}
				else
					challengerProfileImages.Add(_newSprite);
			}
		}
	}

	public static Sprite GetChallengerProfileImage(string _challengerID){
		for (int s = 0; s < challengers.Length; s++) {
			if (challengers [s] [0] == _challengerID) {
				return challengerProfileImages [s];
			}
		}
		return GetTestImage ();
	}

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
