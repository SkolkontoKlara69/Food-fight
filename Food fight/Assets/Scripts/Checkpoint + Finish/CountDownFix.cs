using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownFix : MonoBehaviour
{
    [SerializeField]
    private float startTime;

    private float timeFromStart;
    private float writenTime;

    public TextMeshPro timeLeftText;  

    // Update is called once per frame
    void Update()
    {
        timeFromStart = Time.deltaTime;
        writenTime = (startTime - timeFromStart);
        timeLeftText.text = writenTime.ToString();
    }
}
