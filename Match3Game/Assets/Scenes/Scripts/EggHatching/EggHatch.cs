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
    public static bool StartCountDown;
    public Text TimerText;
    public GameObject UnlockMoobling;
    [HideInInspector]
    public GameObject PowerUpManager;

    public GameObject Congratulations;
    public GameObject CriusUnlockImage;
    public GameObject OkamiUnlockImage;
    public GameObject SaucoUnlockImage;
    public GameObject ChickPeaUnlockImage;
    public GameObject SquishyUnlockImage;
    public GameObject MoneyUnlockImage;
    private GameObject BuyButton;
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
    void Awake()
    {
         
        CurrentTime = 1;
        PowerUpManager = GameObject.FindGameObjectWithTag("PUM");
        TimeStamp = System.Convert.ToInt64(PlayerPrefs.GetString("EggHatch"));
        StartCountDown = (PlayerPrefs.GetInt("EGGCOUNTDOWN") != 0);

        if (GameObject.Find("StoreEgg") == null)
        {
            BuyButton = GameObject.Find("BuyEggButton");

            if (TimerText.text == "New Text")
            {
                TimerText.text = "loading...";
            }
        }
        if(!StartCountDown)
        {
            TimerText.text = "Buy an egg?";
        }
        else
        {
            TimerText.text = "loading";
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Alpha4))
        {
            StartCountDown = true;
        }
        if (GameObject.Find("StoreEgg") == null)
        {
            if (PlayFabLogin.HasLoggedIn == true)
            {
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

                        PlayerPrefs.SetString("EggHatch", "" + TimeStamp);

                        Debug.Log("OVER");
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
                else
                {
                   // BuyButton = GameObject.Find("BuyEggButton");

 
                    BuyButton.GetComponent<Button>().enabled = true;
                    BuyButton.gameObject.SetActive(true);
 
                    TimerText.text = "Buy an egg?";
 

                }
            }
      
        }
    }

    void HatchCreature()
    {
        NowTime = 0;
        TimeStamp = 0;
        MinutesFromTs = 0;
        GetComponent<EggTimerOptions>().HasHalfedTime = false;
        PlayerPrefs.SetInt("HalfTime", (false ? 1 : 0));

        // selects random index for creature
        int Random = UnityEngine.Random.Range(0, EggCreatures.Count);
        UnlockedCompanion = EggCreatures[Random] ;
        // Grabs the unlocked companion using its string
        Congratulations.SetActive(true);

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
                    CriusUnlockImage.SetActive(true);
                }
                else
                {
                    Debug.Log("DUPECRIUS");

                    PowerUpManager.GetComponent<PowerUpManager>().Currency += 150;
                    MoneyUnlockImage.SetActive(true); 
                }
                break;

            case "Sauco":
                if (UnlockMoobling.GetComponent<UnlockableCreatures>().UnlockableMoobling[3] != "SAUCO")
                {
                    PlayerPrefs.SetString("UNLOCKED", "SAUCO");

                    UnlockMoobling.GetComponent<UnlockableCreatures>().Unlock();
                    EggCreatures.RemoveAt(Random);
                    SaucoUnlockImage.SetActive(true);
                    Debug.Log("Sauce");
                }
                else
                {
                    Debug.Log("DUPESAUCE");

                    PowerUpManager.GetComponent<PowerUpManager>().Currency += 150;
                    MoneyUnlockImage.SetActive(true);

                }
                break;

            case "ChickPee":
                if (UnlockMoobling.GetComponent<UnlockableCreatures>().UnlockableMoobling[4] != "CHICKPEA")
                {
                    PlayerPrefs.SetString("UNLOCKED", "CHICKPEA");

                    UnlockMoobling.GetComponent<UnlockableCreatures>().Unlock();
                    EggCreatures.RemoveAt(Random);
                    ChickPeaUnlockImage.SetActive(true); 
                    Debug.Log("ChickePee");
                }
                else
                {
                    Debug.Log("DUPECHICKPEA");

                    PowerUpManager.GetComponent<PowerUpManager>().Currency += 150;
                    MoneyUnlockImage.SetActive(true);

                }
                break;
            case "Squishy":
                if (UnlockMoobling.GetComponent<UnlockableCreatures>().UnlockableMoobling[5] != "SQUISHY")
                {
                    PlayerPrefs.SetString("UNLOCKED", "SQUISHY");

                    UnlockMoobling.GetComponent<UnlockableCreatures>().Unlock();
                    EggCreatures.RemoveAt(Random);
                    SquishyUnlockImage.SetActive(true);
                    Debug.Log("Sqash");
                }
                else
                {
                    Debug.Log("DUPECSQUISHY");

                    PowerUpManager.GetComponent<PowerUpManager>().Currency += 150;
                    MoneyUnlockImage.SetActive(true);

                }
                break;
            case "Okami":
                if (UnlockMoobling.GetComponent<UnlockableCreatures>().UnlockableMoobling[7] != "OKAMI")
                {
                    PlayerPrefs.SetString("UNLOCKED", "OKAMI");

                    UnlockMoobling.GetComponent<UnlockableCreatures>().Unlock();
                    EggCreatures.RemoveAt(Random);
                    OkamiUnlockImage.SetActive(true);
                    Debug.Log("Okamzzz");
                }
                else
                {
                    Debug.Log("DUPEOKAMI");

                    PowerUpManager.GetComponent<PowerUpManager>().Currency += 150;
                    PowerUpManager.GetComponent<PowerUpManager>().PowerUpSaves();
                    MoneyUnlockImage.SetActive(true);

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
            GetComponent<EggTimerOptions>().SetPriceTime();
            ;
        }, null);
    }
    // begins countdown 
    public void CountDownTimer()
    {
        GetComponent<EggTimerOptions>().ResetButtonPos();
        GetComponent<EggTimerOptions>().SetPriceTime();
        StartCountDown = true;
        CurrentTime = 5;
        // gives timestamp a head start to not end timer right away
        //(Timer ends when nowtime > timestamp)
        
        TimeStamp = 100;
        NowTime = 0 ;
        PlayerPrefs.SetInt("EGGCOUNTDOWN", (StartCountDown ? 1 : 0));
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {

            // Eggnumber is the current egg being hatched (WILL CHANGE TO ARRAY THE MORE EGGS WE HAVE)ssssss
            //EggNumber = 1;
            //Current time 
            now = result.Time.AddHours(0);

            // Target Time
            Period = 36L * 3000000000L;
            TimeStamp = now.Ticks + Period;
            TimeSpan ts = TimeSpan.FromTicks(Period);
            NowTime = now.Ticks;
            MinutesFromTs = ts.TotalMinutes;

            // sets egghatch save to timestamp    PLUS ARRAY NUM
            PlayerPrefs.SetString("EggHatch", "" + TimeStamp);


        }, null);
    }
 

}