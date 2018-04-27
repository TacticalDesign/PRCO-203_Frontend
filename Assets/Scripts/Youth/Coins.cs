using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    ParticleSystem particles;
    AudioSource sounds;

    [HideInInspector]
    public bool isRunning = false;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
        sounds = GetComponent<AudioSource>();
    }


    public void Fire()
    {
        if (!particles.isPlaying)
        {
            particles.Play();
            sounds.Play();
        }
    }

    private void Update()
    {
        isRunning = particles.isPlaying || sounds.isPlaying;
    }
}
