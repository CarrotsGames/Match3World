using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdCountdown : MonoBehaviour
{
    public float Countdown;
    private float ValueStore;
    private GameObject AdGameobj;
    private PlayLevelAd PlayLevelAdScript;

    // Start is called before the first frame update
    void Start()
    {
        Countdown = PlayerPrefs.GetFloat("AdTimer");
        AdGameobj = GameObject.FindGameObjectWithTag("SleepingAd");
        PlayLevelAdScript = AdGameobj.GetComponent<PlayLevelAd>();
        ValueStore = Countdown;
    }

    // Update is called once per frame
    void Update()
    {
        Countdown -= Time.deltaTime;
        if(Countdown < 0)
        {
            PlayAd();
        }
    }
    void PlayAd()
    {
        // Reset timer 
        Countdown = 900;
        PlayLevelAdScript.PlayAdNow();
    }
    public void SaveTimer()
    {
        PlayerPrefs.SetFloat("AdTimer", Countdown);
    }
  
   
}
