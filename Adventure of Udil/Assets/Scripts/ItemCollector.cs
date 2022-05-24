using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int Diamond = 0;
    [SerializeField] private TextMeshProUGUI diamondcount;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Collectible")){
            Destroy(collision.gameObject);
            Diamond++;
            diamondcount.text = "x " + Diamond;
        }
    }

}
