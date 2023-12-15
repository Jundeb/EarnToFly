using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    public AudioClip birdSound;
    public AudioClip eagleSound;
    public AudioClip hotAirBalloonSound;

    private AudioSource birdAudioSource;
    private AudioSource eagleAudioSource;
    private AudioSource hotAirBalloonAudioSource;

    private void Awake()
    {
        // Create a new AudioSource for each sound
        birdAudioSource = gameObject.AddComponent<AudioSource>();
        eagleAudioSource = gameObject.AddComponent<AudioSource>();
        hotAirBalloonAudioSource = gameObject.AddComponent<AudioSource>();

        // Set the clip of each AudioSource
        birdAudioSource.clip = birdSound;
        eagleAudioSource.clip = eagleSound;
        hotAirBalloonAudioSource.clip = hotAirBalloonSound;
    }

    internal void PlayBirdSound()
    {
        birdAudioSource.Play();
    }

    internal void PlayEagleSound()
    {
        eagleAudioSource.Play();
    }

    internal void PlayHotAirBalloonSound()
    {
        hotAirBalloonAudioSource.Play();
    }
}