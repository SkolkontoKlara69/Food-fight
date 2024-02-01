using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{

    public bool paused;
    public bool settingsMenu;

    public UnityEvent OnPause;

    public GameObject pauseMenu;
    public GameObject settingsMenuObj;

    private PlayerInput playerInput;

    /// F�r att l�gga in ett villkor i en annan kod f�r att bero p� om spelet �r pausat g�r man s�h�r:
    /// 1. l�gg in: 
    /// public PauseManager pauseManager;
    /// i det script du ska ha l�ngst upp i koden i classen, men utanf�r alla metoder. 
    /// 2. l�gg in pausemanagern scriptet sedan (antingen genom att dra in objektet PausManager i scenen eller genom att l�gga till scriptet dit direkt om det g�r)
    /// 3. skriv en if-sats i den fil du vill ha funktionen som beror p� om det �r pausat och skriv vilkoret:
    /// pauseManager.paused == false
    /// om du vill att allting som �r i if-satsen k�rs n�r spelet inte �r pausat. 
    /// 
    /// KOM VERKLIGEN IH�G ATT L�GGA IN PAUSEMANAGERN I ALLT SOM KAN PAUSAS, ANNARS KOMMER DE INTE ATT FUNGERA ALLS
    /// 
    /// 
    /// 
    /// DOCK BEH�VS DETTA ENDAST F�R SAKER SOM INTE HAR MED TID OCH G�RA, EFTERSOM PAUS-FUNKTIONEN ALLTID G�R S� TIDEN ST�R STILL. D� SLUTAR FYSIKEN ATT R�RA SIG OCH S�DANT.
    /// TROR DOCK ATT GUI FORTFARANDE FUNGERAR EFTERSOM LOOKAROUND SKULLE FUNKA N�R TIDEN ST�R STILL. 
    /// 
    /// 
    /// ALTERNATIVT KAN DU BARA L�GGA IN EN IF-STATS SOM �R if(Time.timeScale == 0) s� �r det samma som om spelet �r pausat. 
   


    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        settingsMenuObj.SetActive(false);

        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.actions["Open&Close Menu"].triggered)
        {
            //Varf�r invokas den inte??????
            OnPause.Invoke();
            paused = !paused;
        }

        if (paused == true)
        {
            Time.timeScale = 0f; // Pausar spelet (tiden)

            //G�r canvasen f�r paus-menyn synlig
            pauseMenu.SetActive(true);

           
            

        }
        else
        {
            Time.timeScale = 1f; // �terupptar spelet (tiden g�r normalt)

            //G�r canvasen f�r paus-menyn osynlig och settings-menyn osynlig
            pauseMenu.SetActive(false);
            settingsMenuObj.SetActive(false);
        }

    }
}
