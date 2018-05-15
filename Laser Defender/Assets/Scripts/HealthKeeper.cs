using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthKeeper : MonoBehaviour {

    public float health;
    private Text healthText;

    void Start()
    {
        healthText = GetComponent<Text>();
    }

    public void Health(float playerHealth)
    {
        health = playerHealth;
        healthText.text = health.ToString();
    }

    public void ResetHealth()
    {
        health = 0;
        healthText.text = health.ToString();
    }
}
