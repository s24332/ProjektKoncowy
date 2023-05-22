using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JezMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;

    public float upForce = 100;
    public float speed = 1500;

    public bool isGrounded = false;


    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    void Start()
    {

    }


    void Update()
    {

        if (isDashing)
        {
            return;
        }


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

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;

        anim.SetBool("IsJump", !isGrounded);

    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = true;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}