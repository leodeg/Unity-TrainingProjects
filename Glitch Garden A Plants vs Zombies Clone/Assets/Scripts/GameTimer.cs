using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float levelSeconds = 5;

    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;

	void Start ()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void Update ()
    {
        slider.value = 1 - (Time.timeSinceLevelLoad / levelSeconds);
        
        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            audioSource.Play();
            Invoke("LoadNextLevel", audioSource.clip.length);
            isEndOfLevel = true;
        }
	}

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
