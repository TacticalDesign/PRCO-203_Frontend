using Backend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    async void Start()
    {
        //Logging in
        Debug.Log("<b>Login to all 3 accounts</b>");
        Admin admin = await Admin.Login("tobysmith568@hotmail.co.uk", "password1");
        Challenger challenger = await Challenger.Login("devonLife@tobysmith.uk", "password1");
        YoungPerson youngPerson = await YoungPerson.Login("toby@tobysmith.uk", "password1");

        //Self-editing
        Debug.Log("<b>All 3 accounts self-editing</b>");
        Debug.Log("Admin firstname: " + admin.FirstName);
        await admin.EditSelf(firstName: "Mike");
        Debug.Log("Admin firstname: " + admin.FirstName);
        await admin.EditSelf(firstName: "Toby");
        Debug.Log("Admin firstname: " + admin.FirstName);
        Debug.Log("Challenger name: " + challenger.Name);
        await challenger.EditSelf(name: "Cornwall Life");
        Debug.Log("Challenger name: " + challenger.Name);
        await challenger.EditSelf(name: "Devon Life");
        Debug.Log("Challenger name: " + challenger.Name);
        Debug.Log("Young Person firstname: " + youngPerson.FirstName);
        await youngPerson.EditSelf(firstName: "Mike");
        Debug.Log("Young Person firstname: " + youngPerson.FirstName);
        await youngPerson.EditSelf(firstName: "Toby");
        Debug.Log("Young Person firstname: " + youngPerson.FirstName);
        
        //Create a challenge (both frozen and defrosted)
        Debug.Log("<b>Create a challenge (with both a frozen and defrosted challenger)</b>");
        Debug.Log("Challenger is frozen: " + challenger.IsFrozen);
        challenger = await admin.SetChallengerFreeze(challenger, true);
        Debug.Log("Challenger is frozen: " + challenger.IsFrozen);
        
        Debug.Log("Try to create a challenge");
        Challenger.Challenge challenge = await challenger.CreateChallenge("This is a challenge", new string[] { "Skill1", "Skill2" }, "Description",
                                         700, "Street", "City", "Postcode", new System.DateTime(2018, 06, 15), 1, 3);
        Debug.Log("Challenge exists: " + (challenge == null ? "False" : "True"));

        Debug.Log("Defrost the challenger");
        challenger = await admin.SetChallengerFreeze(challenger, false);
        Debug.Log("Challenger is frozen: " + challenger.IsFrozen);

        Debug.Log("Try to create a challenge");
        challenge = await challenger.CreateChallenge("This is a challenge", new string[] { "Skill1", "Skill2" }, "Description",
                                         700, "Street", "City", "Postcode", new System.DateTime(2018, 06, 15), 1, 3);
        Debug.Log("Challenge exists: " + (challenge == null ? "False" : "True"));
        
        //Attend the challenge (both frozen and defrosted)
        Debug.Log("<b>Attend the challenge (with both a frozen and defrosted young person)</b>");
        Debug.Log("Young person is frozen: " + youngPerson.IsFrozen);
        youngPerson = await admin.SetYoungPersonFreeze(youngPerson, true);
        Debug.Log("Young person is frozen: " + youngPerson.IsFrozen);

        Debug.Log("Try to attend the challenge");
        Debug.Log("Successfully attended: " + await youngPerson.AttendChallenge(challenge, true));

        Debug.Log("Defrost the young person");
        youngPerson = await admin.SetYoungPersonFreeze(youngPerson, false);
        Debug.Log("Young person is frozen: " + youngPerson.IsFrozen);

        Debug.Log("Try to attend the challenge");
        Debug.Log("Successfully attended: " + await youngPerson.AttendChallenge(challenge, true));
        await challenger.Update();
        await challenge.Update(youngPerson.RawToken);
        Debug.Log("Young person's challenge count: " + youngPerson.CurrentChallenges.Length);
        Debug.Log("Challenge's young people count: " + challenge.Attendees.Length);
        Debug.Log("Challenger's challenge count: " + challenger.CurrentChallenges.Length);

        //De-attend and re-attend the challenge
        Debug.Log("<b>De-attend and re-attend the challenge</b>");
        Debug.Log("Successfully de-attended: " + await youngPerson.AttendChallenge(challenge, false));
        await challenger.Update();
        await challenge.Update(youngPerson.RawToken);
        Debug.Log("Young person's challenge count: " + youngPerson.CurrentChallenges.Length);
        Debug.Log("Challenge's young people count: " + challenge.Attendees.Length);
        Debug.Log("Challenger's challenge count: " + challenger.CurrentChallenges.Length);

        Debug.Log("Successfully attended: " + await youngPerson.AttendChallenge(challenge, true));
        await challenger.Update();
        await challenge.Update(youngPerson.RawToken);

        //Get the challenges challenger's information from the Young Person


#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
