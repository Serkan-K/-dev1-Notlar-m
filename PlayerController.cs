using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 1;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 Player_pos;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject cam_;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Player_pos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(speed, 0);
    }





    private void Update()
    {

        animator.SetFloat("Speed", speed);

        Player_pos = new(Player_pos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), Player_pos.y);
        transform.position = Player_pos;


        if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetFloat("Speed", 0);
        }
        else
        {
            animator.SetFloat("Speed", 1);
        }




        if (Input.GetAxis("Horizontal") > 0.01)
        {
            spriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0.01)
        {
            spriteRenderer.flipX = true;
        }

    }


    private void LateUpdate()
    {
        cam_.transform.position = new(Player_pos.x, Player_pos.y, Player_pos.z - 1);
    }
}


