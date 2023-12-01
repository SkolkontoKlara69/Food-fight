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
    GameObject[] confirmMainMenuButtons = GameObject.FindGameObjectsWithTag("PauseButton");

    public void Start()
    {

        ShowButtons(pauseButtons, true);
        ShowButtons(confirmMainMenuButtons, false);

        settingsMenuObj.SetActive(false);
        confirmExitMenu.SetActive(false);
        confirmMainMenu.SetActive(false);
    }

    public void OnContinuePress()
    {
        GameObject pauseManager = GameObject.FindGameObjectWithTag("PauseManager");
        pauseManager.GetComponent<PauseManager>().paused = false;
    }


    private void ShowButtons(GameObject[] buttons, bool activeOrNo)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(activeOrNo);
        }
    }
    // Menu related buttons
    public void OnMenuButtonPress()
    {
        confirmMainMenu.SetActive(true);
        ShowButtons(pauseButtons, false);
    }

    public void OnMenuYesPress()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnConfirmNoPress()
    {
        confirmExitMenu.SetActive(false);
        confirmMainMenu.SetActive(false);
        ShowButtons(pauseButtons, false);
    }

    //Exit related buttons
    public void OnExitButtonPress()
    {
        confirmExitMenu.SetActive(true);
        ShowButtons(pauseButtons, false);
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
