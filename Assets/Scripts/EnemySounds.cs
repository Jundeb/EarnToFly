using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    public AudioClip birdSound;
    private AudioSource birdAudioSource;
    public AudioClip eagleSound;
    private AudioSource eagleAudioSource;
    public AudioClip hotAirBalloonSound;
    private AudioSource hotAirBalloonAudioSource;

    private void Awake()
    {
        birdAudioSource = GetComponent<AudioSource>();
        eagleAudioSource = GetComponent<AudioSource>();
        hotAirBalloonAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        birdAudioSource.clip = birdSound;
        eagleAudioSource.clip = eagleSound;
        hotAirBalloonAudioSource.clip = hotAirBalloonSound;

    }

    internal void PlayBirdSound()
    {
        Debug.Log("ChirpSound");
        birdAudioSource.Play();
    }

    internal void PlayEagleSound()
    {
        Debug.Log("EagleSound");
        eagleAudioSource.Play();
    }

    internal void PlayHotAirBalloonSound()
    {
        Debug.Log("HotAirBalloonSound");
        hotAirBalloonAudioSource.Play();
    }
}
