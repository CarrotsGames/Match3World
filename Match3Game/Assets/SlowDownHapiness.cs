using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.AuthenticationModels;
using PlayFab.ClientModels;
using System;
public class SlowDownHapiness : MonoBehaviour
{
    public bool SlowDownTime;
     [SerializeField]
    private int TimeTillHatch;
    private long TimeStamp;
    private long NowTime;
    private float CurrentTime;
    private double MinutesFromTs;
    private TimeSpan TimeTillEggHatch;
    private GameObject HappinessGameObj;
    public HappyMultlpier HappinessManagerScript;
    private GameObject DotManagerObj;
    private DotManager DotManagerScript;
    int Multipliersave;
    // Start is called before the first frame update
    void Start()
    {
        Multipliersave = PlayerPrefs.GetInt("SavedMultlpier");
        CurrentTime = 1;
        SlowDownTime = false;
        SlowDownTime = PlayerPrefs.GetInt("FreezeMultlpier") != 0;
        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");

        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        HappinessManagerScript = HappinessGameObj.GetComponent<HappyMultlpier>();
        TimeStamp = System.Convert.ToInt64(PlayerPrefs.GetString("SDTimer"));

    }
    private void Update()
    {
        if (SlowDownTime)
        {
            Multipliersave = PlayerPrefs.GetInt("SavedMultlpier");

            DotManagerScript.Multipier = Multipliersave;
            CurrentTime -= Time.deltaTime;
            TimeTillHatch = unchecked((int)MinutesFromTs);
            if (NowTime > TimeStamp)
            {
                Debug.Log("TIMES OVER");
                SlowDownTime = false;
                PlayerPrefs.SetInt("FreezeMultlpier", (SlowDownTime ? 1 : 0));
            }

            // Gets time every second
            if (CurrentTime < 0)
            {
                GetCurrentTime();
            }
        }
        else
        {
            SlowDownTime = false;
            PlayerPrefs.SetInt("FreezeMultlpier", (SlowDownTime ? 1 : 0));
        }
    }
    // Update is called once per frame
   public void FreezeMultlpier()
    {
        SlowDownTime = true;
        PlayerPrefs.SetInt("FreezeMultlpier", (SlowDownTime ? 1 : 0));
        StartCountdownTimer();
    }
    // checks the current time on server
    void GetCurrentTime()
    {
        // gets the current time for countdown
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            // Gets current time to countup 
            DateTime now = result.Time.AddHours(0); // GMT+1
            NowTime = now.Ticks;
            TimeTillEggHatch = TimeSpan.FromTicks(TimeStamp - NowTime);
            MinutesFromTs = TimeTillEggHatch.TotalMinutes;
            // TimerText.text = "" + MinutesFromTs;
            CurrentTime = 5;

        }, null);
    }
    void StartCountdownTimer()
    {
         
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
          HappinessManagerScript.Multplier();

          // now is equal to current time
          DateTime now = result.Time.AddHours(0);
          // Target Time (3 hours)
          long Period = 36L * 3000000000L;
          // Timestamp is equal to now time plus 3 hours
          TimeStamp = now.Ticks + Period;
          // Convert the target time into ticks
          TimeSpan ts = TimeSpan.FromTicks(Period);
          // convert the ticks into minutes (180)
          MinutesFromTs = ts.TotalMinutes;
          // saves how long until egg hatches
          PlayerPrefs.SetString("SDTimer", "" + TimeStamp);

        }, null);

    }
}