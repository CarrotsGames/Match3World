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


    private GameObject AudioManagerGameObj;
    private AudioManager AudioManagerScript;
    void Start()
    {
        PlayAudio = true;
        AudioManagerGameObj = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManagerScript = AudioManagerGameObj.GetComponent<AudioManager>();
         DecayTimer = 1.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayAudio)
        {
            AudioManagerScript.ParticleSource.clip = AudioManagerScript.ParticleAudio[AudioIndex];
            AudioManagerScript.ParticleSource.Play();
            PlayAudio = false;
        }

        DecayTimer -= Time.deltaTime;
        if(DecayTimer < 0)
        {
            Destroy(gameObject);
         
        }
    }
}
