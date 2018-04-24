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

	[SerializeField]
	private InputField username;

	[SerializeField]
	private InputField password;

	[SerializeField]
	private DummyChallengerLogin challLog;

	[SerializeField]
	private DummyYouthLogin youthLog;

    /// <summary>
    /// Login logic shared by all accounts
    /// Runs after account-specific logic
    /// </summary>
    private void Login()
	{
		animator.SetTrigger("Close");
    }

	/// <summary>
	/// Clears the username and password input fields
	/// </summary>
	public void ClearFields(){
		username.text = "";
		password.text = "";
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

	public void SetupLogin(){
		if (username.text.ToLower () == "alee1234" && password.text == "adamsucks") {
			ChallengerLogin ();
			challLog.SetChallengerID (username.text.ToLower ());
		} else if (username.text.ToLower () == "tsmith1234" && password.text == "iloveenums") {
			ChallengerLogin ();
			challLog.SetChallengerID (username.text.ToLower ());
		} else if (username.text.ToLower () == "jm12345" && password.text == "weebunited") {
			YouthLogin ();
			youthLog.SendID (username.text.ToLower ());
		} else {
			Debug.Log ("Username/Password wrong");
		}
	}
}
