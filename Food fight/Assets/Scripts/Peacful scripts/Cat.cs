using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    private GameObject player;
    public Rigidbody2D rb;
    private Vector3 playerX;
    private Vector3 offest;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offest = new Vector3(5, -2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.localScale.x > 0)
        {
            offest = new Vector3(5, -2, 0);
        }
        else
        {
            offest = new Vector3(-5, -2, 0);
        }
        playerX = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, playerX - offest, 1f);
    }
}
