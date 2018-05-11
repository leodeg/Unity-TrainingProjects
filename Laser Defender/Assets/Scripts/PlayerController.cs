using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    private float speed = 15.0f;
    private float xMin;
    private float xMax;
    private float padding = 1f;


    // Use this for initialization
    void Start ()
	{
        float distance = this.transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xMin = leftmost.x + padding;
        xMax = rightmost.x - padding;
    }
	
	// Update is called once per frame
	void Update ()
	{
        MoveTheShip();
        //MoveWithMouse();
    }

    private void MoveTheShip()
	{
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            // Second method for move of player ship
            this.transform.position += Vector3.right * speed * Time.deltaTime;
            Debug.Log("RightArrow key was pressed.");
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {

            // this.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            // Second method for move of player ship
            this.transform.position += Vector3.left * speed * Time.deltaTime;
            Debug.Log("LeftArrow key was pressed.");
        }

        // Restrict the player to the Gamespace
        float newX = Mathf.Clamp(this.transform.position.x, xMin, xMax);
        this.transform.position = new Vector3(newX, transform.position.y, transform.position.z);

    }

    private void MoveWithMouse()
    {
        // Get a position of the mouse from main camera
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Position of the paddle for transformations
        Vector3 paddlePosition = new Vector3(0f, this.transform.position.y, 0f);

        // Movement limits of the paddle
        paddlePosition.x = Mathf.Clamp(mousePos.x, -8.0f, 8f);

        this.transform.position = paddlePosition;
    }
}
