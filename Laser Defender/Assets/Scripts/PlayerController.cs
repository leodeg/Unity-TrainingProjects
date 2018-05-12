using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 15.0f;    
    public float projectileSpeed = 10;
    public float repeatRating = 0.2f;
    public float padding = 1f;

    private float xMin;
    private float xMax;
    


    // Use this for initialization
    void Start ()
	{
        Camera camera = Camera.main;
        float distance = this.transform.position.z - camera.transform.position.z;
        Vector3 leftmost = camera.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = camera.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xMin = leftmost.x + padding;
        xMax = rightmost.x - padding;
    }
	
	// Update is called once per frame
	void Update ()
	{
        MoveTheShip();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, repeatRating);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

        //MoveWithMouse();
    }

    // Weapons shoot (for player)
    private void Fire()
    {        
        GameObject beam = Instantiate(projectile, this.transform.position, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);        
    }

    // Method of move for player by keyboard arrows
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

    // Method of move for player by mouse
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
