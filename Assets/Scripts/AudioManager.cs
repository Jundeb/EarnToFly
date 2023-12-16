using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public AudioMixer GameAudioMixer;
    public TextMeshProUGUI VolumeSliderText;
    public Slider VolumeSlider;
    public string ExposedVolumeParam = "GameVolume";
    private void Start()
    {
        LoadAudioSettings();
    }
    public void SaveAudioSettings()
    {
        float volume = VolumeSlider.value;
        PlayerPrefs.SetFloat("SavedVolume", volume);
        PlayerPrefs.Save();
        LoadAudioSettings();
    }
    public void LoadAudioSettings()
    {
        if (PlayerPrefs.HasKey("SavedVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("SavedVolume");
            Debug.Log("Loaded volume: " + savedVolume); // Check if this logs the correct volume
            SetVolume(savedVolume);
        }
        else
        {
            Debug.Log("SavedVolume not found");
        }
    }
    public void SetVolume(float volume)
    {
        VolumeSlider.value = volume;
        GameAudioMixer.SetFloat(ExposedVolumeParam, volume);
        float TextValue = ((80+volume)/80)*100;
        VolumeSliderText.text = TextValue.ToString("0");
    }
}
