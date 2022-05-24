using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Obstacle : MonoBehaviour
{
    public int damage = 100;
    private void Reset() 
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag=="Player")
        {
            Debug.Log($"{name} Trigger");
            FindObjectOfType<HealthBar>().LoseHealth(damage);
        }
    }
}
