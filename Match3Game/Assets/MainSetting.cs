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
    public GameObject redeemCodeInputField;

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
        soundOffBool = PlayerPrefs.GetInt("SaveSound") != 0;
        if (musicOffBool)
        {
            MusicOff();
        }
        else
        {
            MusicOn();
        }

  
    }
    public void MusicOn()
    {

        AudioManagerScript.MusicOn = true ;
        AudioManagerScript.TurnMusicOn();

    }
    public void MusicOff()
    {
        AudioManagerScript.MusicOn = false;
        AudioManagerScript.TurnMusicOff();
    }
    public void SoundOn()
    {
        AudioManagerScript.soundOn = true;
        AudioManagerScript.AudioToggle();

    }

    public void SoundOff()
    {
        AudioManagerScript.soundOn = false;

        AudioManagerScript.AudioToggle();
    }



    public void LoadSettings()
    {
        settingsMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
        redeemCodeInputField.SetActive(false);
    }

    public void LoadBugReport()
    {
        Application.OpenURL("https://forms.gle/Qm234t9skgr99mYd8");
    }
    public void LoadPrivacyPolicy()
    {
        Application.OpenURL("https://drive.google.com/file/d/1Te_iB909w3ID611hzF4UiIWG9JX1u9Wu/view?usp=sharing");
    }

    public void RedeemCode()
    {
        redeemCodeInputField.SetActive(true);
    }



}
