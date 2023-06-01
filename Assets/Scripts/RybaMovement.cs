using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RybaMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveV;
    public float speed = 1500;

    public AudioSource movementSound;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Vector2 moveInput = new Vector2(0, Input.GetAxisRaw("Vertical"));
        moveV = moveInput * speed;
        movementSound.enabled = true;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveV * Time.fixedDeltaTime);
    }
}
