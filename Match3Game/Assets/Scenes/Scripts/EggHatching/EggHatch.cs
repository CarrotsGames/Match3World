using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.AuthenticationModels;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine;
using System;

public class EggHatch : MonoBehaviour
{

    DateTime Target;
 
    public Text TimerText;
    public float Timer;
    private float CurrentTime;
     private int EggNumber;
     private float RefreshTimer;
    double MinutesFromTs;
    DateTime now;
    long Period;
    long TimeStamp;
    long Test;
    // Use this for initialization
    void Start()
    {
        CurrentTime = 3;
        TimeStamp = System.Convert.ToInt64(PlayerPrefs.GetString("EggHatch"));
    }
    private void Update()
    {

        // Debug purpose 
        // checks what the current time is 
        if (Input.GetKeyDown(KeyCode.W))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCountdownTimer();
        }
        CurrentTime -= Time.deltaTime;

        if (CurrentTime <  1)
        {
            GetCurrentTime();
        }
    
        // works similarly to the distance from x position from y
        // Current time counts up to get difference
        // gets the difference between target time and current time 
        //  Timer = TargetTime - CurrentTime;
        //
        //  // Displays as timer
        //  string minutes = Mathf.Floor(Timer / 60).ToString("00");
        //  string seconds = (Timer % 60).ToString("00");
        //  TimerText.text = "Time Left: " + minutes + ":" + seconds + ":";
        //

        if (Test > TimeStamp)
        {
            //TODO
            //HATCH EGG
        }
    }
    // checks the current time on server
    void GetCurrentTime()
    {
        // gets the current time for countdown
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            // Gets current time to countup 
            now = result.Time.AddHours(0); // GMT+1
            Test = now.Ticks;
           
            CurrentTime = 5;

        }, null);
    }
    // begins countdown 
    void StartCountdownTimer()
    {
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            // Eggnumber is the current egg being hatched (WILL CHANGE TO ARRAY THE MORE EGGS WE HAVE)ssssss
           //EggNumber = 1;
           now = result.Time.AddHours(0);
            Period = 36L * 1000000000L ;
            TimeStamp = now.Ticks + Period;
            TimeSpan ts = TimeSpan.FromTicks(Period);
            MinutesFromTs = ts.TotalMinutes;
            //Target = result.Time.AddHours(3); // GMT+1
            //Period = Target.Hour * 540 + Target.Minute * 540;
            //TimeStamp = now.Hour * 60 + now.Minute * 60;

            // //                          PLUS ARRAY NUM
            PlayerPrefs.SetString("EggHatch", "" + TimeStamp);

        }, null);

    }

}