using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttonmanager : MonoBehaviour
{

    public GameObject settingsMenuObj;

    public GameObject confirmExitMenu;
    public GameObject confirmMainMenu;

    GameObject[] pauseButtons = GameObject.FindGameObjectsWithTag("PauseButton");


    public void Start()
    {
        settingsMenuObj.SetActive(false);
        confirmExitMenu.SetActive(false);
        confirmMainMenu.SetActive(false);

        for (int i = 0; i < pauseButtons.Length; i++)
        {
            pauseButtons[i].SetActive(true);
        }
    }

    public void OnContinuePress()
    {
        GameObject pauseManager = GameObject.FindGameObjectWithTag("PauseManager");
        pauseManager.GetComponent<PauseManager>().paused = false;
    }

    private void HidePauseButtons()
    {
        for (int i = 0; i < pauseButtons.Length; i++)
        {
            pauseButtons[i].SetActive(false);
        }
    }

    private void ShowPauseButtons()
    {
        for (int i = 0; i < pauseButtons.Length; i++)
        {
            pauseButtons[i].SetActive(true);
        }
    }
    // Menu related buttons
    public void OnMenuButtonPress()
    {
        confirmMainMenu.SetActive(true);
        HidePauseButtons();
    }

    public void OnMenuYesPress()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnConfirmNoPress()
    {
        confirmExitMenu.SetActive(false);
        confirmMainMenu.SetActive(false);
    }

    //Exit related buttons
    public void OnExitButtonPress()
    {
        confirmExitMenu.SetActive(true);
        HidePauseButtons();
    }

    public void OnExitYesPress()
    {
        Application.Quit();
    }

    //The no-option in the confirm menu for exit is the same as the main menu one
    

    //Settings related buttons
    public void OnSettingsPress()
    {
        settingsMenuObj.SetActive(true);
    }
}
