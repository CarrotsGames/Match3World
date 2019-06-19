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

    private GameObject AudioManagerGameObj;
    private AudioManager AudioManagerScript;
    private AudioSource Audio;
    void Start()
    {
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
       

        DecayTimer -= Time.deltaTime;
        if(DecayTimer < 0)
        {
            Destroy(gameObject);
         
        }
    }
}
