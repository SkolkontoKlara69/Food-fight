using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttonmanager : MonoBehaviour
{


    GameObject[] pauseButtons;
    GameObject[] confirmMainMenuButtons;
    GameObject[] confirmExitButtons;
    GameObject[] settingsObjs;
    GameObject[] settingsCategoryButtons;
    GameObject[] rebindButtons;
    GameObject[] audioButtons;
    GameObject[] movementButtons;

    GameObject pauseManager;

    private void Awake()
    {
        pauseButtons = GameObject.FindGameObjectsWithTag("PauseButton");
        confirmMainMenuButtons = GameObject.FindGameObjectsWithTag("confirmMainMenu");
        pauseManager = GameObject.FindGameObjectWithTag("PauseManager");
        confirmExitButtons = GameObject.FindGameObjectsWithTag("confirmExit");
        settingsObjs = GameObject.FindGameObjectsWithTag("settings");
        settingsCategoryButtons = GameObject.FindGameObjectsWithTag("settingsCategory");
        rebindButtons = GameObject.FindGameObjectsWithTag("rebind");
        audioButtons = GameObject.FindGameObjectsWithTag("audio");
        movementButtons = GameObject.FindGameObjectsWithTag("movementSettings");
    }
    public void Start()
    {

        ShowButtons(pauseButtons, true);
        ShowButtons(confirmMainMenuButtons, false);
        ShowButtons(confirmExitButtons, false);
        ShowButtons(settingsObjs, false);
        ShowButtons(settingsCategoryButtons, false);
        ShowButtons(rebindButtons, false);
        ShowButtons(audioButtons, false);
        ShowButtons(movementButtons, false);
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
        ShowButtons(settingsObjs, false);
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
        ShowButtons(settingsObjs, true);
        ShowButtons(settingsCategoryButtons, true);
        ShowButtons(pauseButtons, false);

        ShowButtons(rebindButtons, false);
        ShowButtons(audioButtons, false);
        ShowButtons(movementButtons, false);
    }

    public void OnRebindCategoryPress()
    {
        ShowButtons(settingsCategoryButtons, false);
        ShowButtons(rebindButtons, true);
    }

    public void OnAudioCategoryPress()
    {
        ShowButtons(settingsCategoryButtons, false);
        ShowButtons(audioButtons, true);
    }

    public void OnMovementCategoryPress()
    {
        ShowButtons(settingsCategoryButtons, false);
        ShowButtons(movementButtons, true);
    }

    public void OnLevelSelectButton()
    {
        SceneManager.LoadScene("Level selector");
    }

    //Select level buttons
    public void OnTutorialSelected()
    {
        SceneManager.LoadScene("Tutorial level");
    }

    public void OnUSASelected()
    {
        SceneManager.LoadScene("USA");
    }

    public void OnJapanSelected()
    {
        SceneManager.LoadScene("Japan");
    }

    public void OnFranceSelected()
    {
        SceneManager.LoadScene("French");
    }
    public void OnLondonSelected()
    {
        SceneManager.LoadScene("London");
    }

    public void OnRebindStart()
    {
        ShowButtons(rebindButtons, false);
    }

    public void OnRebindStop()
    {
        ShowButtons(rebindButtons, true);
    }
}
