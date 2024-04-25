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
    public GameObject firstInventoryButton;
    public GameObject firstRebindButton;
    public GameObject firstAudioButton;
    public GameObject firstMovementButton;
    GameObject[] pauseButtons;
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

        pauseButtons = GameObject.FindGameObjectsWithTag("PauseButton");
    }

    public void Update()
    {
        bool settingsActive = ItemActive(firstSettingsButton);
        bool rebindSettingsActive = ItemActive(firstRebindButton);
        bool audioSettingsActive = ItemActive(firstAudioButton);
        bool movementSettingsActive = ItemActive(firstMovementButton);
        bool confirmMenuActive = ItemActive(firstConfirmMenuButton);
        bool confirmExitActive = ItemActive(firstConfirmExitButton);
        bool pauseActive = ItemActive(firstMenuButton);
        bool inventoryActive = ItemActive(firstInventoryButton);
        
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.I))
        { 
            if (audioSettingsActive && firstAudioButton != null)
            {                                                                  

                eventSystem.SetSelectedGameObject(firstAudioButton, new BaseEventData(eventSystem));

            }
            else if (movementSettingsActive && firstMovementButton != null)
            {

                eventSystem.SetSelectedGameObject(firstMovementButton, new BaseEventData(eventSystem));

            }
            else if (rebindSettingsActive && firstRebindButton != null)
            {

                eventSystem.SetSelectedGameObject(firstRebindButton, new BaseEventData(eventSystem));

            }else if (settingsActive && firstSettingsButton != null && !rebindSettingsActive && !movementSettingsActive && !audioSettingsActive)
            {

                eventSystem.SetSelectedGameObject(firstSettingsButton, new BaseEventData(eventSystem));

            }
            else if (confirmMenuActive && firstConfirmMenuButton != null)
            {
                eventSystem.SetSelectedGameObject(firstConfirmMenuButton, new BaseEventData(eventSystem));


            }
            else if (confirmExitActive && firstConfirmExitButton != null)
            {
                eventSystem.SetSelectedGameObject(firstConfirmExitButton, new BaseEventData(eventSystem));

            }else if (inventoryActive && firstInventoryButton != null)
            {
                eventSystem.SetSelectedGameObject(firstInventoryButton, new BaseEventData(eventSystem));
            }
            else
            {
                eventSystem.SetSelectedGameObject(firstMenuButton, new BaseEventData(eventSystem));
                
                for (int i = 0; i < pauseButtons.Length; i++)
                {
                    pauseButtons[i].SetActive(true);
                }
            }
        }
        
    }

    private bool ItemActive(GameObject firstButton)
    {
        if (firstButton != null)
        {
            return firstButton.activeInHierarchy;
        }
        else
        {
            return false;
        }
    }
        
    
    public void OnRebind()
    {
        eventSystem.SetSelectedGameObject(null);
    }
}
