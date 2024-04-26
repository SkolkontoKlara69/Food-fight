using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
        
public class VolumeChanger : MonoBehaviour
{
    private Slider slider;
    private float test;
    public AudioMixer mixer;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Audio slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    { 
        mixer.SetFloat("MasterVolume", slider.value);
        
    }

}

