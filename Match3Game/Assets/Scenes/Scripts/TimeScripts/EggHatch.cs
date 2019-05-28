using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.AuthenticationModels;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine;
using System;

public class EggHatch : MonoBehaviour {

    DateTime Target;
    public Text TimerText;
    public float Timer;
    private float DefaultTime;
    DateTime now;
    // Use this for initialization
    void Start ()
    {
        Target = new DateTime(0, 0, 0, 0, 0, 0);

        DefaultTime = Timer;
        StartCountdownTimer();
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.W))
        {
            GetServerTime();
        }
    }
    public void GetServerTime()
    {
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            now = result.Time.AddHours(1); // GMT+1

            int TargetSec = Target.Hour * 60 * 60 + Target.Minute * 60 + Target.Second;
         }, null);
    }
    void StartCountdownTimer()
    {
          
        if(TimerText != null)
        {
            Timer = DefaultTime;
            TimerText.text = "Time Left :";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }
    void UpdateTimer()
    {
        if (TimerText != null)
        {
            Timer -= Time.deltaTime;
            string minutes = Mathf.Floor(Timer / 60).ToString("00");
            string seconds = (Timer % 60).ToString("00");
            TimerText.text = "Time Left: " + now.Minute + ":" + now.Second + ":";
        }

    }
}
