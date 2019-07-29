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
    [HideInInspector]
    public bool StartCountDown;
    public Text TimerText;
    public GameObject UnlockMoobling;

    private float CurrentTime;
    private int EggNumber;
    double MinutesFromTs;
    private  DateTime now; 
    private  long Period;
    [HideInInspector]
    public long TimeStamp;
    [HideInInspector]
    public long NowTime;
    private string UnlockedCompanion;
    TimeSpan TimeTillEggHatch;
    public List<string> EggCreatures;
     // Use this for initialization
    void Start()
    {
        
        CurrentTime = 1;
        TimeStamp = System.Convert.ToInt64(PlayerPrefs.GetString("EggHatch"));
        StartCountDown = (PlayerPrefs.GetInt("EGGCOUNTDOWN") != 0);
        if (TimerText.text == "New Text")
        {
            TimerText.text = "loading...";
        }
    }

    private void Update()
    {
        // Changes timer text until the server grabs current time
     
        StartCountDown = (PlayerPrefs.GetInt("EGGCOUNTDOWN") != 0);
        //debug starts and ends timer
        if(Input.GetKeyDown(KeyCode.W))
        {
            CountDownTimer();
       
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCountDown = false;
       
            HatchCreature();
        }
        // begins countdown
        if (StartCountDown)
        {

            CurrentTime -= Time.deltaTime;
 
            int TimeTillHatch = unchecked((int)MinutesFromTs);
            if (TimeTillHatch != 0)
            {
                // test -= (int)Time.deltaTime;
                int Minutes = (int)(TimeTillHatch % 60);
                int Hours = (int)((TimeTillHatch / 60));
                TimerText.text = Hours + ":" + Minutes;
            }
            // if the time is greater than time stamp hatch egg
            if (NowTime > TimeStamp)
            {
                StartCountDown = false;

                Debug.Log(NowTime);
                Debug.Log(TimeStamp);
                Debug.Log("fnished");
                HatchCreature();

            }
         
            // Gets time every second
            if (CurrentTime < 0)
            {
                GetCurrentTime();
            }
            // MinutesFromTs = TimeTillEggHatch.TotalMinutes;
        }

    }
    public void CountDownTimer()
    {
        StartCountdownTimer();
    }
    void HatchCreature()
    {
        // selects random index for creature
        int Random = UnityEngine.Random.Range(0, EggCreatures.Count);
        UnlockedCompanion = EggCreatures[Random] ;
        // Grabs the unlocked companion using its string
        switch (UnlockedCompanion)
        {
            case "Crius":
                //TODO
                //SPLASH EGG HATCH ON SCREEEN
                //ADD COMPANION TO LIST
                PlayerPrefs.SetString("UNLOCKED", "CRIUS");
                UnlockMoobling.GetComponent<UnlockableCreatures>().Unlock();
                EggCreatures.RemoveAt(Random);
                Debug.Log("CRUAS");
                break;

            case "Sauco":
                PlayerPrefs.SetString("UNLOCKED", "SAUCO");

                UnlockMoobling.GetComponent<UnlockableCreatures>().Unlock();
                EggCreatures.RemoveAt(Random);
                Debug.Log("Sauce");

                break;

            case "ChickPee":
                PlayerPrefs.SetString("UNLOCKED", "CHICKPEA");

                UnlockMoobling.GetComponent<UnlockableCreatures>().Unlock();
                EggCreatures.RemoveAt(Random);
                Debug.Log("ChickePee");

                break;
            case "Squishy":
                PlayerPrefs.SetString("UNLOCKED", "SQUISHY");

                UnlockMoobling.GetComponent<UnlockableCreatures>().Unlock();
                EggCreatures.RemoveAt(Random);
                Debug.Log("Sqash");

                break;
            case "Okami":
                PlayerPrefs.SetString("UNLOCKED", "OKAMI");

                UnlockMoobling.GetComponent<UnlockableCreatures>().Unlock();
                EggCreatures.RemoveAt(Random);
                Debug.Log("Okamzzz");

                break;
        }
        // saves the egg countdown status(in this case its ended)
        PlayerPrefs.SetInt("EGGCOUNTDOWN", (StartCountDown ? 1 : 0));

    }
    // checks the current time on server
   public void GetCurrentTime()
    {
        // gets the current time for countdown
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            // Gets current time to countup 
            now = result.Time.AddHours(0); // GMT+1
            NowTime = now.Ticks;
            TimeTillEggHatch = TimeSpan.FromTicks(TimeStamp - NowTime);
            MinutesFromTs = TimeTillEggHatch.TotalMinutes;
           // TimerText.text = "" + MinutesFromTs;
            CurrentTime = 5;

        }, null);
    }
    // begins countdown 
    void StartCountdownTimer()
    {
        StartCountDown = true;
        PlayerPrefs.SetInt("EGGCOUNTDOWN", (StartCountDown ? 1 : 0));
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            // Eggnumber is the current egg being hatched (WILL CHANGE TO ARRAY THE MORE EGGS WE HAVE)ssssss
           //EggNumber = 1;
           //Current time 
            now = result.Time.AddHours(0);
            // Target Time
            Period = 36L * 3000000000L ;
            TimeStamp = now.Ticks + Period;
            TimeSpan ts = TimeSpan.FromTicks(Period);
            MinutesFromTs = ts.TotalMinutes;
       
            // sets egghatch save to timestamp    PLUS ARRAY NUM
            PlayerPrefs.SetString("EggHatch", "" + TimeStamp);
           

        }, null);

    }

}