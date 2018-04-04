using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyYouthLogin : MonoBehaviour {

	[SerializeField]
	private DummyFillInformation profilePage;

	public void SendID(string _youthID){
		profilePage.SetInformationID (_youthID);
	}
}
