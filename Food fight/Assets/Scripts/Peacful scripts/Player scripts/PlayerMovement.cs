using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    public CapsuleCollider2D capsuleCollider;
    public float velocity;
    public float jumpVelocity;
    private float move;

    public float regularSizeX;
    public float regularSizeY;
    public float crouchingSizeY;

    public Vector2 regularSize;
    public Vector2 crouchingSize;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    public float timeSinceLanding;
    public bool jumpReady;

    public float gravityScale;
    public float fallingGravityScale;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        regularSize = capsuleCollider.size;
        capsuleCollider.size = regularSize;

        crouchingSizeY = regularSizeY / 2;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLanding += Time.deltaTime;

        if (timeSinceLanding >= 1)
        {
            jumpReady = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            capsuleCollider.size = new Vector2(regularSizeX, crouchingSizeY);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            capsuleCollider.size = new Vector2(regularSizeX, regularSizeY);
        }

        move = Input.GetAxis("Horizontal");

        player.velocity = new Vector2(velocity * move, player.velocity.y);

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.W) && isTouchingGround && jumpReady)
        {
            jump();
        }

        if (player.velocity.y > 0)
        {
            player.gravityScale = gravityScale;
        }
        else
        {
            player.gravityScale = gravityScale;
        }
    }

    public void jump()
    {
        player.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
        jumpReady = false;
    }
}
