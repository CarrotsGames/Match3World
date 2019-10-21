using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.AuthenticationModels;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
public class FreezeMultiplier : MonoBehaviour
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
    private GameObject PowerUpManagerGameObj;
    private GameObject DisablePowerUpGameObj;
    private PowerUpManager PowerUpManagerScript;
    int Multipliersave;
    public Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        Multipliersave = PlayerPrefs.GetInt("SavedMultlpier");
        DisablePowerUpGameObj = GameObject.Find("PowerUps");
        CurrentTime = 1;
        SlowDownTime = false;
        SlowDownTime = PlayerPrefs.GetInt("FreezeMultlpier") != 0;
        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        PowerUpManagerGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManagerGameObj.GetComponent<PowerUpManager>();

        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        HappinessManagerScript = HappinessGameObj.GetComponent<HappyMultlpier>();
        TimeStamp = System.Convert.ToInt64(PlayerPrefs.GetString("SDTimer"));
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            NowTime = TimeStamp + 100000000;
        }
        if (SlowDownTime)
        {
            DisplayTime();
            // disabled button
            GetComponent<Button>().enabled = false;
            // changes button to gray
            GetComponent<Image>().color = Color.gray;
            // Loads the saved mutlpier value
            Multipliersave = PlayerPrefs.GetInt("SavedMultlpier");
            // assigns the Multipier that value
 
        
            // if the current time is greater than target time end powerup
            if (NowTime > TimeStamp)
            {
                DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableFreeze = false;
                DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM = false;

                PlayerPrefs.SetInt("DISABLEFREEZE", (DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableFreeze ? 1 : 0));
                PlayerPrefs.SetInt("DISABLESM", (DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM ? 1 : 0));
                DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableNodes();

                TimerText.text = "";
                Debug.Log("TIMES OVER");
                SlowDownTime = false;
                PlayerPrefs.SetInt("FreezeMultlpier", (SlowDownTime ? 1 : 0));
            }

            CurrentTime -= Time.deltaTime;
            // Gets time every few seconds
            if (CurrentTime < 0)
            {
                GetCurrentTime();
            }
        }
        else
        {
         //   GetComponent<Button>().enabled = true;
         //   GetComponent<Image>().color = Color.white;

          //  SlowDownTime = false;
          //  PlayerPrefs.SetInt("FreezeMultlpier", (SlowDownTime ? 1 : 0));
        }
    }
    public void DisplayTime()
    {
        // converts the tick time to minutes
        TimeTillHatch = unchecked((int)MinutesFromTs);
        if (TimeTillHatch != 0)
        {
            //displays the minutes and hours in game
            int Minutes = (int)(TimeTillHatch % 60);
            int Hours = (int)((TimeTillHatch / 60));
            TimerText.text = Hours + ":" + Minutes;
        }
    }
    // Update is called once per frame
   public void FreezeMultlpier()
    {
        if (!SlowDownTime)
        {
            if (PowerUpManagerScript.HasFreezeMultlpliers)
            {
                DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableFreeze = true;
                DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM = true;

                PlayerPrefs.SetInt("DISABLEFREEZE", (DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableFreeze ? 1 : 0));
                PlayerPrefs.SetInt("DISABLESM", (DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM ? 1 : 0));
                DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableNodes();

              
                SlowDownTime = true;
                PlayerPrefs.SetInt("FreezeMultlpier", (SlowDownTime ? 1 : 0));
                StartCountdownTimer();
            }
            else
            {
                Debug.Log("Got no FreezeMultplier");
            }
        }
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
 
          // now is equal to current time
          DateTime now = result.Time.AddHours(0);
          // Target Time (3 hours)
          long Period = 36L * 1000000000L;
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