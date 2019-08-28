using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settings : MonoBehaviour {

    public Animator uiSliderAnim;

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

    public bool open;
    private RealTimeCounter RealTimeScript;
    private GameObject MainCamera;


    private void Start()
    {     
        // References the Realtimescript which is located on camera (TEMP)
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = MainCamera.GetComponent<RealTimeCounter>();

        AudioManagerGameObj = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManagerScript = AudioManagerGameObj.GetComponent<AudioManager>();
        musicOff = PlayerPrefs.GetInt("MusicSave") != 0;
        soundOff = PlayerPrefs.GetInt("SoundSave") != 0;

        if (musicOff)
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

    public void OpenSlider()
    {

        if (open == true)
        {
            uiSliderAnim.SetBool("Close", true);
            uiSliderAnim.SetBool("Open", false);
            open = false;
        }else if (open == false)
        {
            uiSliderAnim.SetBool("Open", true);
            uiSliderAnim.SetBool("Close", false);
            open = true;
        }



    }



   

   public void MusicOn()
    {

        // sceneAudio.SetActive(true);
        audioManager.GetComponent<AudioManager>().NodeSource.enabled = true;
        //DO THIS TO OTHERS!!!!!!///////////////////////////////////////
        soundEffects.GetComponent<SceneAudio>().SceneMusicSource.enabled = true;
        musicOff = false;
        PlayerPrefs.SetInt("MusicSave", (musicOff ? 1 : 0));
        NoMusicImage.SetActive(false);
        MusicImage.SetActive(true);
    }
    public void MusicOff()
    {
        //  sceneAudio.SetActive(false);
        audioManager.GetComponent<AudioManager>().NodeSource.enabled = false;
        soundEffects.GetComponent<SceneAudio>().SceneMusicSource.enabled = false;

        musicOff = true;
        PlayerPrefs.SetInt("MusicSave", (musicOff ? 1 : 0));
        NoMusicImage.SetActive(true);
        MusicImage.SetActive(false);
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
        SceneManager.LoadScene("Main Screen");
    }


  
}
