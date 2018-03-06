using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    List<GameObject> mainPanels = new List<GameObject>();

    [SerializeField]
    GameObject youthNavbar;
    [SerializeField]
    GameObject challengerNavbar;
    [SerializeField]
    GameObject adminNavbar;

    [SerializeField]
    Text title;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "MainPanel")
            {
                mainPanels.Add(transform.GetChild(i).gameObject);
                Debug.Log(transform.GetChild(i).name);
            }
        }
    }

    /// <summary>
    /// Disabled all of the main content panels
    /// </summary>
    public void HideAllPanels()
    {
        foreach (GameObject panel in mainPanels)
        {
            panel.SetActive(false);
        }
    }

    /// <summary>
    /// Sends the app to the login screen
    /// </summary>
    public void LoginScreen()
    {
        throw new System.Exception("Not developed yet!");
    }

    public void ShowYouthNavbar()
    {
        youthNavbar.SetActive(true);
        challengerNavbar.SetActive(false);
        adminNavbar.SetActive(false);
    }

    public void ShowChallengerNavbar()
    {
        youthNavbar.SetActive(false);
        challengerNavbar.SetActive(true);
        adminNavbar.SetActive(false);
    }

    public void ShowAdminNavbar()
    {
        youthNavbar.SetActive(false);
        challengerNavbar.SetActive(false);
        adminNavbar.SetActive(true);
    }

    public void SetTitle(string newTitle)
    {
        title.text = newTitle;
    }
}
