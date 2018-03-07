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

    /// <summary>
    /// Login logic shared by all accounts
    /// Runs after account-specific logic
    /// </summary>
    private void Login()
    {
        animator.SetTrigger("Close");
    }

    /// <summary>
    /// Login logic specific to the youth account
    /// Also includes a call to the generic login logic
    /// </summary>
    public void YouthLogin()
    {
        mainCanvas.SetAccountType(AccountType.Youth);
        Login();
    }

    /// <summary>
    /// Login logic specific to the challenger account
    /// Also includes a call to the generic login logic
    /// </summary>
    public void ChallengerLogin()
    {
        mainCanvas.SetAccountType(AccountType.Challenger);
        Login();
    }

    /// <summary>
    /// Login logic specific to the admin account
    /// Also includes a call to the generic login logic
    /// </summary>
    public void AdminLogin()
    {
        mainCanvas.SetAccountType(AccountType.Admin);
        Login();
    }
}
