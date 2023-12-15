using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class Finish : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    private float duration;
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("PlayerHasThouchedFinish", true);
            StartCoroutine(Finsish(duration));
        }
    }

    IEnumerator Finsish(float duration)
    {       
        yield return new WaitForSeconds(duration);       
        SceneController.instance.NextLevel();
    }
}
