using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectButtonScript : MonoBehaviour
{
    public GameObject firstMenuButton;
    public GameObject firstSettingsButton;
    public GameObject firstConfirmMenuButton;
    public GameObject firstConfirmExitButton;
    public EventSystem eventSystem;

    void Start()
    {
        /*
       settingsObj = GameObject.FindGameObjectWithTag("settings");
       confirmMenuObj = GameObject.FindGameObjectWithTag("confirmMainMenu");
       confirmExitObj = GameObject.FindGameObjectWithTag("confirmExit");
       pauseObj = GameObject.FindGameObjectWithTag("PauseButton");
        */
        eventSystem.firstSelectedGameObject = firstMenuButton;
    }

    public void Update()
    {
        bool settingsActive = firstSettingsButton.activeInHierarchy;
        bool confirmMenuActive = firstConfirmMenuButton.activeInHierarchy;
        bool confirmExitActive = firstConfirmExitButton.activeInHierarchy;
        bool pauseActive = firstMenuButton.activeInHierarchy;
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.P))
        {
            if (settingsActive)
            {

                eventSystem.SetSelectedGameObject(firstSettingsButton, new BaseEventData(eventSystem));

            }
            else if (confirmMenuActive)
            {
                eventSystem.SetSelectedGameObject(firstConfirmMenuButton, new BaseEventData(eventSystem));


            }
            else if (confirmExitActive)
            {
                eventSystem.SetSelectedGameObject(firstConfirmExitButton, new BaseEventData(eventSystem));

            }
            else
            {
                eventSystem.SetSelectedGameObject(firstMenuButton, new BaseEventData(eventSystem));
            }
        }
        
    }

        
    
}
