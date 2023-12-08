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

    GameObject pausObj;
    GameObject settingsobj;
    GameObject confirmMenuObj;
    GameObject confirmExitObj;

    void Start()
    {
       settingsobj = GameObject.FindGameObjectWithTag("settings");
       confirmMenuObj = GameObject.FindGameObjectWithTag("confirmMainMenu");
       confirmExitObj = GameObject.FindGameObjectWithTag("confirmExit");
       pausObj = GameObject.FindGameObjectWithTag("PauseButton");

        eventSystem.firstSelectedGameObject = firstMenuButton;
    }

    public void Update()
    {
        bool settingsActive = settingsobj.activeInHierarchy;
        bool confirmMenuActive = confirmMenuObj.activeInHierarchy;
        bool confirmExitActive = confirmExitObj.activeInHierarchy;
        bool pauseActive = pausObj.activeInHierarchy;
        
        if (Input.GetKeyDown(KeyCode.Space))
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
            else if (pauseActive)
            {
                eventSystem.SetSelectedGameObject(firstMenuButton, new BaseEventData(eventSystem));
            }
        }
        
    }

        
    
}
