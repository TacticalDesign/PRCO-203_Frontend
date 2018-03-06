using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScreen : MonoBehaviour
{
    [SerializeField]
    MainCanvas mainCanvas;

    private void Login()
    {
        gameObject.SetActive(false);
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
