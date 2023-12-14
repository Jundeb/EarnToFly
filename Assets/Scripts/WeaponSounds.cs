using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSounds : MonoBehaviour
{
    public AudioClip shootSound;
    private AudioSource shootAudioSource;

    private void Awake()
    {
        shootAudioSource = GetComponent<AudioSource>();
    }

    internal void PlayShootSound()
    {
        // shootAudioSource.Play();
        Debug.Log("ShootSound");
    }
}
