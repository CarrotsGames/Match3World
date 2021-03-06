﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Animator fadeAnim;
    public Animator gameAnim;
    public Animator cameraAnim;

    public GameObject skipMenu;


    public GameObject startText;

    public AudioClip pageFlip;
    public AudioSource audioSource;

    public bool stopAd = false;

    public GameObject playBannerGameObject;
    private PlayBannerAd playBannerAdScript;


    public void Start()
    {
        playBannerAdScript = playBannerGameObject.GetComponent<PlayBannerAd>(); 
    }

    public void LoadGame()
    {
        int A = PlayerPrefs.GetInt("TUTORIAL");
        if (A < 1)
        {
            SceneManager.LoadScene("Tutorial Scene");
        }
        else
        {
            SceneManager.LoadScene("Main Screen");

        }
    }

    public void StartFade()
    {
        fadeAnim.SetBool("Start", true);
        stopAd = true;
    }

    public void StartAnim()
    {
        gameAnim.SetBool("AnimStart",true);
        startText.SetActive(false);
        skipMenu.SetActive(false);
    }


    public void PlayAudio()
    {
        audioSource.PlayOneShot(pageFlip, 0.7f);
    }

    public void StartCamera()
    {
        cameraAnim.SetBool("StartZoom", true);
    }


    public void Update()
    {
        if (stopAd == true)
        {
            playBannerAdScript.HideBanner();
        }
    }

    public void LoadSkip()
    {
        int A = PlayerPrefs.GetInt("TUTORIAL");
        if (A < 1)
        {
            skipMenu.SetActive(true);
        }
        else
        {
            StartAnim();
        }
    }

    public void SkipYes()
    {
        PlayerPrefs.SetInt("TUTORIAL", 1);
        SceneManager.LoadScene("Main Screen");
        StartAnim();
    }

}
