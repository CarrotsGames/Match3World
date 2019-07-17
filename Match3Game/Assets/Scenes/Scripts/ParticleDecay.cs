using UnityEngine;
using System.Collections;

// DESTORYS PARTICLE EFFECTS AFTER NODES ARE DESTROYED TO CLEAR MEMORY
public class ParticleDecay : MonoBehaviour
{
    float DecayTimer;
    public int AudioIndex;
    // 0 BOMBSOUND
    // 1 FIREWORKSOUND 
    // 2 LITE PARTY
    // 3 HEAVY PARTY
    bool PlayAudio;
    int i;
    private GameObject Settings;
    private GameObject AudioManagerGameObj;
    private AudioManager AudioManagerScript;
    private AudioSource Audio;

    void Start()
    {
        Settings = GameObject.Find("Settings");
        PlayAudio = true;
        AudioManagerGameObj = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManagerScript = AudioManagerGameObj.GetComponent<AudioManager>();
        DecayTimer = 1.5f;
        Audio = GetComponent<AudioSource>();
        Audio.clip = AudioManagerScript.ParticleAudio[AudioIndex];
        Audio.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (Settings.GetComponent<settings>().soundOff)
        {
            GetComponent<AudioSource>().enabled = false;
        }
            DecayTimer -= Time.deltaTime;
            if (DecayTimer < 0)
            {
                Destroy(gameObject);

            }
    }
}
