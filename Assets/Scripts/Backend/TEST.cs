using Backend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    async void Start()
    {
        TokenRequest t = await API.GetToken("tobysmith568@hotmail.co.uk", "password1");
        Debug.Log(t.Value);

        Admin a = await Admin.GetSelf();
        Debug.Log(a.Surname);

        a = await Admin.EditSelf(surname: "Smith");
        Debug.Log(a.Surname);
        a = await Admin.EditSelf(surname: "Jones");
        Debug.Log(a.Surname);

        YoungPerson yp = await Admin.CreateYoungPerson("test@tobysmith.uk", "dave");
        Debug.Log(yp.FirstName);
        Debug.Log(yp.IsFrozen);

        yp = await Admin.ToggleYoungPersonFreeze(yp.ID, true);
        Debug.Log(yp.IsFrozen);
        yp = await Admin.ToggleYoungPersonFreeze(yp.ID, false);
        Debug.Log(yp.IsFrozen);
    }
}
