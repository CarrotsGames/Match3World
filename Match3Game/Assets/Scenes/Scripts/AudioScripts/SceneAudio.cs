using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudio : MonoBehaviour {
    public AudioClip[] SceneMusic;
    public AudioClip[] WakeUpSound;

    // Wake up and sleeping sounds
    [HideInInspector]
    public GameObject HappinessManagerGameObj;

    public AudioSource CompanionSound;
    public AudioSource SceneMusicSource;

    private HappinessManager HappinessManagerScript;
    public bool Daymode;
    public string MorningSave;
    string NightSave;

    public bool ChangeMusic;
    // Use this for initialization
    void Start ()
    {
      
        // Daymode = true;
        HappinessManagerGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessManagerGameObj.GetComponent<HappinessManager>();
      // if(Daymode)
      // {
      //     NightMusic();
      // }
      // else
      // {
      //     DayMusic();
      // }
    }

    void DayMusic()
    {

        // play night music
        SceneMusicSource.clip = SceneMusic[0];
        SceneMusicSource.Play();
        // save bool as false so if the game is reset it will go back here
        // this will work in the game session to switch between night and day
        // This is not saved because if a restart happens during sleep it will play 
        Daymode = false;
        PlayerPrefs.SetInt("AUDIOSAVE", (Daymode ? 1 : 0));

    }
    void NightMusic()
    {
        //  WakeUpSource.clip = WakeUpSound;
        SceneMusicSource.clip = SceneMusic[1];
        SceneMusicSource.Play();
        // save bool as false so if the game is reset it will go back here
        // this will work in the game session to switch between night and day
        // This is not saved because if a restart happens during sleep it will play 
        Daymode = true;
        PlayerPrefs.SetInt("AUDIOSAVE", (Daymode ? 1 : 0));

    }
    public void PlayMusic()
    {
      //  Daymode = (PlayerPrefs.GetInt("AUDIOSAVE") != 0);

        // if its nighttime
        if (!Daymode)
        {
            NightMusic();
        }
        else
        {
            DayMusic();
        }
    }
}
