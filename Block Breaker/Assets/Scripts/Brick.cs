using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;

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
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
            HandleHits();
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
            LoadSprites();
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
}
