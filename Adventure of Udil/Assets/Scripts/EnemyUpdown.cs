using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpdown : EnemyManager
{
    public int index = 0;
    public Vector2[] path;
    public float speed = 4;
    public int damage = 25;

    protected override void Start()
    {
        base.Start();
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, path[index], speed * Time.deltaTime);
        if(transform.position.x == path[index].x && transform.position.y == path[index].y){
            index++;

            if(index >= path.Length){
                index = 0;
            }
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