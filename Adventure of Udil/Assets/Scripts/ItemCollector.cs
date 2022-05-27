using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int Diamond = 0;
    public bool Kunci = false;
    public AudioSource coinSound;
    public AudioSource KunciSound;
    [SerializeField] private TextMeshProUGUI diamondcount;
    [SerializeField] private TextMeshProUGUI kunci;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Collectible")){
            Destroy(collision.gameObject);
            Diamond++;
            coinSound.Play();
            diamondcount.text = "x " + Diamond;
        }else if(collision.gameObject.CompareTag("Kunci")){
            Destroy(collision.gameObject);
            Kunci = true;
            KunciSound.Play();
            Debug.Log(Kunci);
            kunci.text = "<sprite=0>";
        }
    }

}
