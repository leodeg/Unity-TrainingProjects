using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public int maxHits = 6;

    private int timeHit;

    private LevelManager levelManager;

    // Use this for initialization
    void Start ()
    {
        timeHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timeHit++;

        if (timeHit >= maxHits)
        {
            Destroy(gameObject);
        }
    }
}
