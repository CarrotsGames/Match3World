using System.Collections;
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

    long TimeStamp;
    long CountdownTimerLong;
    long FullHeart;
    long HalfHeart;
    [HideInInspector]
    public static float CurrentTime;
    double MinutesFromTs;
    public int AddPlayCount;
    private bool IsCountingDown;
    //Located in Canvas
    private void Start()
    {
        IsCountingDown = false;   
        CurrentTime = 3;
        TimeStamp = System.Convert.ToInt64(PlayerPrefs.GetString("TimeUntilLives"));
        CountdownTimerLong = TimeStamp;
        LiveCount = PlayerPrefs.GetInt("LIVECOUNT");
        IsCountingDown = PlayerPrefs.GetInt("LIVECOUNTDOWN") != 0;
        if (TimeStamp == 0)
        {
            IsCountingDown = false;
            LiveCount = 3;
        }
        NumberOfLives.text = "" + LiveCount;
        LifeTimerText.text = "Getting time...";

    }
    private void FixedUpdate()
    {
     
        //DEBUG ONLY Resets time
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    IsCountingDown = false;
        //    TimeStamp = 0;
        //    PlayerPrefs.SetString("TimeUntilLives", "" + TimeStamp);

        //    FullHeart = 0 ;
        //}
        // if lives are less than 3 start countdown
        if(LiveCount < 3 && !IsCountingDown)
        {
            CurrentTime -= Time.deltaTime;
            if (CurrentTime < 0)
            {
                BeginTheCountdown();
            }
        }
        // reset lives and countdown
        else if (LiveCount >= 3)
        {
            NumberOfLives.text = "" + LiveCount;

            LiveCount = 3;
            LifeTimerText.text = "Fullhearts";

        }
        // Checks if hearts are regened
        if (IsCountingDown)
        {
            CheckHearts();
      
        }
    }
    void BeginTheCountdown()
    {
        TimeStamp = 0;
        NumberOfLives.text = "" + LiveCount;
        SetFullCounter();
        IsCountingDown = true;
        PlayerPrefs.SetInt("LIVECOUNTDOWN", (IsCountingDown ? 1 : 0));
    }
    // checks if the hearts have regened
    void CheckHearts()
    {
        PlayerPrefs.SetInt("LIVECOUNT", LiveCount);

        CurrentTime -= Time.deltaTime;
        if (CurrentTime < 0)
        {
            Countdown();
        } 
        // if the time has passed the target time
        if (FullHeart > TimeStamp)
        {
 
            if (LiveCount < 3)
            {
                if (FullHeart > TimeStamp + 2398200000)
                {
 
                    LiveCount = 3;
                }
                else if (FullHeart > TimeStamp + 1199100000)
                {
                    CountdownTimerLong += 1199100000;
                    LiveCount = 2;
                }               
                else if (FullHeart > TimeStamp)
                {
                    //  SetFullCounter();
                    // TimeStamp += 1199100000;
                    CountdownTimerLong += 1199100000;

                    LiveCount = 1;
                }
                NumberOfLives.text = "" + LiveCount;
                Countdown();

            }
            else if(LiveCount >= 3)
            {
                IsCountingDown = false;
            }

        }

    }
    // Countsdown the time until heart is ready
    void Countdown()
    {
        int TimeTillResetAd = unchecked((int)MinutesFromTs);
               
        GetCurrentTime();
         
        // Displays the current tick time into minutes and hours
        if (TimeTillResetAd != 0)
        {
            int Minutes = (int)(TimeTillResetAd % 60);
             LifeTimerText.text =  Minutes + "Minutes";
        }
    }
  
    void GetCurrentTime()
    {
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            // current time 
            DateTime now = result.Time.AddHours(0);
            // Converts current time into ticks
            FullHeart = now.Ticks;
            // Deducts now time from target time
            TimeSpan TimeTillRegen = TimeSpan.FromTicks(CountdownTimerLong - FullHeart);
            // Gets how long until the time is up
            MinutesFromTs = TimeTillRegen.TotalMinutes;
            // Resets cool down timer to avoid sending too much infomation to the server
            CurrentTime = 5;
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
            long Period = 10L * 1199100000;
            // Timestamp is equal current time plus target time
            TimeStamp = now.Ticks + Period;
            CountdownTimerLong = TimeStamp;
            // converts the time in ticks to actual time
            TimeSpan Ts = TimeSpan.FromTicks(Period);
            // Shows how many minutes 
            MinutesFromTs = Ts.TotalMinutes;
            //Saves Timestamp
            PlayerPrefs.SetString("TimeUntilLives", "" + TimeStamp);

        }, null);



    }
}