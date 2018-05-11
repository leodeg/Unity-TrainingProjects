﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

	// Use this for initialization
	void Start ()
    {
        foreach (Transform child in this.transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, 
                new Vector3(child.transform.position.x, child.transform.position.y, 0), 
                Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
