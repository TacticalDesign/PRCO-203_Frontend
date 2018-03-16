using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class MainCanvas : MonoBehaviour
{
    [Header("Youth Accounts")]
    [SerializeField]
    GameObject youthNavbar;
    [SerializeField]
    RectTransform[] youthMainPanels;


    [Header("Challenger Accounts")]
    [SerializeField]
    GameObject challengerNavbar;
    [SerializeField]
    RectTransform[] challengerMainPanels;

    [Header("Admin Accounts")]
    [SerializeField]
    GameObject adminNavbar;

    [SerializeField]
    RectTransform[] adminMainPanels;

    [Header("Shared Pages")]
    [SerializeField]
    Animator[] secondryPages;

    [Header("Other Settings")]

    [SerializeField]
    Text title;

    [SerializeField]
    GameObject loginScreen;

    [SerializeField]
    float transitionSmoothness = 0.05f;

    [SerializeField]
    float transitionDuration = 0.3f;

    [SerializeField]
    float secondryPageHidingInterval;

    private void Start()
    {
        loginScreen.SetActive(true);
    }

    /// <summary>
    /// Sends the app to the login screen
    /// </summary>
    public void LoginScreen()
    {
        throw new Exception("Not developed yet!");
    }
    
    /// <summary>
    /// Sets the title label on the title bar
    /// </summary>
    /// <param name="newTitle">The new title to show</param>
    public void SetTitle(string newTitle)
    {
        title.text = newTitle;
    }

    /// <summary>
    /// Sets up the app where it differs between the different account types
    /// </summary>
    /// <param name="type">The type of account to set the app up for</param>
    public void SetAccountType(AccountType type)
    {
        for (int i = 0; i < youthMainPanels.Length; i++)
            youthMainPanels[i].gameObject.SetActive(type == AccountType.Youth);

        for (int i = 0; i < challengerMainPanels.Length; i++)
            challengerMainPanels[i].gameObject.SetActive(type == AccountType.Challenger);

        for (int i = 0; i < adminMainPanels.Length; i++)
            adminMainPanels[i].gameObject.SetActive(type == AccountType.Admin);
        
        youthNavbar.SetActive(type == AccountType.Youth);
        challengerNavbar.SetActive(type == AccountType.Challenger);
        adminNavbar.SetActive(type == AccountType.Admin);
    }

    /// <summary>
    /// Switches the currently showing panel
    /// This is called from NavbarItems
    /// </summary>
    /// <param name="accountType">The type of account being used</param>
    /// <param name="panel">The panel integer to switch to</param>
    /// <param name="titleMessage">The new content of the title after the switch</param>
    /// <returns></returns>
    public IEnumerator ShowPanel(AccountType accountType, int panel, string titleMessage)
    {
        //Find which panels to move based off of the account type
        RectTransform[] panels = new RectTransform[0];
        switch (accountType)
        {
            case AccountType.Youth:
                panels = youthMainPanels;
                break;
            case AccountType.Challenger:
                panels = challengerMainPanels;
                break;
            case AccountType.Admin:
                panels = adminMainPanels;
                break;
        }

        //Find which panel is currently showing by finding the one with an anchorMin.x of 0
        int startingPoition = -1;
        for (int i = 0; i < panels.Length; i++)
        {
            if (panels[i].anchorMin.x == 0f)
                startingPoition = i;
        }

        //If one wasn't found then throw an exception
        if (startingPoition == -1)
            throw new Exception("No panel found with an anchorMin.x of 0!");

        //Work out how many panels to move by and in which direction
        int distance = startingPoition - panel;

        float timeElapsed = 0;
        int secondryPanelsHidden = 0;

        float timeStep = transitionSmoothness;//The length of coroutine frames in seconds
        float duration = transitionDuration;//Duration of coroutine in seconds
        while (timeElapsed < duration)
        {
            if (secondryPanelsHidden < secondryPages.Length && timeElapsed > secondryPanelsHidden * secondryPageHidingInterval)
            {
                secondryPages[secondryPanelsHidden].SetInteger("Show", 0);
                secondryPanelsHidden++;
            }

            //For each panel...
            for (int i = 0; i < panels.Length; i++)
            {
                //... update their anchor X positions
                SetHorizontalAnchor(ref panels[i], timeStep, distance, duration);
            }
            timeElapsed += timeStep;
            yield return new WaitForSecondsRealtime(timeStep);
        }

        //For each panel - round off their anchor X positions to the nearest whole number
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].anchorMin = new Vector2(Mathf.RoundToInt(panels[i].anchorMin.x), 0.12f);
            panels[i].anchorMax = new Vector2(Mathf.RoundToInt(panels[i].anchorMax.x), 0.88f);
        }

        //Then set the new title
        SetTitle(titleMessage);
    }

    /// <summary>
    /// Sets the min and max anchor X positions of a given RectTransform
    /// Also assigns a min Y of 0.12 and a max Y of 0.88
    /// </summary>
    /// <param name="panel">The RectTransform to move</param>
    /// <param name="timeStep">The distance to move it</param>
    /// <param name="distance">The overall distance to move in whole RectTransform width percentages</param>
    /// <param name="duration">The overall time to move the RectTransform in</param>
    public void SetHorizontalAnchor(ref RectTransform panel, float timeStep, int distance, float duration)
    {
        panel.anchorMin = new Vector2(panel.anchorMin.x + ((timeStep * distance) / duration), 0.12f);
        panel.anchorMax = new Vector2(panel.anchorMax.x + ((timeStep * distance) / duration), 0.88f);
    }
}
