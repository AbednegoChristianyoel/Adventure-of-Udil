using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumping : EnemyManager
{
    public bool faceRight = false;
    public LayerMask whatIsGround;

    public bool isGrounded = false;
    public bool isFalling = false;
    public bool isJumping = false;

    public float jumpForceX = 2f;
    public float jumpForceY = 4f;

    public float lastYPos = 0;

    public enum Animations
    {
        Idle = 0,
        Jumping = 1,
        Falling = 2
    };

    public Animations currentAnim;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    public float idleTime = 2f;
    public float currentIdleTime = 0;
    public bool isIdle = true;
    public int damage = 25;
    
    protected override void Start()
    {
        base.Start();
        lastYPos = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(isIdle)
        {
            currentIdleTime += Time.deltaTime;
            if (currentIdleTime >= idleTime)
            {
                currentIdleTime = 0;
                
                faceRight = !faceRight;
                spriteRenderer.flipX = faceRight;
                Jump();
            }
        }

        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.7f, transform.position.y - 0.9f),
        new Vector2(transform.position.x + 0.7f, transform.position.y - 0.91f), whatIsGround);

        if (isGrounded && isFalling)
        {
            isFalling = false;
            isJumping = false;
            isIdle = true;
            ChangeAnimation(Animations.Idle);
        }
        else if (transform.position.y > lastYPos && !isGrounded && !isIdle)
        {
            isJumping = true;
            isFalling = false;
            ChangeAnimation(Animations.Jumping);
        }
        else if (transform.position.y < lastYPos && !isGrounded && !isIdle)
        {
            isJumping = false;
            isFalling = true;
            ChangeAnimation(Animations.Falling);
        }

        lastYPos = transform.position.y;
    }

    void Jump()
    {
        isJumping = true;
        isIdle = false;
        int direction = 0;

        if (faceRight)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        rb.velocity = new Vector2(jumpForceX * direction, jumpForceY);
    }

    void ChangeAnimation(Animations newAnim){
        if (currentAnim != newAnim){
            currentAnim = newAnim;
            anim.SetInteger("kondisi", (int)newAnim);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag=="Player")
        {
            Debug.Log($"{name} Triggered");
            FindObjectOfType<HealthBar>().LoseHealth(damage);
        }
    }
}
