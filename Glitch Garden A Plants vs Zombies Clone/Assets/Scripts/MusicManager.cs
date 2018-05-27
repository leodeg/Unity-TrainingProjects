using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load" + name);
    }

    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}

    void Update()
    {
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    private void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        Debug.Log("Playing clip: " + thisLevelMusic); 

        if (thisLevelMusic)
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    /// <summary>
    /// Set volume sound in game
    /// </summary>
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
