using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings : MonoBehaviour {

    public GameObject settingsMenu;

    public GameObject sceneAudio;

    public GameObject NoMusicImage;
    public GameObject MusicImage;

    public bool musicOff;

 
    private void Start()
    {
        musicOff = PlayerPrefs.GetInt("MusicSave") != 0;
        if(musicOff)
        {
            sceneAudio.SetActive(false);
            NoMusicImage.SetActive(true);
            MusicImage.SetActive(false);
        }
        else
        {
            sceneAudio.SetActive(true);
            NoMusicImage.SetActive(false);
            MusicImage.SetActive(true);
        }

    }

    public void TurnOffTab()
    {
        settingsMenu.SetActive(false);
    }

    public void OpenMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void NoMusic()
    {
        if (musicOff)
        {
            sceneAudio.SetActive(true);
            musicOff = false;
            PlayerPrefs.SetInt("MusicSave", (musicOff ? 1 : 0));
            NoMusicImage.SetActive(false);
            MusicImage.SetActive(true);
        }
        else
        {
            sceneAudio.SetActive(false);
            musicOff = true;
            PlayerPrefs.SetInt("MusicSave", (musicOff ? 1 : 0));
            NoMusicImage.SetActive(true);
            MusicImage.SetActive(false);
        }

    }
}
