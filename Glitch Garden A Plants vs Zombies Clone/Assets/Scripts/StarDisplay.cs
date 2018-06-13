using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour
{
    private Text text;
    private int stars;

	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();
	}

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void UseStars(int amount)
    {
        stars -= amount;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        text.text = stars.ToString();
    }
}
