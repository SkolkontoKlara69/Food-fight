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

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            capsuleCollider.size = new Vector2(regularSizeX, crouchingSizeY);
            velocity = 2;
            jumpVelocity = 10;
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            capsuleCollider.size = new Vector2(regularSizeX, regularSizeY);
            velocity = 5;
            jumpVelocity = 15;
        }

        move = Input.GetAxis("Horizontal");

        player.velocity = new Vector2(velocity * move, player.velocity.y);

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.W) && isTouchingGround || Input.GetKeyDown(KeyCode.UpArrow) && isTouchingGround)
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
    }
}
