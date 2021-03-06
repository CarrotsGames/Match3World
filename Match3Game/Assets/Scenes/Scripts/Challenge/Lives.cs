﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.UI;
public class Lives : MonoBehaviour
{
    public static int LiveCount;
    public Text NumberOfLives;
    public Text LifeTimerText;
    private GameObject PlayFab;
    int TimeLeft;
    long TimeStamp;
    long CountdownTimerLong;
    long CurrentTime;
    long TimerLong;
    [HideInInspector]
    public static float CheckTime;
    double MinutesFromTs;
    public int AddPlayCount;
    private bool IsCountingDown;
    //Located in Canvas
    private void Start()
    {
        PlayFab = GameObject.FindGameObjectWithTag("PlayFab");

        IsCountingDown = false;
        CheckTime = 3;
        TimeStamp = System.Convert.ToInt64(PlayerPrefs.GetString("TimeUntilLives"));
      
        CountdownTimerLong = TimeStamp;
        LiveCount = PlayerPrefs.GetInt("LIVECOUNT");
        IsCountingDown = PlayerPrefs.GetInt("LIVECOUNTDOWN") != 0;

        NumberOfLives.text = "" + LiveCount;
        LifeTimerText.text = "Getting time...";
        int FirstTimeLogin = PlayerPrefs.GetInt("FirstTimeLogin");
        //TIMESTAMP USED TO = 0 HERE \/
        if(FirstTimeLogin < 1 || LiveCount <= -1)
        {
            IsCountingDown = false;
            LiveCount = 3;
            PlayerPrefs.SetInt("LIVECOUNT",3);
        }
        FirstTimeLogin++;
        if(LiveCount >= 3)
        {
            LifeTimerText.text = "FULL";
        }
        PlayerPrefs.SetInt("FirstTimeLogin", FirstTimeLogin);
        Countdown();
       

    }
    private void FixedUpdate()
    {   
        //DEBUG ONLY Resets time
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ResetStats();
        }
        
