using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;

	void Start ()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager.LoadLevel("03 Lose");
    }
}
