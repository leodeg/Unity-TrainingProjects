using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 15.0f;    
    public float projectileSpeed = 10;
    public float repeatRating = 0.2f;
    public float padding = 1f;
    public float health = 100;

    public AudioClip fireSound;

    private float xMin;
    private float xMax;
    private HealthKeeper healthKeeper;


    // Use this for initialization
    void Start ()
	{
        Camera camera = Camera.main;
        float distance = this.transform.position.z - camera.transform.position.z;
        Vector3 leftmost = camera.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = camera.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xMin = leftmost.x + padding;
        xMax = rightmost.x - padding;

        healthKeeper = GameObject.Find("Health").GetComponent<HealthKeeper>();
    }
	
	// Update is called once per frame
	void Update ()
	{
        MoveTheShip();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            InvokeRepeating("Fire", 0.000001f, repeatRating);
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Keypad5))
        {
            CancelInvoke("Fire");
        }

        healthKeeper.Health(health);
        //MoveWithMouse();
    }

    // Weapons shoot (for player)
    private void Fire()
    {
        Vector3 startPosition = this.transform.position + new Vector3(0f, +1f, 0f);
        GameObject beam = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);

        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    // Method of move for player by keyboard arrows
    private void MoveTheShip()
	{
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Keypad6))
        {
            // this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            // Second method for move of player ship
            this.transform.position += Vector3.right * speed * Time.deltaTime;
            Debug.Log("RightArrow key was pressed.");
        }

        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Keypad4))
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Player collider");
        Projectile missile = collider.gameObject.GetComponent<Projectile>();

        if (missile)
        {
            health -= missile.getDamage();
            missile.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
                healthKeeper.ResetHealth();
            }
        }
    }
}
