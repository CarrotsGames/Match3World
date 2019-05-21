using UnityEngine;
using System.Collections;

// DESTORYS PARTICLE EFFECTS AFTER NODES ARE DESTROYED TO CLEAR MEMORY
public class ParticleDecay : MonoBehaviour
{
    float DecayTimer;
    private AudioSource Source;
    public AudioClip ParticleAudio;
    // Use this for initialization
    void Start()
    {
        Source = GetComponent<AudioSource>();
        DecayTimer = 1.5f;
        Source.clip = ParticleAudio;
        Source.Play();
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
