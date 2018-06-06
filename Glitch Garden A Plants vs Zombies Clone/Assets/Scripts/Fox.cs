using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attackers))]
public class Fox : MonoBehaviour
{
    private Attackers attackers;
    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        attackers = GetComponent<Attackers>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        // Leave the method if not colliding with defender
        if (!obj.GetComponent<Defenders>())
        {
            return;
        }

        if (obj.GetComponent<Stone>())
        {
            animator.SetTrigger("Jump Trigger");
        }
        else
        {
            animator.SetBool("isAttack", true);
            attackers.Attack(obj);
        }
    }
}
