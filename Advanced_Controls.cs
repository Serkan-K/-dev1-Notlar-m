using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advanced_Controls : MonoBehaviour
{

    public float jumpForce_ = 2;
    public float speed_ = 1;
    public float moveDirection;

    private bool jump_;
    private bool grounded_ = true;
    private bool isMoving_;


    private Rigidbody2D rb_;
    private Animator anim_;
    private SpriteRenderer sr;

    private void Awake()
    {
        anim_ = GetComponent<Animator>();
    }



    private void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }






    private void FixedUpdate()
    {
        if (rb_.velocity != Vector2.zero)
        {
            isMoving_ = true;
        }
        else  { isMoving_ = false; }

        rb_.velocity = new(speed_ * moveDirection, rb_.velocity.y);



        if (jump_ == true)
        {
            rb_.velocity = new(rb_.velocity.x, jumpForce_);
            jump_ = false;
        }
    }






    private void Update()
    {
        if (grounded_ && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1;
                sr.flipX = true;
                anim_.SetFloat("Speed", speed_);
            }


            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1;
                sr.flipX = false;
                anim_.SetFloat("Speed", speed_);
            }
        }

        else if (grounded_) 
        { 
            moveDirection= 0;
            anim_.SetFloat("Speed", 0);
        }



        if(grounded_ && (Input.GetKey(KeyCode.Space)))
        {
            jump_ = true;
            grounded_ = false;
            anim_.SetTrigger("Jump");
            anim_.SetBool("Grounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim_.SetBool("Grounded", true);
            grounded_ = true;
        }
    }


}
