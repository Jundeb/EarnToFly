using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void ReturnButton()
    {
        OptionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
