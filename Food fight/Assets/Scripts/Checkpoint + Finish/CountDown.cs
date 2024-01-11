using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    private float startTime;

    private float timeFromStart;
    private float writenTime;

    public TextMesh timeLeftText;
    void Update()
    {
        timeFromStart = Time.deltaTime;
        writenTime = (startTime - timeFromStart);
        timeLeftText.text = writenTime.ToString();
    }
}
