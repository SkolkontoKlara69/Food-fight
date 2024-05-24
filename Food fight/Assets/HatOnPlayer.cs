using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatOnPlayer : MonoBehaviour
{
    public Sprite test;
    SpriteRenderer hatt;
    Image Script;
    // Start is called before the first frame 
    void Start()
    {
        
        hatt = GameObject.Find("Hatt").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UppdateHatt()
    {
        Script = GameObject.Find("HattEquipmentImage").GetComponent<Image>();
        hatt.sprite = Script.sprite;

    }
}
