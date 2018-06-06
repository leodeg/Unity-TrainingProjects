using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attackers : MonoBehaviour
{
    private float currentSpeed;
    private GameObject currentTarget;
    
    // Update is called once per frame
    void Update ()
    {
        this.transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
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
        Debug.Log(name + " caused damage: " + damage);
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
