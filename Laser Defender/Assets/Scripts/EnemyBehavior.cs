using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject projectile;
    public float health = 150;
    public float projectileSpeed = 10;
    public float shotsPerSeconds = 0.5f;
    public int scoreValue = 150;

    public AudioClip fireSound;
    public AudioClip deathSound;

    private ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    private void Update()
    {
        float probability = Time.deltaTime * shotsPerSeconds;

        if (Random.value < probability)
        {
            EnemyFire();
        }
    }

    private void EnemyFire()
    {
        Vector3 startPosition = this.transform.position + new Vector3(0f, -1f, 0f);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);

        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        
        if (missile)
        {
            health -= missile.getDamage();
            missile.Hit();
            if (health <= 0)
            {
                EnemyDie();
            }
        }
    }

    void EnemyDie()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        scoreKeeper.Score(scoreValue);
        Destroy(gameObject);
    }

}
