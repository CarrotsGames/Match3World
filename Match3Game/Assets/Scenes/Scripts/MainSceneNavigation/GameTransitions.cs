using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTransitions : MonoBehaviour {

    public AudioSource antiPop;
    public AudioSource pop;
    public AudioSource giggle;
    public GameObject sceneTransitions;
    private Animator anim;
    private GameObject RealTimerGameObj;
    private RealTimeCounter RealTimeScript;
    public GameObject settingsMenu;
    public GameObject Analytics;

    // Use this for initialization
    void Start () {
        anim = sceneTransitions.GetComponent<Animator>();

        anim.SetBool("UnTransition", true);
        StartCoroutine(EndAnim());
        // References the Realtimescript which is located on camera (TEMP)
        RealTimerGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = RealTimerGameObj.GetComponent<RealTimeCounter>();
    }

    public void PopSound()
    {
        pop.Play(0);
    }

    public void AntiPopSound()
    {
        antiPop.Play(0);
    }
    public void GiggleSound()
    {
        giggle.Play(0);
    }


    IEnumerator EndAnim()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("UnTransition", false);
    }

    public void BackToMain()
    {
        RealTimeScript.ResetClock();

        SceneManager.LoadScene("Main Screen");
        Analytics.GetComponent<PlayFabAnalytics>().GraphedData();
    }

    public void HomeButton()
    {
        RealTimeScript.ResetClock();

        anim.SetBool("Transition", true);
        settingsMenu.SetActive(false);
        Analytics.GetComponent<PlayFabAnalytics>().GraphedData();
    }




}
