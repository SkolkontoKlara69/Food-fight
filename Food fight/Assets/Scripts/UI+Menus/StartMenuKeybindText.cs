using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartMenuKeybindText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Text movementKeys;
    public Text hitKey;
    public Text pauseKey;
    public Text inventoryKey;

    // Update is called once per frame
    void Update()
    { 
        text.text = movementKeys.text + " - movement " + hitKey.text.Substring(13) + " - hit    " + pauseKey.text + " - pause          " + inventoryKey.text + " - inventory";
    }
}
