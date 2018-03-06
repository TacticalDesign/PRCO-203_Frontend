using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour
{
    [SerializeField]
    MainCanvas mainCanvas;

    [SerializeField]
    Animator animator;

    private void Login()
    {
        animator.SetTrigger("Close");
    }

    public void YouthLogin()
    {
        mainCanvas.ShowYouthNavbar();
        Login();
    }

    public void ChallengerLogin()
    {
        mainCanvas.ShowChallengerNavbar();
        Login();
    }

    public void AdminLogin()
    {
        mainCanvas.ShowAdminNavbar();
        Login();
    }
}
