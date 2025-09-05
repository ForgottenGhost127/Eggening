using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Components")]
    public Rigidbody2D rb;
    public SpriteRenderer spriteRend;
    public GameManager gm;

    [Header("Input")]
    public float moveX;
    #endregion

    #region Unity Callbacks
    void Start()
    {
        InitializeComponents();
    }

    public void Update()
    {
        HandleInput();
        HandleSpriteFlipping();
        HandleJumpInput();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void InitializeComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindWithTag("GameM").GetComponent<GameManager>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void HandleInput()
    {
        moveX = Input.GetAxis("Horizontal");
    }

    private void HandleSpriteFlipping()
    {
        if (moveX < 0)
        {
            spriteRend.flipX = false;
        }
        else if (moveX > 0)
        {
            spriteRend.flipX = true;
        }
    }

    private void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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

    private void HandleMovement()
    {
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
    }
    #endregion


}
