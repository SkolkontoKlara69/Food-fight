using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSpawnScript : MonoBehaviour
{
    private GameObject player;
    private Transform playerTranform;
    private void Awake()
    {
        playerTranform.position = new Vector3(0, 0, -10);
        player = GameObject.FindWithTag("Player");
        player.transform.position = playerTranform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
