using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_walking : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float movmentSpeed;
    public int destination;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    private void Awake()
    {
        GameObject player = GameObject.Find ("Player (2)");
        Transform playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {   
        if (isChasing)
        {
            if(transform.position.x > playerTransform.position.x)
            {
                transform.position += Vector3.left * movmentSpeed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.position += Vector3.right * movmentSpeed * Time.deltaTime;
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
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, movmentSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    destination = 1;
                }
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
    }
}
