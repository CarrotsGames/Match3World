using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Animator fadeAnim;
    public Animator gameAnim;
    public Animator cameraAnim;

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
        SceneManager.LoadScene("Tutorial Scene");
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


}
