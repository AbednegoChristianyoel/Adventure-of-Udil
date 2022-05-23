using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;

    public float speed = 15f;
    public float horizontalMove = 0f;
    public bool jump = false;
    public bool crouch = false;
    private void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        anim.SetFloat("running", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("jumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLand(){
        anim.SetBool("jumping", false);
    }
    public void OnCrouch(bool isCrouching){
        anim.SetBool("isCrouching", isCrouching);
    }

    private void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;
    }
}