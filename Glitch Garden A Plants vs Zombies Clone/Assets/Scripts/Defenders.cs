using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour
{
    private StarDisplay starDisplay;

    void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }
    // Used as a tag

    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }

}
