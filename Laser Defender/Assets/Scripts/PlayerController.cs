using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;

	// Use this for initialization
	void Start ()
	{
        speed = 15.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
        MoveTheShip();
        //MoveWithMouse();
    }

    void MoveTheShip()
	{
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(+speed * Time.deltaTime, 0, 0);
            Debug.Log("RightArrow key was pressed.");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            Debug.Log("LeftArrow key was pressed.");
        }

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
