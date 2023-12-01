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

    public void Start()
    {
        settingsMenuObj.SetActive(false);
        confirmExitMenu.SetActive(false);
        confirmMainMenu.SetActive(false);
    }

    // Menu related buttons
    public void OnMenuButtonPress()
    {
        confirmMainMenu.SetActive(true);
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
