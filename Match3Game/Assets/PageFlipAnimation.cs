using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFlipAnimation : MonoBehaviour
{
    public GameObject paperSprite;

    public AudioClip pageFlip;
    public AudioSource audioSource;


    public void StopAnim()
    {
        paperSprite.SetActive(false);
    }

    public void PlayAudio()
    {
        audioSource.PlayOneShot(pageFlip, 0.7f);
    }
}
