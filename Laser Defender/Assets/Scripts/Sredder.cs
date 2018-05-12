using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sredder : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy the object (player laser in our case) which is in the collider
        Destroy(collision.gameObject);
    }
}
