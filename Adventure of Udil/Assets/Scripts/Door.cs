using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    SpriteRenderer sr;
    private Material BlackMamba;
    private Material matDefault;
    public ItemCollector item;
    public AudioSource doorsound;

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        BlackMamba = Resources.Load("BlackMamba", typeof(Material)) as Material;
        matDefault = sr.material;
    }
    

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.tag=="Player"){
            if(Input.GetAxisRaw("Crouch") == 1 && item.Kunci){
                sr.material = BlackMamba;
                doorsound.Play();
                Debug.Log("lele");
            }
        }
    }
}
