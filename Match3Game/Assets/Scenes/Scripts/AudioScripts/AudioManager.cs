using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip[] NodeAudio;
    public AudioSource NodeSource;
    public AudioClip[] MooblingAudio;
    public AudioSource MooblingSource;
    public AudioClip[] ParticleAudio;
    public AudioSource ParticleSource;
 
    public bool soundOn;
    private string SaveBool;
    // Use this for initialization
    private void Start()
    {
        soundOn = true;
        soundOn = (PlayerPrefs.GetInt(SaveBool) != 0);
    }
    // Update is called once per frame
    public void AudioToggle ()
    { 
        if (!soundOn)
        {
            //Disable audioSource
            NodeSource.enabled = false;
            MooblingSource.enabled = false;
            ParticleSource.enabled = false;
            PlayerPrefs.SetInt(SaveBool, (soundOn ? 1 : 0));
        }
        else
        {
            NodeSource.enabled = true;
            MooblingSource.enabled = true;
            ParticleSource.enabled = true;
            PlayerPrefs.SetInt(SaveBool, (soundOn ? 1 : 0));
            //enable audio source
        }
    }
}
