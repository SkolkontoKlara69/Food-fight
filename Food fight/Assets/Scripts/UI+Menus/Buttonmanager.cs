using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttonmanager : MonoBehaviour
{

    public GameObject settingsMenuObj;

    GameObject[] pauseButtons;
    GameObject[] confirmMainMenuButtons;
    GameObject[] confirmExitButtons;

    GameObject pauseManager;

    private void Awake()
    {
        pauseButtons = GameObject.FindGameObjectsWithTag("PauseButton");
        confirmMainMenuButtons = GameObject.FindGameObjectsWithTag("confirmMainMenu");
        pauseManager = GameObject.FindGameObjectWithTag("PauseManager");
        confirmExitButtons = GameObject.FindGameObjectsWithTag("confirmExit");
    }
    public void Start()
    {

        ShowButtons(pauseButtons, true);
        ShowButtons(confirmMainMenuButtons, false);
        ShowButtons(confirmExitButtons, false);

        settingsMenuObj.SetActive(false);
    }

    public void OnContinuePress()
    { 
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

        ShowButtons(confirmMainMenuButtons, true);
        ShowButtons(pauseButtons, false);
    }

    public void OnMenuYesPress()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnConfirmNoPress()
    {
        ShowButtons(confirmExitButtons, false);
        ShowButtons(confirmMainMenuButtons, false);
        ShowButtons(pauseButtons, true);
    }

    //Exit related buttons
    public void OnExitButtonPress()
    {
        ShowButtons(confirmExitButtons, true);
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
