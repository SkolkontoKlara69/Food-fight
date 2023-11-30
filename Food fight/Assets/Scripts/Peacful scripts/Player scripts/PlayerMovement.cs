using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    public CapsuleCollider2D capsuleCollider;
    public float velocity;
    public float jumpVelocity;
    private float move;

    bool isFacingRight = true;

    public float regularSizeX;
    public float regularSizeY;
    public float crouchingSizeY;

    public Vector2 regularSize;
    public Vector2 crouchingSize;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;

    public Transform roofCheck1;
    public Transform roofCheck2;
    public bool isTouchingRoof;
    public LayerMask roofCheckLayer;

    public float gravityScale;
    public float fallingGravityScale;

    public Camera camera;
    public Vector3 cameraOffset;
    public float cameraY;

    public SpriteRenderer spriteRenderer;
    public Sprite idle;
    public Sprite crouched;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        regularSize = capsuleCollider.size;
        capsuleCollider.size = regularSize;

        crouchingSizeY = regularSizeY / 2;

        camera = Camera.main;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        cameraY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
       /* if(transform.position.y >= 5f)
        {
            while (camera.transform.position.y != transform.position.y)
                cameraY++;
                camera.transform.position = new Vector3(transform.position.x * cameraOffset.x + 6.37f, cameraY, cameraOffset.z);
        }
        else
            camera.transform.position = new Vector3(transform.position.x * cameraOffset.x + 6.37f, 3.28f, cameraOffset.z);
       */
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            capsuleCollider.size = new Vector2(regularSizeX, crouchingSizeY);
            velocity = 5;
            jumpVelocity = 20;
            capsuleCollider.offset = new Vector2(0, -0.14f);
            spriteRenderer.sprite = crouched;
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            capsuleCollider.size = new Vector2(regularSizeX, regularSizeY);
            velocity = 10;
            jumpVelocity = 20;
            capsuleCollider.offset = new Vector2(0, 0);
            spriteRenderer.sprite = idle;
        }

        if(Physics2D.OverlapArea(roofCheck1.position, roofCheck2.position, groundLayer) && isTouchingGround)
        {
            isTouchingRoof = true;
        }
        else
        {
            isTouchingRoof = false;
        }

        if (isTouchingRoof)
        {
            capsuleCollider.offset = new Vector2(0, -0.14f);
            capsuleCollider.size = new Vector2(regularSizeX, crouchingSizeY);
        }
        else if (!isTouchingGround)
        {
            capsuleCollider.size = new Vector2(regularSizeX, regularSizeY);
            capsuleCollider.offset = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") > 0 && !isFacingRight || isFacingRight && Input.GetAxisRaw("Horizontal") < 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        move = Input.GetAxis("Horizontal");

        player.velocity = new Vector2(velocity * move, player.velocity.y);

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); 

        if (Input.GetKeyDown(KeyCode.W) && isTouchingGround || Input.GetKeyDown(KeyCode.UpArrow) && isTouchingGround)        
            jump();        

        if (player.velocity.y > 0)        
            player.gravityScale = gravityScale;        
        else        
            player.gravityScale = gravityScale;        
    }

    public void jump()
    {
        player.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse); 
    }
}
