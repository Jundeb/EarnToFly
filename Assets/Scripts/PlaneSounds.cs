using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlaneSounds : MonoBehaviour
{
    public float soundFxPitch;
    public AudioClip engineSound;
    private AudioSource engineAudioSource;
    private PlaneControlV2 planeControlV2;
    private void Awake()
    {
        engineAudioSource = GetComponent<AudioSource>();
        planeControlV2 = GameObject.FindWithTag("Player").GetComponent<PlaneControlV2>();
    }

    private void Start()
    {
        soundFxPitch = 1.0f;
        engineAudioSource.clip = engineSound;
        engineAudioSource.loop = true;
        engineAudioSource.pitch = soundFxPitch;
        engineAudioSource.Play();
    }

    void Update()
    {
        engineAudioSource.pitch = soundFxPitch;
        if(planeControlV2.flySpeed > 20)
        {
            soundFxPitch = Mathf.Lerp(soundFxPitch, 1.5f, Time.deltaTime * 0.5f);
        }
        else
        {
            soundFxPitch = Mathf.Lerp(soundFxPitch, 1.0f, Time.deltaTime * 0.5f);
        }
    }
}
