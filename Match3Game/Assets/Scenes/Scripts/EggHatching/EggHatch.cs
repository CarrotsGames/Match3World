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
  
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCountdownTimer();
        }
        CurrentTime -= Time.deltaTime;

        // Gets time every second
        if (CurrentTime <  1)
        {
            GetCurrentTime();
        }
    
  
        // if the time is greater than time stamp hatch egg
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
       
            // sets egghatch save to timestamp    PLUS ARRAY NUM
            PlayerPrefs.SetString("EggHatch", "" + TimeStamp);

        }, null);

    }

}