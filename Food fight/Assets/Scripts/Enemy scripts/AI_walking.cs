using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_walking : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float movmentSpeed;
    public int destination;
    private bool leftOfEnemy = false;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    public GameObject player;

    private void Awake()
    {
        /*GameObject player = GameObject.Find ("Player");
        Transform playerTransform = player.transform;*/

        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        playerTransform = player.transform; 
    }

    // Update is called once per frame
    void Update()
    {   
        if (isChasing)
        {
            if(transform.position.x > playerTransform.position.x)
            {
                transform.position += Vector3.left * movmentSpeed * Time.deltaTime;
                /* if(this.transform.localScale.y < 15)
                 {
                     this.transform.localScale = new Vector3(10.434f, 10.434f, 10.434f);
                 }
                 else
                 {
                     this.transform.localScale = new Vector3(15, 15, 15);
                 }*/
                if (leftOfEnemy)
                {
                    this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
                    leftOfEnemy = false;
                }
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.position += Vector3.right * movmentSpeed * Time.deltaTime;
                /*if (this.transform.localScale.y < 15)
                {
                    this.transform.localScale = new Vector3(-10.434f, 10.434f, 10.434f);
                }
                else
                {
                    this.transform.localScale = new Vector3(-15, 15, 15);
                }*/
                if (!leftOfEnemy)
                {
                    leftOfEnemy = true;
                    this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
                }
                
            }
        }
        else
        {
            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }
            

            if (destination == 0)
            {
                //transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, movmentSpeed * Time.deltaTime);
                /*if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    destination = 1;
                }*/
            }
            if (destination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, movmentSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    destination = 0;
                }
            }
        }

        if (Vector2.Distance(transform.position, playerTransform.position) > chaseDistance)
        {
            isChasing = false;
        }
    }
}
