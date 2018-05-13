using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public bool movingRight = true;
    public float spawnDelay = 0.5f;

    private float speed = 3f;
    private float xMax;
    private float xMin;
    private float padding = 0.5f;
    private int direction = 1;
    private float boundaryRightEdge, boundaryLeftEdge;

    // Use this for initialization
    void Start ()
    {
        Camera camera = Camera.main;
        float distance = transform.position.z - camera.transform.position.z;
        boundaryLeftEdge = camera.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + padding;
        boundaryRightEdge = camera.ViewportToWorldPoint(new Vector3(1, 1, distance)).x - padding;

        spawnDelay = 0.5f;

        SpawnUntilFull();

    }

    // Update is called once per frame
    void Update ()
    {
        float formationRightEdge = this.transform.position.x + 0.5f * width;
        float formationLeftEdge = this.transform.position.x - 0.5f * width;
        if (formationRightEdge > boundaryRightEdge)
        {
            direction = -1;
        }
        if (formationLeftEdge < boundaryLeftEdge)
        {
            direction = 1;
        }
        this.transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);

        if (AllMemberDead())
        {
            Debug.Log("Empty Formation");
            SpawnUntilFull();

        }
    }

    public void SpawnEnemies()
    {
        // Move the enemy to EnemyFormation/Position
        foreach (Transform child in this.transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosotion();

        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }

        if (NextFreePosotion())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }

    Transform NextFreePosotion()
    {
        foreach (Transform childPositionGameObject in this.transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }

    private bool AllMemberDead()
    {
        foreach (Transform childPositionGameObject in this.transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }
}
