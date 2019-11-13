using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using PlayFab;
using PlayFab.AuthenticationModels;
using PlayFab.ClientModels;
public class EggTimerOptions : MonoBehaviour
{
    [HideInInspector]
    public GameObject PowerUpManagerGameObj;
    [HideInInspector]
    public PowerUpManager PowerUpManagerScript;
    public int[] Prices;
    public int[] HalfTimePrice;
    [HideInInspector]
    public bool HasHalfedTime;
    public Text[] PriceTags;
    public Button SkipButton;
    public Button HalfButton;
    private void Start()
    {
     
        PowerUpManagerGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManagerGameObj.GetComponent<PowerUpManager>();
        HasHalfedTime = (PlayerPrefs.GetInt("HalfTime") != 0);
        if(HasHalfedTime)
        {
            SkipButton.transform.position -= new Vector3(10, 0,0);
            HalfButton.gameObject.SetActive(false);
            PriceTags[1].gameObject.SetActive(false);
        }

    }

    public void ResetButtonPos()
    {
        // moves skip button back to its default position if halfed time
        if (HalfButton.gameObject.activeSelf == false)
        {
            SkipButton.transform.position += new Vector3(10, 0, 0);
        }
        // re enabled half time button and price regardless
        HalfButton.gameObject.SetActive(true);
        PriceTags[1].gameObject.SetActive(true);
        // makes price tags to default price
        PriceTags[0].text = "200";
        PriceTags[1].text = "100";
        // disabled buttons just in case players press Skip/half by mistake
        HalfButton.interactable = false;
        SkipButton.interactable = false;
    }
    public void SetPriceTime()
    {
     // gets time until egg hatches
        long Result = GetComponent<EggHatch>().TimeStamp - GetComponent<EggHatch>().NowTime;
        TimeSpan ts = TimeSpan.FromTicks(Result);
        double MinutesFromTs = ts.TotalMinutes;
        // 3 hours
        if (MinutesFromTs >= 120 && MinutesFromTs <= 180)
        {
            // SkipEgg
            PriceTags[0].text = "200";
            // HalfTime
            PriceTags[1].text = "100";

        }
        //2 hours 
        else if (MinutesFromTs >= 90 && MinutesFromTs <= 180)
        { 
            // SkipEgg
            PriceTags[0].text = "150";
            // HalfTime
            PriceTags[1].text = "75";
        }
        // 1 hour
        else if (MinutesFromTs >= 0 && MinutesFromTs < 90)
        {
            // SkipEgg
            PriceTags[0].text = "100";
            // HalfTime
            PriceTags[1].text = "75";
        }
        // enabled buttons to be pressed when correct price is listed
        HalfButton.interactable = true;
        SkipButton.interactable = true;
    }
    public void HalfTime()
    {
        if (PlayFabLogin.HasLoggedIn == true)
        {
            // gets time until egg hatches

            long Result = GetComponent<EggHatch>().TimeStamp - GetComponent<EggHatch>().NowTime;
            TimeSpan ts = TimeSpan.FromTicks(Result);
            double MinutesFromTs = ts.TotalMinutes;
            if (!HasHalfedTime)
            {
                // if the timer is between 1.5 and 3 hours
                if (MinutesFromTs >= 90 && MinutesFromTs <= 180)
                {
                    if (PowerUpManagerScript.Currency >= HalfTimePrice[0])
                    {
                        PowerUpManagerScript.Currency -= HalfTimePrice[0];
                        CutCurrentTime();
                        HasHalfedTime = true;
                        HalfButton.gameObject.SetActive(false);
                        SkipButton.transform.position -= new Vector3(10, 0, 0);
                        PriceTags[1].gameObject.SetActive(false);
                    }
                }
                // if the timer is between 0 and 1.4 hours
                else if (MinutesFromTs >= 0 && MinutesFromTs < 90)
                {
                    if (PowerUpManagerScript.Currency >= HalfTimePrice[1])
                    {
                        PowerUpManagerScript.Currency -= HalfTimePrice[1];
                        CutCurrentTime();
                        HasHalfedTime = true;
                        HalfButton.gameObject.SetActive(false);
                        SkipButton.transform.position -= new Vector3(10, 0, 0);
                        PriceTags[1].gameObject.SetActive(false);
                    }
                }
                PowerUpManagerScript.PowerUpSaves();
                PlayerPrefs.SetInt("HalfTime", (HasHalfedTime ? 1 : 0));
            }


        }
    }
    public void SkipTime()
    {
        if (PlayFabLogin.HasLoggedIn == true)
        {
            Debug.Log("Skip");
            // Gets the time until egghatches
            long Result = GetComponent<EggHatch>().TimeStamp - GetComponent<EggHatch>().NowTime;
            TimeSpan ts = TimeSpan.FromTicks(Result);
            double MinutesFromTs = ts.TotalMinutes;
            if (MinutesFromTs < 60)
            {
                //SPAWN BUY BUTTON FOR THIS ONE
                if (PowerUpManagerScript.Currency >= Prices[0])
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
                if (PowerUpManagerScript.Currency >= Prices[1])
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
                if (PowerUpManagerScript.Currency >= Prices[2])
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
            PowerUpManagerScript.PowerUpSaves();
        }
    }
        // Goes through the process of halfing the time
        public void CutCurrentTime()
    {
        if (PlayFabLogin.HasLoggedIn == true)
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
        },
        null);
        }
    }


}

 
