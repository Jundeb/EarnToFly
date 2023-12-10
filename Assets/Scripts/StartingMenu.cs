using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartingMenu : MonoBehaviour
{
    public GameObject OptionsPanel;
    public GameObject MainMenuPanel;
    // MAIN MENU
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OptionsButton()
    {
        MainMenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    // OPTIONS MENU
    public AudioMixer GameAudioMixer;

    public void ReturnButton()
    {
        OptionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void SetVolume(float volume)
    {
        GameAudioMixer.SetFloat("GameVolume", volume);
    }
}
