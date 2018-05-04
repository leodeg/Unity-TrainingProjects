using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public int maxHits = 5;

    private int timeHit;

    // Use this for initialization
    void Start ()
    {
        timeHit = 0;
    }
    
    // Update is called once per frame
    void Update ()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timeHit++;
    }
}
