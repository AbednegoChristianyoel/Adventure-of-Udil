using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    public Image fillBar;
    public float health;

    public void LoseHealth(int value)
    {
        if (health <= 0)
        {
            return; // ga ngapa-ngapain
        }
        // Kurangin darah
        health -= value;

        // Refresh UI health fill bar
        fillBar.fillAmount = health / 100;

        // Cek kalo darah <= 0 ~> Mati
        if (health <= 0)
        {
            // Debug.Log("Died");
            FindObjectOfType<LevelManager>().Restart();
        }
    }
}
