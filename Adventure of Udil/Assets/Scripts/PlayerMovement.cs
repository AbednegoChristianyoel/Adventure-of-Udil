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
    public bool falling = false;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;
    public AudioSource KillSound;
    public AudioSource HurtSound;
    public AudioSource JumpSound;
    [SerializeField] private float hurtforce = 10f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        EnemyManager em = other.gameObject.GetComponent<EnemyManager>();
        if(other.gameObject.tag == "Enemy"){
            if (falling == true){
                em.JumpOn();
                KillSound.Play();
                Jump();
                Debug.Log("mati");
            }else{
                sr.material = matWhite;
                Debug.Log("hidup");
                if(other.gameObject.transform.position.x > transform.position.x){
                    rb.velocity = new Vector2(-hurtforce, rb.velocity.y);
                }else{
                    rb.velocity = new Vector2(hurtforce, rb.velocity.y);
                }
                Invoke("ResetMaterial", .2f);
                HurtSound.Play();
            } 
        }
    }

    void ResetMaterial(){
        sr.material = matDefault;
    }
    private void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        anim.SetFloat("running", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("jumping", true);
            falling = true;
            JumpSound.Play();
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if(!controller.m_Grounded){
            anim.SetBool("jumping", true);
            
        }else if(controller.m_Grounded){
            anim.SetBool("jumping", false);
        }

        anim.SetFloat("y_velocity", rb.velocity.y);
    }

    public void OnLand(){
        anim.SetBool("jumping", false);
        falling = false;
    }
    public void OnCrouch(bool isCrouching){
        anim.SetBool("isCrouching", isCrouching);
    }

    private void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        anim.SetBool("jumping", true);
    }
}