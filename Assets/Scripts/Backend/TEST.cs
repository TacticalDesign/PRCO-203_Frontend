using Backend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour {

    // Use this for initialization
    async void Start ()
    {
        Token t = await API.GetToken("tobysmith568@hotmail.co.uk", "password1");
        Debug.Log(t.Value);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
