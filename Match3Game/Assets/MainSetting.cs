using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSetting : MonoBehaviour
{
    public GameObject settingsMenu;

    public GameObject audioManager;

    public GameObject musicOff;
    public GameObject musicOn;
    public GameObject soundOff;
    public GameObject soundOn;

    public GameObject soundEffects;

    public bool musicOffBool;

    public bool soundOffBool;

    private GameObject AudioManagerGameObj;
    private AudioManager AudioManagerScript;


    public void Start()
    {
        AudioManagerGameObj = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManagerScript = AudioManagerGameObj.GetComponent<AudioManager>();
        musicOffBool = PlayerPrefs.GetInt("MusicSave") != 0;
        soundOffBool = PlayerPrefs.GetInt("SoundSave") != 0;
        if (musicOffBool)
        {
            MusicOff();
        }
        else
        {
            MusicOn();
        }

        if (soundOff)
        {
            SoundOff();
        }
        else
        {
            SoundOn();
        }
    }
    public void MusicOn()
    {

        // sceneAudio.SetActive(true);
        audioManager.GetComponent<AudioManager>().NodeSource.enabled = true;
        //DO THIS TO OTHERS!!!!!!///////////////////////////////////////
        soundEffects.GetComponent<SceneAudio>().SceneMusicSource.enabled = true;
        musicOffBool = false;
        PlayerPrefs.SetInt("MusicSave", (musicOff ? 1 : 0));
        musicOff.SetActive(false);
        musicOn.SetActive(true);
    }
    public void MusicOff()
    {
        //  sceneAudio.SetActive(false);
        audioManager.GetComponent<AudioManager>().NodeSource.enabled = false;
        soundEffects.GetComponent<SceneAudio>().SceneMusicSource.enabled = false;

        musicOffBool = true;
        PlayerPrefs.SetInt("MusicSave", (musicOff ? 1 : 0));
        musicOff.SetActive(true);
        musicOn.SetActive(false);
    }
    public void SoundOn()
    {
        soundOffBool = false;
        AudioManagerScript.soundOn = true;

        soundOff.SetActive(false);
        soundOn.SetActive(true);
        AudioManagerScript.AudioToggle();

        PlayerPrefs.SetInt("SoundSave", (soundOff ? 1 : 0));
    }

    public void SoundOff()
    {
        AudioManagerScript.soundOn = false;
        soundOffBool = true;
        soundOff.SetActive(true);
        soundOn.SetActive(false);
        AudioManagerScript.AudioToggle();
        PlayerPrefs.SetInt("SoundSave", (soundOff ? 1 : 0));
    }



    public void LoadSettings()
    {
        settingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }

    public void LoadBugReport()
    {
        Application.OpenURL("https://forms.gle/Qm234t9skgr99mYd8");
    }
    public void LoadPrivacyPolicy()
    {
        Application.OpenURL("https://drive.google.com/file/d/1Te_iB909w3ID611hzF4UiIWG9JX1u9Wu/view?usp=sharing");
    }


}
