using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpdown : MonoBehaviour
{
    public int index = 0;
    public Vector2[] path;
    public float speed = 4;

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, path[index], speed * Time.deltaTime);
        if(transform.position.x == path[index].x && transform.position.y == path[index].y){
            index++;

            if(index >= path.Length){
                index = 0;
            }
        }   
    }
}