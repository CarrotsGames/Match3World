using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip[] NodeAudio;
    public AudioSource NodeSource;
    public AudioClip[] MooblingAudio;
    public AudioSource MooblingSource;
    public AudioClip[] ParticleAudio;
    public AudioSource ParticleSource;
    public GameObject SoundEffects;
    [HideInInspector]
    public GameObject Settings;
    public bool soundOn;
    public bool MusicOn;
     // Use this for initialization
    private void Start()
    {
      
        soundOn = true;
        soundOn = (PlayerPrefs.GetInt("SaveSound") != 0);
        MusicOn = true;
        MusicOn = (PlayerPrefs.GetInt("MusicSave") != 0);
        Settings = GameObject.Find("Settings");
     
        if (!MusicOn)
        {
            TurnMusicOn();
        }
        else
        {
            TurnMusicOff();
        }
        AudioToggle();
    }
    // Update is called once per frame
    public void AudioToggle ()
    {

        string Scene = SceneManager.GetActiveScene().name;
        if (Scene != "Main Screen")
        {
            if (!soundOn)
            {
                //Disable audioSource
                Settings.GetComponent<settings>().noSound.SetActive(true);
                Settings.GetComponent<settings>().sound.SetActive(false);

                NodeSource.enabled = false;
                MooblingSource.enabled = false;
                ParticleSource.enabled = false;
                PlayerPrefs.SetInt("SaveSound", (soundOn ? 1 : 0));
            }
            else
            {
                Settings.GetComponent<settings>().noSound.SetActive(false);
                Settings.GetComponent<settings>().sound.SetActive(true);

                NodeSource.enabled = true;
                MooblingSource.enabled = true;
                ParticleSource.enabled = true;
                PlayerPrefs.SetInt("SaveSound", (soundOn ? 1 : 0));
                //enable audio source
            }
        }
        else
        {
            if (!soundOn)
            {
                //Disable audioSource
                Settings.GetComponent<MainSetting>().soundOff.SetActive(true);
                Settings.GetComponent<MainSetting>().soundOn.SetActive(false);

                NodeSource.enabled = false;
                MooblingSource.enabled = false;
                ParticleSource.enabled = false;
                PlayerPrefs.SetInt("SaveSound", (soundOn ? 1 : 0));
            }
            else
            {
                Settings.GetComponent<MainSetting>().soundOff.SetActive(false);
                Settings.GetComponent<MainSetting>().soundOn.SetActive(true);

                NodeSource.enabled = true;
                MooblingSource.enabled = true;
                ParticleSource.enabled = true;
                PlayerPrefs.SetInt("SaveSound", (soundOn ? 1 : 0));
                //enable audio source
            }
        }
       
    }

    public void TurnMusicOn()
    {
 

        // sceneAudio.SetActive(true);
        //GetComponent<AudioManager>().NodeSource.enabled = true;
        //DO THIS TO OTHERS!!!!!!///////////////////////////////////////
        SoundEffects.GetComponent<AudioSource>().enabled = true;
        MusicOn = false;
        PlayerPrefs.SetInt("MusicSave", (MusicOn ? 1 : 0));
        string Scene = SceneManager.GetActiveScene().name;
        if(Scene != "Main Screen" )
        {
            Settings.GetComponent<settings>().NoMusicImage.SetActive(false);
            Settings.GetComponent<settings>().MusicImage.SetActive(true);
        }
        else
        {
            Settings.GetComponent<MainSetting>().musicOff.SetActive(false);
            Settings.GetComponent<MainSetting>().musicOn.SetActive(true);
        }
       
    }

    public void TurnMusicOff()
    {
 

        //  sceneAudio.SetActive(false);
        //GetComponent<AudioManager>().NodeSource.enabled = false;
        SoundEffects.GetComponent<AudioSource>().enabled = false;

        MusicOn = true;
        PlayerPrefs.SetInt("MusicSave", (MusicOn ? 1 : 0));
        string Scene = SceneManager.GetActiveScene().name;
        if (Scene != "Main Screen")
        {
            Settings.GetComponent<settings>().NoMusicImage.SetActive(true);
            Settings.GetComponent<settings>().MusicImage.SetActive(false);
        }
        else
        {
            Settings.GetComponent<MainSetting>().musicOff.SetActive(true);
            Settings.GetComponent<MainSetting>().musicOn.SetActive(false);
        }
    }

}
