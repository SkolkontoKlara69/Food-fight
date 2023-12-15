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

    public TextMeshPro timeLeftText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeFromStart = Time.deltaTime;
        writenTime = (startTime - timeFromStart);
        timeLeftText.text = writenTime.ToString();
    }
}
