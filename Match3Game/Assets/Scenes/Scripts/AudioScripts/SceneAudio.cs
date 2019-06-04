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
    public AudioSource Source;

    private HappinessManager HappinessManagerScript;
    public bool Daymode;
    public string MorningSave;
    string NightSave;

    public bool ChangeMusic;
    // Use this for initialization
    void Start ()
    {
        Daymode = (PlayerPrefs.GetInt(MorningSave) != 0);
      
        // Daymode = true;
        HappinessManagerGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessManagerGameObj.GetComponent<HappinessManager>();
     
    }

   
    public void PlayMusic()
    {
        // if its nighttime
        if (!Daymode)
        {
 
            // play night music
            Source.clip = SceneMusic[1];
            Source.Play();
             // save bool as false so if the game is reset it will go back here
            PlayerPrefs.SetInt(MorningSave, (Daymode ? 1 : 0));
            // this will work in the game session to switch between night and day
            // This is not saved because if a restart happens during sleep it will play 
            Daymode = true;
        }
        else
        {
            //  WakeUpSource.clip = WakeUpSound;
             Source.clip = SceneMusic[0];
            Source.Play();
            // save bool as false so if the game is reset it will go back here
            PlayerPrefs.SetInt(MorningSave, (Daymode ? 1 : 0));
            // this will work in the game session to switch between night and day
            // This is not saved because if a restart happens during sleep it will play 
            Daymode = false;

        }
    }
}
