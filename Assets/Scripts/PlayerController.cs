using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public Rigidbody2D rb;
    private float moveX;

    private bool isGrounded;
    private bool isJumping;

    public GameManager jumpTracker;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    public void Update()
    {
        moveX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            jumpTracker.ActivateScrollbar();
            print("Está saltando");
        }
    }


    void FixedUpdate()
    {
       
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if(isJumping)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
            jumpTracker.DeactivateScrollbar();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = false;
        }
    }
}
