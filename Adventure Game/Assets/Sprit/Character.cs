using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private float moveController;
    private bool jumpController;
    private bool Running;
    private bool Jumping;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        moveController = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * moveController, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        Running = moveController != 0;
        anim.SetBool("Running", Running);
        if (rb.velocity.x>0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (rb.velocity.x<0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (rb.velocity.y>0.3f)
        {
            Jumping = true;
        }
        else
        {
            Jumping = false;
        }
        anim.SetBool("Jump", Jumping);
    }
}