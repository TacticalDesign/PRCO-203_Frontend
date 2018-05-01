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
            sounds.Play();
            Invoke("ThrowParticles", 0.9f);
        }
    }

    private void Update()
    {
        isRunning = particles.isPlaying || sounds.isPlaying;
    }

    private void ThrowParticles() {
        particles.Play();
    }
}
