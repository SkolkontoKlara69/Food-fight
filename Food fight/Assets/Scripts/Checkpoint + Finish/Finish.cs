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

    [SerializeField]
    private float duration;

    private void Start()
    {
        movementScript = GameObject.Find("Player (2)").GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.CompareTag("Player"))
        {
            
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
}
