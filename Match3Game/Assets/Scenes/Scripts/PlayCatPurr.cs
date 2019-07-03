using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCatPurr : MonoBehaviour
{

    public AudioSource sceneaudio;
    public AudioClip purr;



    public void PlaySound()
    {
        sceneaudio.PlayOneShot(purr);
    }
}
