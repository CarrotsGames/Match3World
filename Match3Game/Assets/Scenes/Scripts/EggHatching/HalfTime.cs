using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PlayFab;
using PlayFab.AuthenticationModels;
using PlayFab.ClientModels;
public class HalfTime : MonoBehaviour
{
    [HideInInspector]
    public GameObject PowerUpManagerGameObj;
    [HideInInspector]
    public PowerUpManager PowerUpManagerScript;
    public int[] Prices;
    private void Start()
    {
        PowerUpManagerGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManagerGameObj.GetComponent<PowerUpManager>();
    }

    private void Update()
    {
       
    }


    public void CutTime()
    {
            PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
            {
                // Gets current time to countup 
               DateTime now = result.Time.AddHours(0); // GMT+1
               long NowTime = now.Ticks;
               TimeSpan TimeTillEggHatch = TimeSpan.FromTicks(GetComponent<EggHatch>().TimeStamp - NowTime);
                double MinutesFromHatching = TimeTillEggHatch.TotalMinutes;       
                MinutesFromHatching /= 2;
                TimeSpan interval = TimeSpan.FromMinutes(MinutesFromHatching);
                long Re = GetComponent<EggHatch>().TimeStamp -= interval.Ticks;
                GetComponent<EggHatch>().TimeStamp = Re;
                //GetComponent<EggHatch>().TimeStamp
                PlayerPrefs.SetString("EggHatch", "" + GetComponent<EggHatch>().TimeStamp);
                GetComponent<EggHatch>().GetCurrentTime();
            }, null);
         

    }
    public void SkipTime()
    {
        // Gets the time until egghatches
        long Result = GetComponent<EggHatch>().TimeStamp - GetComponent<EggHatch>().NowTime;
        TimeSpan ts = TimeSpan.FromTicks(Result);
        double MinutesFromTs = ts.TotalMinutes;
        if (MinutesFromTs < 60)
        {
            //SPAWN BUY BUTTON FOR THIS ONE
            if (PowerUpManagerScript.Currency > Prices[0])
            {
                PowerUpManagerScript.Currency -= Prices[0];
                Debug.Log("Under60");
                // Makes current time greater than time stamp, hatching the egg
                GetComponent<EggHatch>().TimeStamp = GetComponent<EggHatch>().NowTime - 10000000;
            }
            else
            {
                Debug.Log("Insufficient Funds");
                //SPAWN SCREEN WHICH CAN LEAD PLAYER TO STORE?

            }
        }
        else if (MinutesFromTs >= 60 && MinutesFromTs < 120)
        {
            //SPAWN BUY BUTTON FOR THIS ONE
            if (PowerUpManagerScript.Currency > Prices[1])
            {
                PowerUpManagerScript.Currency -= Prices[1];
                Debug.Log("Under60");
                // Makes current time greater than time stamp, hatching the egg
                GetComponent<EggHatch>().TimeStamp = GetComponent<EggHatch>().NowTime - 10000000;
            }
            else
            {
                Debug.Log("Insufficient Funds");
                //SPAWN SCREEN WHICH CAN LEAD PLAYER TO STORE?

            }

        }
        else if (MinutesFromTs >= 120 && MinutesFromTs <= 180)
        {
            //SPAWN BUY BUTTON FOR THIS ONE
            if (PowerUpManagerScript.Currency > Prices[2])
            {
                PowerUpManagerScript.Currency -= Prices[2];
                Debug.Log("Under60");
                GetComponent<EggHatch>().TimeStamp = GetComponent<EggHatch>().NowTime - 10000000;
            }
            else
            {
                Debug.Log("Insufficient Funds");
                //SPAWN SCREEN WHICH CAN LEAD PLAYER TO STORE?

            }

        }
     }
  
}
