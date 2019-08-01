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
    public GameObject PowerUpManager;

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
        PowerUpManager = GameObject.FindGameObjectWithTag("PUM");
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
                PlayerPrefs.SetInt("EGGCOUNTDOWN", (StartCountDown ? 1 : 0));

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
        GetComponent<EggTimerOptions>().HasHalfedTime = false;
        PlayerPrefs.SetInt("HalfTime", (GetComponent<EggTimerOptions>().HasHalfedTime ? 1 : 0));

        // selects random index for creature
        int Random = UnityEngine.Random.Range(0, EggCreatures.Count);
        UnlockedCompanion = EggCreatures[Random] ;
        // Grabs the unlocked companion using its string
        switch (UnlockedCompanion)
        {
            case "Crius":
                if (UnlockMoobling.GetComponent<UnlockableCreatures>().CriusUnlocked != "CRIUS")
                {
                    //TODO
                    //SPLASH EGG HATCH ON SCREEEN
                    //ADD COMPANION TO LIST
                    PlayerPrefs.SetString("UNLOCKED", "CRIUS");
                    UnlockMoobling.GetComponent<UnlockableCreatures>().Unlock();
                    EggCreatures.RemoveAt(Random);
                    Debug.Log("CRUAS");
                }
                else
                {
                    Debug.Log("DUPECRIUS");

                    PowerUpManager.GetComponent<PowerUpManager>().Currency += 150;
                }
                break;

            case "Sauco":
                if (UnlockMoobling.GetComponent<UnlockableCreatures>().UnlockableMoobling[3] != "SAUCO")
                {
                    PlayerPrefs.SetString("UNLOCKED", "SAUCO");

                    UnlockMoobling.GetComponent<UnlockableCreatures>().Unlock();
                    EggCreatures.RemoveAt(Random);
                    Debug.Log("Sauce");
                }
                else
                {
                    Debug.Log("DUPESAUCE");

                    PowerUpManager.GetComponent<PowerUpManager>().Currency += 150;
                }
                break;

            case "ChickPee":
                if (UnlockMoobling.GetComponent<UnlockableCreatures>().UnlockableMoobling[4] != "CHICKPEA")
                {
                    PlayerPrefs.SetString("UNLOCKED", "CHICKPEA");

                    UnlockMoobling.GetComponent<UnlockableCreatures>().Unlock();
                    EggCreatures.RemoveAt(Random);
                    Debug.Log("ChickePee");
                }
                else
                {
                    Debug.Log("DUPECHICKPEA");

                    PowerUpManager.GetComponent<PowerUpManager>().Currency += 150;
                }
                break;
            case "Squishy":
                if (UnlockMoobling.GetComponent<UnlockableCreatures>().UnlockableMoobling[5] != "SQUISHY")
                {
                    PlayerPrefs.SetString("UNLOCKED", "SQUISHY");

                    UnlockMoobling.GetComponent<UnlockableCreatures>().Unlock();
                    EggCreatures.RemoveAt(Random);
                    Debug.Log("Sqash");
                }
                else
                {
                    Debug.Log("DUPECSQUISHY");

                    PowerUpManager.GetComponent<PowerUpManager>().Currency += 150;
                }
                break;
            case "Okami":
                if (UnlockMoobling.GetComponent<UnlockableCreatures>().UnlockableMoobling[7] != "OKAMI")
                {
                    PlayerPrefs.SetString("UNLOCKED", "OKAMI");

                    UnlockMoobling.GetComponent<UnlockableCreatures>().Unlock();
                    EggCreatures.RemoveAt(Random);
                    Debug.Log("Okamzzz");
                }
                else
                {
                    Debug.Log("DUPEOKAMI");

                    PowerUpManager.GetComponent<PowerUpManager>().Currency += 150;
                }
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