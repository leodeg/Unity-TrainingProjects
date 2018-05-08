﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private Paddle paddle;
    private AudioSource audio;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

    // Use this for initialization.
    void Start ()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        rigidBody2D = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame.
    void Update ()
    {
        if (!hasStarted)
        {
            // Lock the ball relative to the paddle.
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for a mouse press to launch.
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse clicked, launch ball");
                hasStarted = true;
                rigidBody2D.velocity = new Vector2(2f, 10f);
            }
        }        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted)
        {
            audio.Play();
            rigidBody2D.velocity += tweak;
        }
    }
}
