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

    public TextMeshProUGUI timeLeftText;

    private void Start()
    {
        writenTime = startTime;        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeFromStart += 0.019f;
        writenTime = startTime - Mathf.RoundToInt(timeFromStart);
        timeLeftText.text = writenTime.ToString();
    }
}
