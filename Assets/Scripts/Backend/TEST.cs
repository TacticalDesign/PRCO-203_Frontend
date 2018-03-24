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
    }
}
