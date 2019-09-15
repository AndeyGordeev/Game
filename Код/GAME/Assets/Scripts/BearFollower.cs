using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearFollower : MonoBehaviour
{
    private Transform target;
    private bool isFacingRight;
    private Rigidbody2D rigidBody;
    private int amountOfJumpsLeft;
    private bool canJump = true;
    private bool isGrounded;
    private Animator anim;

    public float followSpeed;
    public float followDistance;
    public float jumpForce;
    public int amountOfJumps = 1;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isFacingRight = true;
        amountOfJumpsLeft = amountOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > followDistance) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
        }
        if ((!isFacingRight && transform.position.x < target.position.x) || (isFacingRight && transform.position.x > target.position.x)) {
            Flip();
        }
        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
        CheckIfCanJump();
        UpdateAnimations();
    }

    private void FixedUpdate()
    {
        CheckSurrounding();
    }

    private void CheckSurrounding()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void CheckIfCanJump()
    {
        if (isGrounded && rigidBody.velocity.y <= 0)
        {
            amountOfJumpsLeft = amountOfJumps;
        }

        if (amountOfJumpsLeft <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }

    private void Jump()
    {
        if(canJump)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            amountOfJumpsLeft--;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    
    private void UpdateAnimations()
    {
        anim.SetBool("isGrounded", isGrounded);
    }
}
