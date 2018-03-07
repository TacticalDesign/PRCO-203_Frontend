using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class NavbarItem : MonoBehaviour
{
    [SerializeField]
    MainCanvas mainCanvas;

    [Header("Transition Settings")]
    [SerializeField]
    AccountType accountType;
    [SerializeField]
    int panelNumber;

    [Header("Title Settings")]
    [SerializeField]
    string titleMessage;

    /// <summary>
    /// Called by the GameObjects button click event
    /// Switches to the wanted panel
    /// </summary>
    public void Show()
    {
        mainCanvas.StartCoroutine(mainCanvas.ShowPanel(accountType, panelNumber, titleMessage));
    }
}
