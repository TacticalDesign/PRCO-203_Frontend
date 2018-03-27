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

        /*

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

        */

        // Young People Testing
        // ====================

        YoungPerson yp = await YoungPerson.Login("toby@tobysmith.uk", "password1");
        Debug.Log("Logged in young person token: " + yp.RawToken);
        Debug.Log("Logged in young person surname: " + yp.Surname);

        //Edit the logged in account
        await yp.EditSelf(surname: "Jones");
        Debug.Log("Logged in admin surname: " + yp.Surname);
        await yp.EditSelf(surname: "Smith");
        Debug.Log("Logged in admin surname: " + yp.Surname);


#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
