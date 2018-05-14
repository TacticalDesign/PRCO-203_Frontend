using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyRewardPage : MonoBehaviour {

	[SerializeField]
	private Text rewardPoints;

	public void UpdatePoints(){

        int points = 0;
        int.TryParse(DummyPullDataFromID.PullPersonalRewardPoints(), out points);
        StartCoroutine(CountUp(points));
    }

    /// <summary>
    /// Counts the value displayed for the users points up to the correct value
    /// from an offset
    /// </summary>
    /// <param name="points">The value to count up to</param>
    /// <returns>IEnumerator</returns>
    private IEnumerator CountUp(int points)
    {
        int startingOffset = 35;

        //Move the offset if the starting point is less than 0
        if (points - startingOffset < 0)
            startingOffset = points;

        //Increment the value over time
        for (int i = startingOffset; i >= 0; i--)
        {
            rewardPoints.text = "Reward Points: " + (points - i);
            float wait = Mathf.Lerp(0.2f, 0.01f, i / (float) startingOffset);
            yield return new WaitForSeconds(wait);
        }
    }
}
