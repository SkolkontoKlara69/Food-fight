using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class Finish : MonoBehaviour
{
    public Animator animator;
    public GameObject finnishCanvas;
    public PlayerMovement movementScript;

    public Rigidbody2D rb2d;

    [SerializeField]
    private float duration;
  
    private float waitingTime = 2;

    private bool compleet = false;
    private void Start()
    {
        
        movementScript = GameObject.Find("Player (2)").GetComponent<PlayerMovement>();        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.CompareTag("Player"))
        {
            compleet = true;
            animator.SetBool("PlayerHasThouchedFinish", true);
            StartCoroutine(Finsish(duration));
            finnishCanvas.SetActive(true);
        }
    }

    IEnumerator Finsish(float duration)
    {       
        yield return new WaitForSeconds(duration);
        SceneController.instance.NextLevel();
    }

    private void Update()
    {
        if(compleet == true)
        {
            movementScript.enabled = !movementScript.enabled;
            rb2d.velocity = new Vector2(0, 0);
            compleet = false;
        }
    }
}
