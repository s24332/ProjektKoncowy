using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JezMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    
    public float upForce = 300;
    public float speed = 1500;
   
    public bool isGrounded = false;

    public bool isDashing;

    public float DashForce;
    public float StartDashTime;

    private float CurrentDashTimer;
    private float DashDirection;

    public AudioSource movementSound;

    void Start()
    {
        
    }


    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (move == 0)
        {
            anim.SetBool("IsWalk", false);
            anim.SetBool("IsDash", false);
            movementSound.enabled = false;

        }
        else
        {
            movementSound.enabled = true;
            if (move > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (move < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            anim.SetBool("IsWalk", true);
            rb.velocity = new Vector2(move * speed * Time.deltaTime, rb.velocity.y);

        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * upForce);
            isGrounded = false;
            movementSound.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && move != 0)
        {
            anim.SetBool("IsDash", true);
            isDashing = true;
            CurrentDashTimer = StartDashTime;
            rb.velocity = Vector2.zero;
            DashDirection = (int)move;

        }

        if (isDashing)
        {
            rb.velocity = transform.right * DashDirection * DashForce;

            CurrentDashTimer -= Time.deltaTime;
            if (CurrentDashTimer <= 0)
            {
                isDashing = false;
                anim.SetBool("IsDash", false);
            }
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;

        anim.SetBool("IsJump", !isGrounded);

    }

   

}