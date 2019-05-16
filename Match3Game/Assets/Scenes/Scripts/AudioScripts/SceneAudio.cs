using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudio : MonoBehaviour {
    public AudioClip[] SceneMusic;
    [HideInInspector]
    public GameObject HappinessManagerGameObj;

    private AudioSource Source;
    private HappinessManager HappinessManagerScript;
    public bool Daymode;
    public bool NightMode;

    public bool ChangeMusic;
    // Use this for initialization
    void Start ()
    {
        // Daymode = true;
        HappinessManagerGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessManagerGameObj.GetComponent<HappinessManager>();
        Source = GetComponent<AudioSource>();
        PlayMusic();
    }

    private void Update()
    {
        PlayMusic();
    }
    void PlayMusic()
    {
        if (Daymode)
        {
            Source.clip = SceneMusic[0];
            Source.Play();
            Daymode = false;
        }
        if (NightMode)
        {
            Source.clip = SceneMusic[1];
            Source.Play();
            NightMode = false;
        }
    }
}
