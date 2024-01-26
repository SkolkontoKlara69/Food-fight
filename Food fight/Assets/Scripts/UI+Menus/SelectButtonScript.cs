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
        bool confirmMenuActive = ItemActive(firstConfirmMenuButton);
        bool confirmExitActive = ItemActive(firstConfirmExitButton);
        bool pauseActive = ItemActive(firstMenuButton);
        bool inventoryActive = ItemActive(firstInventoryButton);
        
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.P))
        {
            if (settingsActive && firstSettingsButton != null)
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
        
    
}
