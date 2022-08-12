using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public static float speed = 5.0f;

    bool isWalking;

    void Start()
    {
        speed = 5.0f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetFloat("X", horizontal);
            animator.SetFloat("Y", vertical);

            if (!isWalking)
            {
                isWalking = true;
                animator.SetBool("isMoving", true);
            }
        } else
        {
            if (isWalking)
            {
                isWalking = false;
                animator.SetBool("isMoving", false);
                StopMoving();
            }
        }
    }

    void FixedUpdate()
    {
        // Credits Pawe? (Stack Overflow)
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }
}
