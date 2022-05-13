using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [HideInInspector] 
    public bool patrollingEnemy;
    private bool mustFlip;

    public float enemySpeed;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;

    // Start is called before the first frame update
    void Start()
    {
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

    void Flip()
    {
        patrollingEnemy = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        enemySpeed *= -1;
        patrollingEnemy = true;
    }

}