        if (PlayFabLogin.HasLoggedIn)
        {
            if (LiveCount >= 3)
            {
                LifeTimerText.text = "FULL";

            }
            NumberOfLives.text = "" + LiveCount;
        
            // if lives are less than 3 start countdown
            if (PlayFabLogin.HasLoggedIn == true)
            {
                if (LiveCount < 3 && !IsCountingDown)
                {
                    BeginTheCountdown();
                }
                // reset lives and countdown
                else if (LiveCount >= 3 && IsCountingDown)
                {
                    NumberOfLives.text = "" + LiveCount;
                    ResetStats();
                    LifeTimerText.text = "Fullhearts";
                    PlayerPrefs.SetInt("LIVECOUNT", LiveCount);
                    PlayerPrefs.SetInt("LIVECOUNTDOWN", (IsCountingDown ? 1 : 0));

                }
                // Checks if hearts are regened
                if (IsCountingDown)
                {
                    NumberOfLives.text = "" + LiveCount;

                    CheckHearts();

                }
            }
        }
        else
        {
            NumberOfLives.text = "" + LiveCount;
            LifeTimerText.text = "Buy egg?";
           
        }
    }
 
    void BeginTheCountdown()
    {

        TimeStamp = 0;
        CurrentTime = 0;
        // temporarily makes it 2 to not give lives right away
        TimeLeft = 19;
        NumberOfLives.text = "" + LiveCount;
        SetFullCounter();
        IsCountingDown = true;
         PlayerPrefs.SetInt("LIVECOUNT", LiveCount);

        PlayerPrefs.SetInt("LIVECOUNTDOWN", (IsCountingDown ? 1 : 0));
    }
    public void ResetStats()
    {
        TimeStamp = 100;
        CurrentTime = 0;
        TimerLong = 0;
        IsCountingDown = false;
        LiveCount = 3;
        PlayerPrefs.SetInt("LIVECOUNT", LiveCount);

        PlayerPrefs.SetString("TimeUntilLives", "" + TimeStamp);
        PlayerPrefs.SetInt("LIVECOUNTDOWN", (IsCountingDown ? 1 : 0));  
        PlayerPrefs.SetString("TimerLong", "" + TimerLong);
    }
    // checks if the hearts have regened
    void CheckHearts()
    {

        CheckTime -= Time.deltaTime;
        if (CheckTime < 0 && TimeStamp > 0)
        {
            Countdown();
        } 
        // if the time has passed the target time
        if (CurrentTime > TimeStamp)
        {
 
            if (LiveCount < 3)
            {
                if (CurrentTime > TimeStamp + 23982000000)
                {
                    ResetStats();
                    LifeTimerText.text = "FullHearts";
                }
              
                else if (CurrentTime > TimeStamp)
                {
                    LiveCount++;
                    PlayerPrefs.SetInt("LIVECOUNT", LiveCount);
                    TimerLong = 9L * 1199100000;
                    // gets amount of time already done 
                    TimerLong -=   CurrentTime - TimeStamp;

                    TimeSpan Ts = TimeSpan.FromTicks(TimerLong);
                    MinutesFromTs = Ts.TotalMinutes;

                    // adds time to timestamp
                    double test = TimerLong;
                    TimeStamp += (long)test;

                    int TimeTillLifeRegen = unchecked((int)MinutesFromTs);
                    TimeLeft = (int)(TimeTillLifeRegen % 60);
                    LifeTimerText.text = TimeLeft + 1 + "Minutes";
                }

                if(LiveCount >= 3)
                {
                    ResetStats();
                }

            }

                Countdown();
                NumberOfLives.text = "" + LiveCount;
                PlayerPrefs.SetString("TimeUntilLives", "" + TimeStamp);
            }
            else if(LiveCount >= 3)
            {
                IsCountingDown = false;
            }

        }

    
    // Countsdown the time until heart is ready
    void Countdown()
    {
        GetCurrentTime();
        int TimeTillLifeRegen = unchecked((int)MinutesFromTs);
              
     
        // Displays the current tick time into minutes and hours
        TimeLeft = (int)(TimeTillLifeRegen % 60);
        if (TimeTillLifeRegen > -1 && TimeLeft > -1)
        {
            LifeTimerText.text = TimeLeft + 1 + "Minutes";
        }
    }
    void GetCurrentTime()
    {
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            // current time 
            DateTime now = result.Time.AddHours(0);
            // Converts current time into ticks
            CurrentTime = now.Ticks;
            // Deducts now time from target time
            TimeSpan TimeTillRegen = TimeSpan.FromTicks(TimeStamp - CurrentTime);
            // Gets how long until the time is up
            MinutesFromTs = TimeTillRegen.TotalMinutes;
            // Resets cool down timer to avoid sending too much infomation to the server
            CheckTime = 5;
        }, null);
    }
     
    public void SetFullCounter()
    {
        TimeStamp = 0;

        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            // Current time
            DateTime now = result.Time.AddHours(0);
            // 20 minutes is set 
            long Period = 9L * 1199100000 ;
            // Timestamp is equal current time plus target time
            TimeStamp = now.Ticks + Period;
            // Timer long will save 20 minutes in ticks
            TimerLong = Period;
            // converts the time in ticks to actual time
            TimeSpan Ts = TimeSpan.FromTicks(Period);
            // Shows how many minutes 
            MinutesFromTs = Ts.TotalMinutes;
            //Saves Timestamp
            PlayerPrefs.SetString("TimeUntilLives", "" + TimeStamp);
            PlayerPrefs.SetString("TimerLong", "" + TimerLong);

        }, null);



    }
    public void DeductLife()
    {
        if (LiveCount > 0)
        {
            LiveCount -= 1;
            PlayerPrefs.SetInt("LIVECOUNT", LiveCount);

        }
    }
}