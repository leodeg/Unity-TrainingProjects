using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    private bool isBreakable; 
    private int timesHit;
    private LevelManager levelManager;

    void Start ()
    {
        isBreakable = (this.tag == "Breakable");

        // Keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
            print(breakableCount);
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    
    void Update ()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.7f);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
            LoadSprites();
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing...");
        }
    }
}
