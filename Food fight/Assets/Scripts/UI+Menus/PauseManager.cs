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

    /// För att lägga in ett villkor i en annan kod för att bero på om spelet är pausat gör man såhär:
    /// 1. lägg in: 
    /// public PauseManager pauseManager;
    /// i det script du ska ha längst upp i koden i classen, men utanför alla metoder. 
    /// 2. lägg in pausemanagern scriptet sedan (antingen genom att dra in objektet PausManager i scenen eller genom att lägga till scriptet dit direkt om det går)
    /// 3. skriv en if-sats i den fil du vill ha funktionen som beror på om det är pausat och skriv vilkoret:
    /// pauseManager.paused == false
    /// om du vill att allting som är i if-satsen körs när spelet inte är pausat. 
    /// 
    /// KOM VERKLIGEN IHÅG ATT LÄGGA IN PAUSEMANAGERN I ALLT SOM KAN PAUSAS, ANNARS KOMMER DE INTE ATT FUNGERA ALLS
    /// 
    /// 
    /// 
    /// DOCK BEHÖVS DETTA ENDAST FÖR SAKER SOM INTE HAR MED TID OCH GÖRA, EFTERSOM PAUS-FUNKTIONEN ALLTID GÖR SÅ TIDEN STÅR STILL. DÅ SLUTAR FYSIKEN ATT RÖRA SIG OCH SÅDANT.
    /// TROR DOCK ATT GUI FORTFARANDE FUNGERAR EFTERSOM LOOKAROUND SKULLE FUNKA NÄR TIDEN STÅR STILL. 
    /// 
    /// 
    /// ALTERNATIVT KAN DU BARA LÄGGA IN EN IF-STATS SOM ÄR if(Time.timeScale == 0) så är det samma som om spelet är pausat. 
   


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
            //Varför invokas den inte??????
            OnPause.Invoke();
            paused = !paused;
        }

        if (paused == true)
        {
            Time.timeScale = 0f; // Pausar spelet (tiden)

            //Gör canvasen för paus-menyn synlig
            pauseMenu.SetActive(true);

           
            

        }
        else
        {
            Time.timeScale = 1f; // Återupptar spelet (tiden går normalt)

            //Gör canvasen för paus-menyn osynlig och settings-menyn osynlig
            pauseMenu.SetActive(false);
            settingsMenuObj.SetActive(false);
        }

    }
}
