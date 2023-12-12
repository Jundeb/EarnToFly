using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using Unity.VisualScripting;

public class StartingMenu : MonoBehaviour
{
    private AudioManager AudioManager;
    public GameObject OptionsPanel;
    public GameObject MainMenuPanel;
    // MAIN MENU
    public void StartGame()
    {
        SceneManager.LoadScene("UpgradeScreen");
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

    public void ReturnButton()
    {
        OptionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
    public void AcceptButton()
    {
        if(AudioManager != null)
        {
            AudioManager.SaveAudioSettings();
        }
        ReturnButton();
    }
}
