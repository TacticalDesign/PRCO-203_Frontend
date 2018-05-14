using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType {
ACCEPT,
DECLINE,
JACKPOT}

public class AudioManager : MonoBehaviour {

    [SerializeField]
    private AudioSource accept;
    [SerializeField]
    private AudioSource decline;
    [SerializeField]
    private AudioSource jackpot;

    private static AudioManager singleton;

    // Use this for initialization
    void Start () {
		if (singleton == null)
        {
            singleton = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void GetAudioSource(SoundType soundType) {
        switch (soundType)
        {
            case SoundType.ACCEPT:
                singleton.accept.Play();
                break;
            case SoundType.DECLINE:
                singleton.decline.Play();
                break;
            case SoundType.JACKPOT:
                singleton.jackpot.Play();
                break;
            default:
                break;
        }

    }


}
