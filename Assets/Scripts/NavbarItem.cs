using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class NavbarItem : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    [SerializeField]
    MainCanvas mainCanvas;

    /// <summary>
    /// Swaps the main display panel to this items panel
    /// </summary>
    public void Show()
    {
        Debug.Log("RAN!");
        mainCanvas.HideAllPanels();
        panel.SetActive(true);
    }
}
