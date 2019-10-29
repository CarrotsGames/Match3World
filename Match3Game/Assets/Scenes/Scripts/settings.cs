using System.Collections;
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
        soundOff = PlayerPrefs.GetInt("SoundSave") != 0;
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
        soundOff = false;
        AudioManagerScript.soundOn = true;

        noSound.SetActive(false);
        sound.SetActive(true);
        AudioManagerScript.AudioToggle();

        PlayerPrefs.SetInt("SoundSave", (soundOff ? 1 : 0));
    }

    public void SoundOff()
    {
        AudioManagerScript.soundOn = false;
        soundOff = true;
        noSound.SetActive(true);
        sound.SetActive(false);
        AudioManagerScript.AudioToggle();
        PlayerPrefs.SetInt("SoundSave", (soundOff ? 1 : 0));
    }

    public void LoadMain()
    {  
        RealTimeScript.ResetClock();
        HappinessManagerGameObj.GetComponent<HappinessManager>().SaveMe();

        GameObject SaveTime = GameObject.Find("AdCountdown");
        SaveTime.GetComponent<AdCountdown>().SaveTimer();

        SceneManager.LoadScene("Main Screen");
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
    
}
