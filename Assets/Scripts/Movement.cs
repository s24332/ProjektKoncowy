using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator anim;

    public float upForce = 100;
    public float speed = 1500;
    public float runSpeed = 2500;

    public bool isGrounded = false;
    public bool isJump = false;
    public bool isWalk = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime, rb.velocity.y);
            isWalk = true;
        }
        else 
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, rb.velocity.y);
            isWalk = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * upForce);
            isGrounded = false;
            isJump = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
