using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    protected Animator anim;

    protected virtual void Start() {
        anim = GetComponent<Animator>();
    }

    public void JumpOn(){
        anim.SetTrigger("death");
    }

    public void Death(){
        Destroy(this.gameObject);
    }
    
}
