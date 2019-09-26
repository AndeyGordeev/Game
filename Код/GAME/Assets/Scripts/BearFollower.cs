using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearFollower : MonoBehaviour
{
    private float movementInputDirection;
    private float attackTimer;

    private int amountOfJumpsLeft;

    private bool isWalking;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isWallSliding;
    private bool canJump = true;
    private bool movementBlock = false;

    private Rigidbody2D rb;
    private Animator anim;
    private Play player;

    private GameObject hud;

    public int amountOfJumps = 1;

    public bool isFacingRight = true;
    public float movementSpeed = 10.0f;
    public float jumpForce = 16.0f;
    public float groundCheckRadius;
    public float wallCheckDistance;
    public float wallSlideSpeed;
    public float health = 100f;
    public int fallBoundary = -20; //граница падения по оси Y
    public bool isAttacking = false;

    public Transform groundCheck;
    public Transform wallCheck;
    public GameObject attackHitBox;

    public LayerMask whatIsGround;

    public int curHealth;
    public int maxHealth = 4;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        amountOfJumpsLeft = amountOfJumps;
        hud = GameObject.FindGameObjectWithTag("HUDbear");
        UpdateHealth();
        curHealth = maxHealth;
        attackHitBox.SetActive(false);
        player = FindObjectOfType<Play>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        UpdateAnimations();
        CheckIfWallSliding();
        IfFellDown();
        CheckVelocity();
        if (!movementBlock)
        {
            CheckIfCanJump();
            CheckMovementDirection();
        }
        Attack();
    }

    private void FixedUpdate()
    {
        if (!movementBlock)
        {
            ApplyMovement();
        }
        CheckSurrounding();
        if (isGrounded && movementBlock)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void CheckIfWallSliding()
    {
        if (isTouchingWall && !isGrounded && rb.velocity.y < 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void CheckVelocity()
    {
        if (Mathf.Abs(rb.velocity.x) < movementSpeed)
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }
    }

    private void CheckSurrounding()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
    }

    private void CheckIfCanJump()
    {
        if (isGrounded && rb.velocity.y <= 0)
        {
            canJump = true;
            amountOfJumpsLeft = amountOfJumps;
        }
        if (amountOfJumpsLeft <= 0)
        {
            canJump = false;
        }
    }

    private void CheckMovementDirection()
    {
        if (isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if (!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }

        if (rb.velocity.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isAttacking", isAttacking);
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("CompanionMovementBlock"))
        {
            if (movementBlock)
            {
                movementBlock = false;
            }
            else {
                movementBlock = true;
                canJump = false;
            }
        }

        if (Input.GetButtonDown("CompanionTeleport"))
        {
            if (player.isFacingRight)
            {
                transform.position = new Vector3(player.transform.position.x + 2, transform.position.y, transform.position.z);
                if (!isFacingRight) Flip();
                isFacingRight = true;
                
            }
            else
            {
                transform.position = new Vector3(player.transform.position.x - 2, transform.position.y, transform.position.z);
                if (isFacingRight) Flip();
                isFacingRight = false;
            }
            
            movementBlock = false;
        }
    }

    private void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            amountOfJumpsLeft--;
        }
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);

        if (isWallSliding)
        {
            if (rb.velocity.y < -wallSlideSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, wallSlideSpeed);
            }
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }

    public void DamagePlayer(float damage)
    {
        health -= damage;
        UpdateHealth();
        if (health <= 0)
        {
            GameMaster.KillBear(this.gameObject);
        }
    }

    private void IfFellDown()
    {
        if (transform.position.y <= fallBoundary) DamagePlayer(health);
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Coin")
        {
            GameMaster.Gm.Score++;
            Destroy(obj.gameObject);
        }
    }

    public void UpdateHealth()
    {
        hud.GetComponent<Animator>().SetFloat("Health", health);
    }
    
    private void Attack()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;

            int index = Random.Range(1, 4);
            anim.Play("BearAttack" + index);

            StartCoroutine(DoAttack());
        }
    }

    IEnumerator DoAttack()
    {
        attackHitBox.SetActive(true);
        yield return new WaitForSeconds(.5f);
        attackHitBox.SetActive(false);
        isAttacking = false;
    }
    
}
