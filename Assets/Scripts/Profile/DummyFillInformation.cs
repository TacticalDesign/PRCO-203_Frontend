using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyFillInformation : MonoBehaviour {

	[SerializeField]
	private Text name;
	[SerializeField]
	private Text skillOne;
	[SerializeField]
	private Text skillTwo;
	[SerializeField]
	private Text skillThree;
	[SerializeField]
	private Text interestOne;
	[SerializeField]
	private Text interestTwo;
	[SerializeField]
	private Text interestThree;
	[SerializeField]
	private Text rewardPoints;
	[SerializeField]
	private Text avgFeedback;

	private string fillInformationID;

	private string[] myInformation;

	[SerializeField]
	private ClickForPopupPage editProfileButton;

	public void FillInformation(){
		myInformation = DummyPullDataFromID.PullPersonalInformation ();


		name.text = myInformation [1];
		skillOne.text = myInformation [2];
		skillTwo.text = myInformation [3];
		skillThree.text = myInformation [4];
		interestOne.text = myInformation [5];
		interestTwo.text = myInformation [6];
		interestThree.text = myInformation [7];

		editProfileButton.SetResource (myInformation);

        int points = 0;
        int.TryParse(myInformation[8], out points);
        StartCoroutine(CountUpPoints(points));
        
        float rating = 0;
        float.TryParse(myInformation[9], out rating);
        StartCoroutine(CountUpRating(rating));
    }

	public void SetInformationID(string _myID){
		fillInformationID = _myID;
    }

    /// <summary>
    /// Counts the value displayed for the users points up to the correct value
    /// from an offset
    /// </summary>
    /// <param name="points">The value to count up to</param>
    /// <returns>IEnumerator</returns>
    private IEnumerator CountUpPoints(int points)
    {
        int startingOffset = 35;

        //Move the offset if the starting point is less than 0
        if (points - startingOffset < 0)
            startingOffset = points;

        //Increment the value over time
        for (int i = startingOffset; i >= 0; i--)
        {
            rewardPoints.text = "Reward Points: " + (points - i);
            float wait = Mathf.Lerp(0.2f, 0.01f, i / (float)startingOffset);
            yield return new WaitForSeconds(wait);
        }
    }

    /// <summary>
    /// Counts the value displayed for the users average rating up to the correct value
    /// from an offset
    /// </summary>
    /// <param name="rating">The value to count up to</param>
    /// <returns>IEnumerator</returns>
    private IEnumerator CountUpRating(float rating)
    {
        float startingOffset = 2;

        //Move the offset if the starting point is less than 0
        if (rating - startingOffset < 0)
            startingOffset = rating;

        //Increment the value over time
        for (float i = startingOffset; i >= 0; i -= 0.1f)
        {
            avgFeedback.text = "Average Rating: " + (rating - i).ToString("F1") + " / 5";
            float wait = Mathf.Lerp(0.1f, 0.01f, i / startingOffset);
            yield return new WaitForSeconds(wait);
        }

        //Set the maximum value to hide any float rounding errors
        avgFeedback.text = "Average Rating: " + rating.ToString("F1") + " / 5";
    }
}
