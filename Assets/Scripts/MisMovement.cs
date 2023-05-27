using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MisMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;

    public float upForce = 100;
    public float speed = 1500;

    public bool isGrounded = false;


    void Update()
    {


        float move = Input.GetAxis("Horizontal");
        if (move == 0)
        {
            anim.SetBool("IsWalk", false);

        }
        else
        {
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


            anim.SetFloat("yVelocity", rb.velocity.y);

        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetBool("IsJump", true);
            rb.AddForce(Vector2.up * upForce);
            isGrounded = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;

        anim.SetBool("IsJump", !isGrounded);

    }

}