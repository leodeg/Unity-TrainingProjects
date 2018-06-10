using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner spawners;

    void Start()
    {
        projectileParent = GameObject.Find("Projectiles");
        animator = GameObject.FindObjectOfType<Animator>();

        // Create a parent if necessary
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        FindSpawner();
    }

    private void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttack", true);
        }
        else
        {
            animator.SetBool("isAttack", false);
        }
    }

    // Look through all spawner, and set spawners
    void FindSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach (Spawner spawner in spawnerArray)
        {
            // Comparison spawner child with this object.transform.position.y
            if (spawner.transform.position.y == this.transform.position.y)
            {
                spawners = spawner;
                return;
            }
        }

        Debug.LogError(name + " can't find spawner in lane");
    }

    bool IsAttackerAheadInLane()
    {
        // Exit if no attackers in lane
        if (spawners.transform.childCount <= 0)
        {
            return false;
        }

        // If there are attackers
        foreach (Transform attackers in spawners.transform)
        {
            if (attackers.transform.position.x > transform.position.x) return true;
        }

        // Attackers in lane, but behind of defender
        return false;
    }

    private void Fire()
    {
        GameObject newProjectile =  Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
