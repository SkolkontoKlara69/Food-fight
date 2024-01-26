using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform playerTransform; 
    public GameObject player; 
    public Transform doorTransform;
    public GameObject door;

    // Start is called before the first frame update
    void Awake()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        playerTransform = player.transform; 
        doorTransform = door.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.x < doorTransform.position.x + 1.5)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
