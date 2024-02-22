using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GummiBounce : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D playerRb;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        //playerrb = GameObject.FindGameObjectsWithTag("Player").get
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < 2.1f)
        {
            Debug.Log("TO SPACE!!!!!!");
            //playerRb.velocity = new Vector2(5000000000, 3);
            playerRb.AddForce(new Vector2(-force, 10));
        }
    }
}
