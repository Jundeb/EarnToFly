using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartingMenu : MonoBehaviour
{
    public AudioManager AudioManager;
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
    public void CreditsButton()
    {
        SceneManager.LoadScene("CreditsScreen");
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
