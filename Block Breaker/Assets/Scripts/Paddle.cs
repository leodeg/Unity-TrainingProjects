using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // Use this for initialization
    void Start ()
    {
        
    }
    
    // Update is called once per frame
    void Update ()
    {
        // Get a position of the mouse from main camera
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Position of the paddle for transformations
        Vector3 paddlePosition = new Vector3(-6.0f, this.transform.position.y, 0f)
        {
            // Get a screen value and blocks` size (16)
            //float mousePositionInBlocks = mousePos.x / Screen.width * 16; 
            //print(mousePositionInBlocks);

            // Movement limits of the paddle
            x = Mathf.Clamp(mousePos.x, 0f, 14f)
        };

        this.transform.position = paddlePosition;
    }
}
