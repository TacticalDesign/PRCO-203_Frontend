using Backend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    async void Start()
    {
        // Admin Testing
        // =============

        //Login using Admin credentials
        Admin a = await Admin.Login("tobysmith568@hotmail.co.uk", "password1");
        Debug.Log("Logged in admin token: " + a.RawToken);
        Debug.Log("Logged in admin surname: " + a.Surname);

        //Edit the logged in account
        await a.EditSelf(surname: "Jones");
        Debug.Log("Logged in admin surname: " + a.Surname);
        await a.EditSelf(surname: "Smith");
        Debug.Log("Logged in admin surname: " + a.Surname);

        //Create a Young Person
        YoungPerson yp = await a.CreateYoungPerson("dave@tobysmith.uk", "Dave");
        Debug.Log("Created Young Person called: " + yp.FirstName);
        Debug.Log("Is Dave frozen: " + yp.IsFrozen);

        //Freeze/Defrost the Young Person
        yp = await a.SetYoungPersonFreeze(yp.ID, true);
        Debug.Log("Is Dave frozen: " + yp.IsFrozen);
        yp = await a.SetYoungPersonFreeze(yp.ID, false);
        Debug.Log("Is Dave frozen: " + yp.IsFrozen);

        //Create a Challenger
        Challenger chr = await a.CreateChallenger("devonLife@tobysmith.uk", "Devon Life");
        Debug.Log("Created a Challenger called: " + chr.Name);
        Debug.Log("Is Devon Life frozen: " + chr.IsFrozen);

        //Freeze/Defrost the Challenger
        chr = await a.SetChallengerFreeze(chr.ID, true);
        Debug.Log("Is Devon Life frozen: " + chr.IsFrozen);
        chr = await a.SetChallengerFreeze(chr.ID, false);
        Debug.Log("Is Devon Life frozen: " + chr.IsFrozen);

        //Create a Reward
        Reward r = await a.CreateReward("Amazon £10", "This is an Amazon voucher", 500);
        Debug.Log("Created a Reward called: " + r.Name);
        Debug.Log("Is Amazon £10 frozen: " + r.IsFrozen);



        // Challenger Testing
        // ====================

        //Challenger c = await Challenger.Login("devonLife@tobysmith.uk", "password1");
        //Debug.Log("Logged in Challenger token: " + c.RawToken);
        //Debug.Log("Logged in Challenger name: " + c.Name);

        ////Edit the logged in account
        //await c.EditSelf(name: "Cornwall Life");
        //Debug.Log("Logged in Challenger name: " + c.Name);
        //await c.EditSelf(name: "Devon Life");
        //Debug.Log("Logged in Challenger name: " + c.Name);

        ////Create a Challenge
        //Challenger.Challenge c1 = await c.CreateChallenge("Article", new string[] { "arty" }, "This is a description",
        //    50, "", "", "Devon", new System.DateTime(2018, 05, 06, 12, 00, 00), 1, 10);
        //Debug.Log("New challenges name: " + c1.Name);
        //Debug.Log("New challenges description: " + c1.Description);

        ////Edit the Challenge
        //await c1.EditChallenge(c.RawToken, description: "This is a new description");
        //Debug.Log("New challenges description: " + c1.Description);
        //await c1.EditChallenge(c.RawToken, description: "This is a description");
        //Debug.Log("New challenges description: " + c1.Description);


        // Young People Testing
        // ====================

        //YoungPerson yp = await YoungPerson.Login("toby@tobysmith.uk", "password1");
        //Debug.Log("Logged in young person token: " + yp.RawToken);
        //Debug.Log("Logged in young person surname: " + yp.Surname);

        ////Edit the logged in account
        //await yp.EditSelf(surname: "Jones");
        //Debug.Log("Logged in young person surname: " + yp.Surname);
        //await yp.EditSelf(surname: "Smith");
        //Debug.Log("Logged in young person surname: " + yp.Surname);

        ////Get and attend a challenge
        //Challenger.Challenge c1 = await Challenger.Challenge.GetChallenge(yp.RawToken, "15217881817431");
        //Debug.Log("Found Challenge's name: " + c1.Name);
        //Debug.Log("Found Challenge's young person count: " + c1.Attendees.Length);
        //Debug.Log("Logged in young person challenges count: " + yp.CurrentChallenges.Length);
        //await yp.AttendChallenge("15217881817431", true);
        //await c1.Update(yp.RawToken);
        //Debug.Log("Found Challenge's young person count: " + c1.Attendees.Length);
        //Debug.Log("Logged in young person challenges count: " + yp.CurrentChallenges.Length);
        //await yp.AttendChallenge("15217881817431", false);
        //await c1.Update(yp.RawToken);
        //Debug.Log("Found Challenge's young person count: " + c1.Attendees.Length);
        //Debug.Log("Logged in young person challenges count: " + yp.CurrentChallenges.Length);


#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
