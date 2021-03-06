﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settings : MonoBehaviour {

    public GameObject settingMenu;

    public GameObject audioManager;

    public GameObject NoMusicImage;
    public GameObject MusicImage;

    public GameObject noSound;
    public GameObject sound;


    public bool musicOff;

    public bool soundOff;

    private GameObject AudioManagerGameObj;
    private AudioManager AudioManagerScript;

    public bool open;
    private RealTimeCounter RealTimeScript;
    private GameObject MainCamera;
    public GameObject Analytics;
    private GameObject HappinessManagerGameObj;
    private void Start()
    {     
        // References the Realtimescript which is located on camera (TEMP)
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = MainCamera.GetComponent<RealTimeCounter>();
        Analytics = GameObject.FindGameObjectWithTag("PlayFab");
        AudioManagerGameObj = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManagerScript = AudioManagerGameObj.GetComponent<AudioManager>();
        musicOff = PlayerPrefs.GetInt("MusicSave") != 0;
        soundOff = PlayerPrefs.GetInt("SaveSound") != 0;
        HappinessManagerGameObj = GameObject.FindGameObjectWithTag("HM");

   
    }

    public void OpenSettings()
    {
        settingMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        settingMenu.SetActive(false);
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
    public void PushAnalytics()
    {
        if (PlayFabLogin.HasLoggedIn == true)
        {
            // Gets moobling data
            Analytics.GetComponent<PlayFabAnalytics>().SetUserData();
            //Sends gold amount and powerups used
            Analytics.GetComponent<PowerUpAnalytics>().SendAnalytics();
            //Sends gold amount and powerups used
            Analytics.GetComponent<PlayFabLogin>().TournamentScore();
        }
    }
    public void SaveData()
    {
        if (!GameObject.Find("CHALLENGE"))
        {
            HappinessManagerGameObj.GetComponent<HappinessManager>().SaveMe();
        }

    }
    public void LoadMain()
    {  
        RealTimeScript.ResetClock();
        SaveData();
        GameObject SaveTime = GameObject.Find("AdCountdown");
        SaveTime.GetComponent<AdCountdown>().SaveTimer();

        SceneManager.LoadScene("Main Screen");
        PushAnalytics();
        
     
    }
     
    
}
