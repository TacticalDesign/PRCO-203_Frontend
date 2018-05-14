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
    [SerializeField]
    RectTransform margin;

    [Header("Title Settings")]
    [SerializeField]
    string titleMessage;

    static List<NavbarItem> allNavBarItems;

    private void Start()
    {
        if (allNavBarItems == null)
            allNavBarItems = new List<NavbarItem>();
        allNavBarItems.Add(this);
    }

    

    /// <summary>
    /// Called by the GameObjects button click event
    /// Switches to the wanted panel
    /// </summary>
    public void Show()
    {
        mainCanvas.StartCoroutine(mainCanvas.ShowPanel(accountType, panelNumber, titleMessage));

        if (allNavBarItems != null)
            foreach (NavbarItem item in allNavBarItems)
            {
                if (item.gameObject.activeInHierarchy)
                    item.StartCoroutine(item.Shrink());
            }

        StopAllCoroutines();
        StartCoroutine(Grow());
    }

    public IEnumerator Grow()
    {
        float startMin = margin.anchorMin.y;
        float startMax = margin.anchorMax.y;

        for (int i = 0; i < 10; i++)
        {
            margin.anchorMin = new Vector2(0, Mathf.Lerp(startMin, 0.05f, i / 10f));
            margin.anchorMax = new Vector2(1, Mathf.Lerp(startMax, 0.95f, i / 10f));
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator Shrink()
    {
        float startMin = margin.anchorMin.y;
        float startMax = margin.anchorMax.y;

        for (int i = 0; i < 10; i++)
        {
            margin.anchorMin = new Vector2(0, Mathf.Lerp(startMin, 0.1f, i / 10f));
            margin.anchorMax = new Vector2(1, Mathf.Lerp(startMax, 0.9f, i / 10f));
            yield return new WaitForSeconds(0.01f);
        }
    }
}
