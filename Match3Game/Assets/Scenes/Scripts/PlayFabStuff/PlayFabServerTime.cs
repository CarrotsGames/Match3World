using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.UI;
// DAILY SPIN TIMER (MUST RENAME THIS)
public class PlayFabServerTime : MonoBehaviour {
    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;
    private DotManager DotManagerScript;
    int DailySpinCount;
    private EventScript DailyEvent;
    private GameObject Events;
    public string SaveBool;
    float DelayTimer;
    double MinutesFromTs;
    public Text DailySpinTimer;
    private float CurrentTime;
    long TimeStamp;
    long NowTime;
     // Use this for initialization
    void Start () {
        DailySpinCount = PlayerPrefs.GetInt("DAILYSPINCOUNTER");
        Events = GameObject.FindGameObjectWithTag("ES");
        DailyEvent = Events.GetComponent<EventScript>();
        DailyEvent.CanDoDaily = (PlayerPrefs.GetInt(SaveBool) != 0);
        DelayTimer = 3;
        CurrentTime = 3;
        TimeStamp = System.Convert.ToInt64(PlayerPrefs.GetString("DailySpinTime"));

        DailyEvent.CanDoDaily = false;
    
    }
    public void DoTheDailySpinDebug()
    {
        DailyEvent.CanDoDaily = true;
    }
    void Update()
    {
        if (PlayFabLogin.HasLoggedIn == true)
        {
            if (DailySpinTimer.text == "New Text")
            {
                DailySpinTimer.text = "Getting \n time....";
            }
            CurrentTime -= Time.deltaTime;
            int TimeTillSpin = unchecked((int)MinutesFromTs);


            if (CurrentTime < 0 && !DailyEvent.CanDoDaily)
            {
                GetCurrentTime();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                NowTime = TimeStamp + 100000000000000;
            }

            if (NowTime > TimeStamp)
            {

                DailyEvent.CanDoDaily = true;
                DailySpinTimer.text = "Spin \n ready!!";

            }
            else
            {
                if (TimeTillSpin != 0)
                {
                    int Minutes = (int)(TimeTillSpin % 60);
                    int Hours = (int)((TimeTillSpin / 60));
                    DailySpinTimer.text = Hours + ":" + Minutes;
                }
            }
        }
        else
        {
            DailySpinTimer.text = "offline";
        }
    }

 
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
    }

    private void OnLoginFailure(PlayFabError error)
    {

        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
    void GetCurrentTime()
    {
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            DateTime now = result.Time.AddHours(0);
            NowTime = now.Ticks;
            TimeSpan TimeTillSpin = TimeSpan.FromTicks(TimeStamp - NowTime);
            MinutesFromTs = TimeTillSpin.TotalMinutes;
            CurrentTime = 5;
        }, null);
    }
    // adds currency earned by tournament 
    public void DailySpin()
    {

        if (PlayFabLogin.HasLoggedIn == true)
        {

            PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
     
            {

                DateTime now = result.Time.AddHours(0);
                DateTime TargetTime = result.Time.AddHours(24);
                long Period = 36L * 24000000000L;
                TimeStamp = now.Ticks + Period;
                TimeSpan Ts = TimeSpan.FromTicks(Period);
                MinutesFromTs = Ts.TotalMinutes;
                PlayerPrefs.SetString("DailySpinTime", "" + TimeStamp);


            }
            , null);

        }

    }
 
  
}
