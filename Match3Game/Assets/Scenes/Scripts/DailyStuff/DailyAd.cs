using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.UI;
public class DailyAd : MonoBehaviour
{
    public Text DailyAdPlays;
    public PowerUpManager PowerUpManagerScript;
    public string gameId = "3222685";
    public string placementId;
    long TimeStamp;
    long NowTime;
    public bool testMode = false;
    private float CurrentTime;
    double MinutesFromTs;
    public int AddPlayCount;
    //Located in Canvas
    private void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        CurrentTime = 3;
        TimeStamp = System.Convert.ToInt64(PlayerPrefs.GetString("TimeTilAd"));
        AddPlayCount = PlayerPrefs.GetInt("TotalAdPlays");
    }
    private void Update()
    {
        // Diplsays a temp text until it gets the current time
        if (DailyAdPlays.text == "New Text")
        {
            DailyAdPlays.text = "Getting \n time....";
        }
        int TimeTillResetAd = unchecked((int)MinutesFromTs);
        CurrentTime -= Time.deltaTime;

        // if the time has passed the target time
        if (NowTime > TimeStamp)
        {
            // resets 
            AddPlayCount = 0;
            PlayerPrefs.SetInt("TotalAdPlays", AddPlayCount);

        }
        else
        {
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
                DailyAdPlays.text = Hours + ":" + Minutes;
            }
        }
    }
    void GetCurrentTime()
    {
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            // current time 
            DateTime now = result.Time.AddHours(0);
            // Converts current time into ticks
            NowTime = now.Ticks;
            // Deducts now time from target time
            TimeSpan TimeTillSpin = TimeSpan.FromTicks(TimeStamp - NowTime);
            // Gets how long until the time is up
            MinutesFromTs = TimeTillSpin.TotalMinutes;
            // Resets cool down timer to avoid sending too much infomation to the server
            CurrentTime = 5;
        }, null);
    }
    // adds currency earned by tournament 
    public void SetResetTimer()
    {

        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            // Current time
            DateTime now = result.Time.AddHours(0);
            // 24 hours written in longs (Will try to make it easier to understand)
            long Period = 36L * 24000000000L;
            // Timestamp is equal current time plus target time
            TimeStamp = now.Ticks + Period;
            // converts the time in ticks to actual time
            TimeSpan Ts = TimeSpan.FromTicks(Period);
            // Shows how many minutes 
            MinutesFromTs = Ts.TotalMinutes;
            //Saves Timestamp
            PlayerPrefs.SetString("TimeTilAd", "" + TimeStamp);

        }, null);



    }
    public void PlayAdNow()
    {
        if (AddPlayCount < 1)
        {
            PowerUpManagerScript.GetComponent<PowerUpManager>().Currency += 5;
            // Adds to how many adds can be played 
            AddPlayCount++;
            // Sets a target time 24 hours from now
            SetResetTimer();
            // Plays Add
            Advertisement.Show(placementId);

        }
        else if (AddPlayCount < 3)
        {
            PowerUpManagerScript.GetComponent<PowerUpManager>().Currency += 5;

            // Adds to how many adds can be played 
            AddPlayCount++;
            Advertisement.Show(placementId);
            Debug.Log("PLAYED AD");
        }
        else if (AddPlayCount >= 3)
        {
            //PUT UI HERE
            //COME BACK TOMORROW FOR YOUR FREE COINS
        }
        // saves number of times ad has been played
        PlayerPrefs.SetInt("TotalAdPlays", AddPlayCount);
    }
}