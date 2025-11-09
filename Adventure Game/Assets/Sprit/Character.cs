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
    private bool isGround;
    public bool isJumping;
    private bool doubleJump;
    public AudioSource jumpSound;
    public AudioSource runSound;
    [SerializeField]private float jumpAddTime;
    [SerializeField]private float jumpAddController;
    [SerializeField] private float jumpAddPower;
    [SerializeField] private float fallAddPower;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float isGroundCheck;
    [SerializeField] private LayerMask groundLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        moveController = Input.GetAxisRaw("Horizontal");
        if (moveController!=0)
        {
            if (!runSound.isPlaying&&isGround)
            {
                runSound.Play();
            }
        }
        else
        {
            runSound.Stop();
        }
        rb.velocity = new Vector2(moveSpeed * moveController, rb.velocity.y);
        if (Input.GetButtonDown("Jump")&&isGround)
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            isJumping = true;
            jumpAddController = 0;
            doubleJump = true;
        }
        if (doubleJump&&!isGround&&Input.GetButtonDown("Jump"))
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            isJumping = true;
            jumpAddController = 0;
            doubleJump = false;
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
        if (isJumping)
        {
            if (jumpAddController < jumpAddTime)
            {
                rb.velocity += new Vector2(0, -Physics2D.gravity.y * Time.deltaTime * jumpAddPower);
            }
            else
            {
                isJumping = false;
            }
            jumpAddController += Time.deltaTime;
        }
        if (!isJumping)
        {
            rb.velocity -=new Vector2(0, -Physics2D.gravity.y * Time.deltaTime*fallAddPower);
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
        isGround = Physics2D.Raycast(transform.position, Vector2.down, isGroundCheck, groundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x,transform.position.y-isGroundCheck));
    }
}