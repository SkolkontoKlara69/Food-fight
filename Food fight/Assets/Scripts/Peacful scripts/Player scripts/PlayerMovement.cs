using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

    public bool isCrouched;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public bool isTouchingGround;
    public bool standingOnEnemies;

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

    private GameObject playerStatManager;
    private float speedFromEquipment;

    public bool paused;



    private PlayerInput playerInput;

    public bool jumpReady;

    public bool doubleJumpEnabled = true;

    public float jumpsRemaining;

    [Header("Toggle crouch")]
    public bool toggleCrouch;
    public bool isCrouching;
    public Toggle crouchToggle;

    [Header("Audio controls")]
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip doubleJumpSound;

    [Header("Toggle jump")]
    public bool toggleJump;
    public bool isJumping;
    public Toggle jumpToggle;

    [Header("Toggle walk")]
    public bool toggleWalk;
    public bool isWalkingRight;
    public bool isWalkingLeft;
    public Toggle walkToggle;


    public Animator animator;


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

        if (GameObject.Find("PlayerStatManager") != null)
        {
            playerStatManager = GameObject.Find("PlayerStatManager");
        }

        playerInput = GetComponent<PlayerInput>();

        jumpReady = true;

        animator = gameObject.GetComponent<Animator>();


        toggleCrouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (doubleJumpEnabled && standingOnEnemies)
        {
            jumpsRemaining = 1;
        }

        paused = GameObject.FindGameObjectWithTag("PauseManager").GetComponent<PauseManager>().paused;

        if (playerStatManager != null)
        {
            speedFromEquipment = playerStatManager.GetComponent<PlayerStats>().speed;
        }

        /* if(transform.position.y >= 5f)
         {
             while (camera.transform.position.y != transform.position.y)
                 cameraY++;
                 camera.transform.position = new Vector3(transform.position.x * cameraOffset.x + 6.37f, cameraY, cameraOffset.z);
         }
         else
             camera.transform.position = new Vector3(transform.position.x * cameraOffset.x + 6.37f, 3.28f, cameraOffset.z);
        */


        Vector2 moveInput = playerInput.actions["Move"].ReadValue<Vector2>();

        //Om det är toggle crouch så ändrar den bara om man crouchar eller inte. Om man istället inte har toggle crouch så crouchar den bara ifall man trycker på knappen
        if (toggleCrouch == true)
        {
            if (moveInput.y < 0.0f && !paused)
            {
                isCrouched = !isCrouched;
            }

        }
        else if (moveInput.y < 0.0f && !paused)
        {
            isCrouched = true;

        }
        else //om vi vill att det ska vara toggle-crouch istället så lägg till if(moveInput.y > 0.0f && !paused) här
        {
            isCrouched = false;
        }

        animator.SetBool("IsCrouching", isCrouched);

        //för att spriten ska kunna offsettas: 
        //offsetta spelarens och colliderns position uppåt till dit spriten är (kanske fungerar)
        //eller:
        //sätt spriten till ett child och offsetta childet (kanske fungerar)
        //eller:
        //ta bort offsetten på collidern och offsetta hela spelarens position istället för att undvika att spelaren faller ner en liten bit när den crouchar (kanske fungerar)

        if (isCrouched)
        {
            capsuleCollider.size = new Vector2(regularSizeX, crouchingSizeY);
            velocity = 5 + (speedFromEquipment - 10);
            jumpVelocity = 20;
            capsuleCollider.offset = new Vector2(0, -0.27f);
            spriteRenderer.sprite = crouched;
        }
        else
        {
            capsuleCollider.size = new Vector2(regularSizeX, regularSizeY);
            velocity = 10 + (speedFromEquipment - 10);
            jumpVelocity = 20;
            capsuleCollider.offset = new Vector2(0, -0.12f);
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

        animator.SetBool("IsTouchingRoof", isTouchingRoof);

        if (isTouchingRoof)
        {
            capsuleCollider.offset = new Vector2(0, -0.27f);
            capsuleCollider.size = new Vector2(regularSizeX, crouchingSizeY);
            spriteRenderer.sprite = crouched;
            velocity = 5;
        }

        if (moveInput.x > 0 && !isFacingRight && !paused || isFacingRight && moveInput.x < 0 && !paused)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
        
        if (toggleWalk == true)
        {
            if (moveInput.x > 0 && isWalkingRight == false) //Ifall man trycker höger och inte redan går åt höger så ska man börja gå åt höger
            {
                isWalkingRight = true;
                isWalkingLeft = false;

            }
            else if (moveInput.x < 0 && isWalkingLeft == false) //Ifall man trycker vänster och inte redan går åt vänster, så ska man börja gå åt vänster
            {
                isWalkingRight = false;
                isWalkingLeft = true;
            }
            else if (moveInput.x > 0 && isWalkingRight == true) //Ifall man trycker höger och redan går åt höger så slutar man gå åt höger, samma sak med den vänstra
            {
                isWalkingRight = false;
                isWalkingLeft = false;
            }


            if (isWalkingLeft == true && isWalkingRight == false)
            {
                move = -1;
            }else if (isWalkingRight && !isWalkingLeft)
            {
                move = 1;
            }
            else
            {
                move = 0;
            }
        }
        else //Säger vilket håll eller om den ska gå överhuvudtaget, för vanlig walking utan toggle
        {
            move = moveInput.x;
        }


        

        //Gör så att spelaren går
        player.velocity = new Vector2(velocity * move, player.velocity.y);

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        standingOnEnemies = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, enemyLayer);

        if (!doubleJumpEnabled)
        {
            if (moveInput.y > 0.0f && jumpReady == true && isTouchingGround && !isTouchingRoof && !paused || jumpReady == true && moveInput.y > 0.0f && standingOnEnemies && !isTouchingRoof && !paused)
            {
                audioSource.clip = jumpSound;
                audioSource.Play();
                jump();
                StartCoroutine(JumpCooldown());
            }
        }

        if (doubleJumpEnabled)
        {
            if(moveInput.y > 0.0f && jumpReady && isTouchingGround && !isTouchingRoof && !paused || moveInput.y > 0.0f && jumpReady && standingOnEnemies && isTouchingRoof && !paused)
            {
                audioSource.clip = jumpSound;
                audioSource.Play();
                jump(); 
                StartCoroutine(DoubleJumpCooldown()); 
            }

            if(moveInput.y > 0.0f && !paused && !isTouchingRoof && jumpsRemaining == 1 && jumpReady || moveInput.y > 0.0f && !paused && standingOnEnemies && jumpsRemaining == 1 && jumpReady)
            {
                audioSource.clip = doubleJumpSound;
                audioSource.Play();
                jump(); 
                StartCoroutine(JumpCooldown()); 
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.W) && isTouchingGround && !isTouchingRoof && !paused || Input.GetKeyDown(KeyCode.UpArrow) && isTouchingGround && !isTouchingRoof && !paused)
        {
            jump();
        }

        if (Input.GetKeyDown(KeyCode.W) && standingOnEnemies && !isTouchingRoof && !paused || Input.GetKeyDown(KeyCode.UpArrow) && standingOnEnemies && !isTouchingRoof && !paused)
        {
            jump();
        }
        */

        if (player.velocity.y > 0)     
            player.gravityScale = gravityScale;        
        else        
            player.gravityScale = gravityScale;        
    }

    public void jump()
    {
        player.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
    }

    private IEnumerator DoubleJumpCooldown()
    {
        jumpReady = false;
        jumpsRemaining = 1;
        yield return new WaitForSeconds(0.25f);
        jumpReady = true;
    }

    private IEnumerator JumpCooldown()
    {
        jumpReady = false;
        jumpsRemaining = 0;
        yield return new WaitForSeconds(0.3f);
        jumpReady = true;
        jumpsRemaining = 2;
    }

    public void UpdateToggleCrouch(bool toggleValue)
    {
        toggleCrouch = toggleValue;
    }

    public void UpdateToggleJump(bool toggleValue)
    {
        toggleJump = toggleValue;
    }

    public void UpdateToggleWalk(bool toggleValue)
    {
        toggleWalk = toggleValue;
    }
}
