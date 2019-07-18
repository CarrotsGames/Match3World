using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings : MonoBehaviour {

    public GameObject settingsMenu;

    public GameObject audioManager;

    public GameObject NoMusicImage;
    public GameObject MusicImage;

    public GameObject noSound;
    public GameObject sound;

    public GameObject soundEffects;

    public bool musicOff;

    public bool soundOff;


    private GameObject AudioManagerGameObj;
    private AudioManager AudioManagerScript;
 
    private void Start()
    {
        AudioManagerGameObj = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManagerScript = AudioManagerGameObj.GetComponent<AudioManager>();
        musicOff = PlayerPrefs.GetInt("MusicSave") != 0;
        soundOff = PlayerPrefs.GetInt("SoundSave") != 0;

        if (musicOff)
        {
            audioManager.GetComponent<AudioManager>().NodeSource.enabled = false;
            soundEffects.GetComponent<SceneAudio>().Source.enabled = false;

            // sceneAudio.SetActive(false);
            NoMusicImage.SetActive(true);
            MusicImage.SetActive(false);
        }
        else
        {
            audioManager.GetComponent<AudioManager>().NodeSource.enabled = true;
            soundEffects.GetComponent<SceneAudio>().Source.enabled = true;

            // sceneAudio.SetActive(true);
            NoMusicImage.SetActive(false);
            MusicImage.SetActive(true);
        }

        if (!soundOff)
        {
            AudioManagerScript.soundOn = false;
            soundOff = false;
            noSound.SetActive(false);
            sound.SetActive(true);
        }
        else
        {
            AudioManagerScript.soundOn = true;
            sound.SetActive(false);
            soundOff = true;
            noSound.SetActive(true);
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

            // sceneAudio.SetActive(true);
            audioManager.GetComponent<AudioManager>().NodeSource.enabled = true;
             //DO THIS TO OTHERS!!!!!!///////////////////////////////////////
            soundEffects.GetComponent<SceneAudio>().Source.enabled = true;
            musicOff = false;
            PlayerPrefs.SetInt("MusicSave", (musicOff ? 1 : 0));
            NoMusicImage.SetActive(false);
            MusicImage.SetActive(true);
        }
        else
        {
            //  sceneAudio.SetActive(false);
            audioManager.GetComponent<AudioManager>().NodeSource.enabled = false;
            soundEffects.GetComponent<SceneAudio>().Source.enabled = false;

            musicOff = true;
            PlayerPrefs.SetInt("MusicSave", (musicOff ? 1 : 0));
            NoMusicImage.SetActive(true);
            MusicImage.SetActive(false);
        }

    }


    public void NoSounds()
    {
        if (soundOff)
        {
            AudioManagerScript.soundOn = true;
            soundOff = false;
            noSound.SetActive(false);
            sound.SetActive(true);
            PlayerPrefs.SetInt("SoundSave", (soundOff ? 1 : 0));

        }
        else
        {
            AudioManagerScript.soundOn = false;
            soundOff = true;
            noSound.SetActive(true);
            sound.SetActive(false);
            PlayerPrefs.SetInt("SoundSave", (soundOff ? 1 : 0));

        }

    }
}
