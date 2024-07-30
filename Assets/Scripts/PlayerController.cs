using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public Rigidbody2D rb;
    public float moveX;

    
    public GameManager gm;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindWithTag("GameM").GetComponent<GameManager>();

    }

    public void Update()
    {
        moveX = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.velocity = new Vector2(rb.velocity.x, 10);
            gm.activeBarra();

            Debug.Log("Salto Activado");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
            }
            
            gm.DetenBarra();
            
        }
    }


    void FixedUpdate()
    {
       
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        
        
    }

    
}
