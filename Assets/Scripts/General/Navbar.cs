using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navbar : MonoBehaviour
{
    private void Start()
    {
        transform.GetChild(0).GetComponent<NavbarItem>().Show();
    }
}
