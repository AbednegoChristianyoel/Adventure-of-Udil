using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : EnemyManager
{
    [HideInInspector] 
    public bool patrollingEnemy;
    private bool mustFlip;

    public float enemySpeed;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public int damage = 25;

 
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        patrollingEnemy = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(patrollingEnemy)
        {
            Patrol();
        }
    }

    private void FixedUpdate() 
    {
        if(patrollingEnemy)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustFlip || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }

        rb.velocity = new Vector2(-enemySpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag=="Player")
        {
            Debug.Log($"{name} Triggered");
            FindObjectOfType<HealthBar>().LoseHealth(damage);
        }
    }

    void Flip()
    {
        patrollingEnemy = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        enemySpeed *= -1;
        patrollingEnemy = true;
    }
}
