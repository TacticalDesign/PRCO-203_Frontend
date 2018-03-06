using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class NavbarItem : MonoBehaviour
{
    [Header("Transition Settings")]
    [SerializeField]
    GameObject panel;
    [SerializeField]
    MainCanvas mainCanvas;
    [Header("Title Settings")]
    [SerializeField]
    string titleMessage;

    /// <summary>
    /// Swaps the main display panel to this items panel
    /// </summary>
    public void Show()
    {
        mainCanvas.HideAllPanels();
        mainCanvas.SetTitle(titleMessage);
        panel.SetActive(true);
    }
}
