using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attackers : MonoBehaviour
{
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update ()
    {
        this.transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            animator.SetBool("isAttack", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + " trigger enter");
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Called from the animator at time of actual blow
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
