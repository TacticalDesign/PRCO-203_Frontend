using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Navbar : MonoBehaviour
{
    private void Start()
    {
        transform.GetChild(0).GetComponent<NavbarItem>().Show();
    }
}
