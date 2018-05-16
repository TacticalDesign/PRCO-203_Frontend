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
		mainCanvas.YouthLogin ();
    }

    /// <summary>
    /// Login logic specific to the challenger account
    /// Also includes a call to the generic login logic
    /// </summary>
    public void ChallengerLogin()
    {
        mainCanvas.SetAccountType(AccountType.Challenger);
        Login();
		mainCanvas.ChallengerLogin ();
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
		switch (username.text.ToLower ()) {
		case "thedeadpencils":
			if (password.text == "password") {
				ChallengerLogin ();
				challLog.SetChallengerID (username.text.ToLower ());
			}
			break;
		case "rio":
			if (password.text == "password") {
				ChallengerLogin ();
				challLog.SetChallengerID (username.text.ToLower ());
			}
			break;
		case "katefarmery":
			if (password.text == "password") {
				ChallengerLogin ();
				challLog.SetChallengerID (username.text.ToLower ());
			}
			break;
		case "theshorelymagazine":
			if (password.text == "password") {
				ChallengerLogin ();
				challLog.SetChallengerID (username.text.ToLower ());
			}
			break;
		case "jacobbrandon":
			if (password.text == "password") {
				ChallengerLogin ();
				challLog.SetChallengerID (username.text.ToLower ());
			}
			break;
		case "carmendesilva":
			if (password.text == "password") {
				ChallengerLogin ();
				challLog.SetChallengerID (username.text.ToLower ());
			}
			break;
		case "wonderassociates":
			if (password.text == "password") {
				ChallengerLogin ();
				challLog.SetChallengerID (username.text.ToLower ());
			}
			break;
		case "jm12345":
			if (password.text == "password") {
				YouthLogin ();
				youthLog.SendID (username.text.ToLower ());
			}
			break;
		}
	}
}
