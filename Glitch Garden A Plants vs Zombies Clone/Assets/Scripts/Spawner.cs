using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] attackerPrefabArray;

	
	// Update is called once per frame
	void Update ()
    {
        foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if(isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}

    bool isTimeToSpawn(GameObject attackerGameObject)
    {
        Attackers attacker = attackerGameObject.GetComponent<Attackers>();

        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnPerSecond = 1 / meanSpawnDelay;

        if(Time.deltaTime > meanSpawnDelay)
            Debug.LogWarning("Spawn rate capped by frame rate");

        float threshold = spawnPerSecond * Time.deltaTime / 5;

        if(Random.value < threshold) return true;
        else return false;
    }

    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }
}
