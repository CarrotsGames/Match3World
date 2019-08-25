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

    long TimeStamp;
    long FullHeart;
    long HalfHeart;
    private float CurrentTime;
    double MinutesFromTs;
    public int AddPlayCount;
    private bool IsCountingDown;
    //Located in Canvas
    private void Start()
    {
        IsCountingDown = false;   
        CurrentTime = 3;
        TimeStamp = System.Convert.ToInt64(PlayerPrefs.GetString("TimeUntilLives"));
        LiveCount = PlayerPrefs.GetInt("LIVECOUNT");
        IsCountingDown = PlayerPrefs.GetInt("LIVECOUNTDOWN") != 0;
        if (TimeStamp == 0)
        {
            IsCountingDown = false;
            LiveCount = 3;
        }
        NumberOfLives.text = "" + LiveCount;
    }
    private void FixedUpdate()
    {
     
 
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TimeStamp = 0;
            PlayerPrefs.SetString("TimeUntilLives", "" + TimeStamp);

            FullHeart += 10L * 1199100000;
        }
    
        if(LiveCount < 3 && !IsCountingDown)
        {
            CurrentTime -= Time.deltaTime;
            if (CurrentTime < 0)
            {
                SetFullCounter();
                IsCountingDown = true;
                PlayerPrefs.SetInt("LIVECOUNTDOWN", (IsCountingDown ? 1 : 0));
            }
        }
        if (IsCountingDown)
        {
            CheckHearts();
        }
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
        if (FullHeart > TimeStamp && LiveCount < 1)
        {
            LiveCount++;
            PlayerPrefs.SetInt("LiveCount", AddPlayCount);
        }
        //                              plus 20 minutes
        else if (FullHeart > TimeStamp + 1199100000 && LiveCount < 2)
        {
            //  SetFullCounter();
            LiveCount++;
            PlayerPrefs.SetInt("LiveCount", AddPlayCount);
        }
        //                               plus 40 minutes
        else if (FullHeart > TimeStamp + 2398200000 && LiveCount < 3)
        {
            //  SetFullCounter();
            LiveCount++;
            IsCountingDown = false;

            PlayerPrefs.SetInt("LiveCount", AddPlayCount);
        }
    }
    // Countsdown the time until heart is ready
    void Countdown()
    {
        int TimeTillResetAd = unchecked((int)MinutesFromTs);
        CurrentTime -= Time.deltaTime;
        // Checks the time every  5 seconds to avoid sending to much info to the server
        if (CurrentTime < 0)
        {
            GetCurrentTime();
        }
        // Displays the current tick time into minutes and hours
        if (TimeTillResetAd != 0)
        {
            int Minutes = (int)(TimeTillResetAd % 60);
            int Hours = (int)((TimeTillResetAd / 60));
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
            TimeSpan TimeTillRegen = TimeSpan.FromTicks(TimeStamp - FullHeart);
            // Gets how long until the time is up
            MinutesFromTs = TimeTillRegen.TotalMinutes;
            // Resets cool down timer to avoid sending too much infomation to the server
            CurrentTime = 5;
        }, null);
    }
     
    public void SetFullCounter()
    {

        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            // Current time
            DateTime now = result.Time.AddHours(0);
            // 20 minutes is set 
            long Period = 10L * 1199100000;
            // Timestamp is equal current time plus target time
            TimeStamp = now.Ticks + Period;
            // converts the time in ticks to actual time
            TimeSpan Ts = TimeSpan.FromTicks(Period);
            // Shows how many minutes 
            MinutesFromTs = Ts.TotalMinutes;
            //Saves Timestamp
            PlayerPrefs.SetString("TimeUntilLives", "" + TimeStamp);

        }, null);



    }
}