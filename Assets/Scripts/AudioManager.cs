using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class AudioManager : MonoBehaviour
{
    public AudioMixer GameAudioMixer;
    public TextMeshProUGUI VolumeSliderText;
    public string ExposedVolumeParam = "GameVolume";
    public void LoadAudioSettings()
    {
        /*
        if (PlayerPrefs.HasKey("SavedVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("SavedVolume");
            SetVolume(savedVolume);
        }
        */
    }
    public void SaveAudioSettings()
    {
        /*
        float volume;
        GameAudioMixer.GetFloat(ExposedVolumeParam, out volume);
        PlayerPrefs.SetFloat("SavedVolume", volume);
        PlayerPrefs.Save();
        */
    }
    public void SetVolume(float volume)
    {
        GameAudioMixer.SetFloat(ExposedVolumeParam, volume);
        float TextValue = ((80+volume)/80)*100;
        VolumeSliderText.text = TextValue.ToString("0");
    }
}
