using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool autoPlay = false;

    private Ball ball;
    
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    private void AutoPlay()
    {
        Vector3 paddlePosition = new Vector3(-6.0f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePosition.x = Mathf.Clamp(ballPos.x, 0f, 14f);
        this.transform.position = paddlePosition;
    }

    private void MoveWithMouse()
    {
        // Get a position of the mouse from main camera
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Position of the paddle for transformations
        Vector3 paddlePosition = new Vector3(-6.0f, this.transform.position.y, 0f);

        // Movement limits of the paddle
        paddlePosition.x = Mathf.Clamp(mousePos.x, 0f, 14f);

        this.transform.position = paddlePosition;
    }
}
