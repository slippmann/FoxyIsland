﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float runningSpeed = 6;
    public float jumpVelocity = 6;
    public float minX = 7;
    public float maxX = 20;
    public bool isJumping = false;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private playerCollision collisionManager;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collisionManager = GetComponent<playerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

        CheckBorders();
    }

    void Move()
    {
        float input;
        int rotation;

        input = Input.GetAxisRaw("Horizontal");

        // Handle animation state machine
        animator.SetBool("isRunning", input != 0);

        // Rotate player (if moving)
        if (input != 0)
        {
            rotation = input >= 0 ? 0 : 180;
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }

        // Move player
        rigidBody.velocity = new Vector2(runningSpeed * input, rigidBody.velocity.y);
    }

    void Jump()
    {
        if (collisionManager.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpVelocity);
            animator.SetTrigger("jumpTrigger");
        }

        animator.SetBool("isFalling", rigidBody.velocity.y < 0);
    }

    void CheckBorders()
    {
        if (transform.position.x < minX)
            transform.position = new Vector2(minX, transform.position.y);

        if (transform.position.x > maxX)
            transform.position = new Vector2(maxX, transform.position.y);
    }
}
