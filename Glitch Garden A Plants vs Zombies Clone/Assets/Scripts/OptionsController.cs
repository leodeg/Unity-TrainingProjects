using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider diffSlider;
    public LevelManager levelManager;

    private MusicManager musicManager;

	// Use this for initialization
	void Start ()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        diffSlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
    }

    public void SaveAndExit()
    {
        SaveOptions();
        levelManager.LoadLevel("01 Start");
    }

    public void SaveOptions()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(diffSlider.value);
        //musicManager.SetVolume(volumeSlider.value);
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        diffSlider.value = 2f;
    }
}
