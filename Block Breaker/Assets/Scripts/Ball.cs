using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public Paddle paddle;

    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

    // Use this for initialization.
    void Start ()
    {
        paddleToBallVector = this.transform.position - paddle.transform.position;
        rigidBody2D = GetComponent<Rigidbody2D>();
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
}
