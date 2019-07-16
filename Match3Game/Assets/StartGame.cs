using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Animator fadeAnim;
    public Animator gameAnim;

    public GameObject startText;

    public AudioClip pageFlip;
    public AudioSource audioSource;



    public void LoadGame()
    {
        SceneManager.LoadScene("Main Screen");
    }

    public void StartFade()
    {
        fadeAnim.SetBool("Start", true);
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


}
