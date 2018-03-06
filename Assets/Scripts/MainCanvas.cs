using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{

    List<GameObject> mainPanels = new List<GameObject>();

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

    public void HideAllPanels()
    {
        foreach (GameObject panel in mainPanels)
        {
            panel.SetActive(false);
        }
    }
}
