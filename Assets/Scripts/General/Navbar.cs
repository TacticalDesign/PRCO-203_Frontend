using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Navbar : MonoBehaviour
{
    private void Start()
    {
        //Show the first panel
        transform.GetChild(0).GetComponent<NavbarItem>().Show();
    }
}
