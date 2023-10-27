using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class If_walk : MonoBehaviour
{
    public Animator animator;
    public Camera camera;
    bool isFacingRigth = true;
    public Rigidbody2D rb;
    public float speed;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") > 0 && !isFacingRigth || isFacingRigth && Input.GetAxisRaw("Horizontal") < 0)
        {
            isFacingRigth = !isFacingRigth;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
        //float player_x = transform.position.x;

        camera.transform.position = new Vector3 (transform.position.x * offset.x,offset.y,offset.z);
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        rb.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * speed,0);
    }
}
