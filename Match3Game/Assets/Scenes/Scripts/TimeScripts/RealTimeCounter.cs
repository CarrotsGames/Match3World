﻿using UnityEngine;
using System.Collections;
// Counts down happiness of each moobling
// used in HappinessManager, CompanionMonitorScript and CompanionNavigation
// Used in main scene
public class RealTimeCounter : MonoBehaviour
{
    //TestTimer
    //TEMP Holds each Happyness value from each companion
    public float[] HappinessCountDown;
   // public float TimerCountDown1;
   // public float TimerCountDown2;
    //public float DailyTimerCountDown;

    private float MultlpierCountdown;
    private GameObject HappinessGameObj;
    private GameObject MultiplierGameOb;
    private HappinessManager HappinessManagerScript;
    private SuperMultiplierScript SuperMultiplier;

    string companionName;

    public float SaveNum;
    // Use this for initialization
    void Start()
    {
        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
        MultiplierGameOb = GameObject.FindGameObjectWithTag("SM");
        SuperMultiplier = MultiplierGameOb.GetComponent<SuperMultiplierScript>();

        // Starting timer amount
        // Update timer with real time passed
        //TODO [Find a better way of doing this]

        //////////////////////// HOW TO SETUP THE SAVES/////////////////////////////
        //1 Assign a save to happinesscountdown array with new companion
        //2 Add a "TimeMasterScript.instance.CheckDate() / 25" to deduct that companions happiness
        //3 In this script go to happinessmanagerscript(line 74) switch and add a case with a save name
        //4 Now go into update and make the new happiness countdown (line 159 to end of update)
        //5 Then in update add an else if with that companion name and countdown the time (Make sure HappinessCountdown is set to right array)
        //6 Make that companon array equal the happiness slidervalue(happienssmetre)
        //7 In "happinessmanager" script go to companion save switch (line 51) and add that companion save 
        //8 Make sure the case is equal to the companions name in scene
        //9 Give that companion savestring name(savestring saves the sleeping bool for that companion)
        //10 Now go to the CompanionNaviagion script "PlayLevel" (Line 125) and add that companions name in the navigation menu 
        //with their arrays
        //11 Finally go to "CompanionSwitch" (Line 214) and add a case along with their happiness string and index.
        //  Make the happySlider.value equal that index
        ////////////////////////HAPPINESS COUNTDOWNS////////////////////////////////
       
        //Gobus Happiness Timer
        HappinessCountDown[0] = PlayerPrefs.GetFloat("GobuHappiness");
        // update timer when real time passes 
        HappinessCountDown[0] -= TimeMasterScript.instance.CheckDate() / 25;

        // Binkies Happiness Timer
        HappinessCountDown[1] = PlayerPrefs.GetFloat("BinkyHappiness");
        // update timer when real time passes 
        HappinessCountDown[1] -= TimeMasterScript.instance.CheckDate() / 25;

        // Kokos Happiness timer
        HappinessCountDown[2] = PlayerPrefs.GetFloat("KokoHappiness");
        // update timer when real time passes 
        HappinessCountDown[2] -= TimeMasterScript.instance.CheckDate() / 25;
       
        //Crius Happiness timer
        HappinessCountDown[3] = PlayerPrefs.GetFloat("CriusHappiness");
        // update timer when real time passes 
        HappinessCountDown[3] -= TimeMasterScript.instance.CheckDate() / 25;

        //Sauco Happiness Timer
        HappinessCountDown[4] = PlayerPrefs.GetFloat("SaucoHappiness");
        // update timer when real time passes 
        HappinessCountDown[4] -= TimeMasterScript.instance.CheckDate() / 25;

        //Sauco Happiness Timer
        HappinessCountDown[5] = PlayerPrefs.GetFloat("ChickPeaHappiness");
        // update timer when real time passes 
        HappinessCountDown[5] -= TimeMasterScript.instance.CheckDate() / 25;

        //  //Sauco Happiness Timer
        //  HappinessCountDown[6] = PlayerPrefs.GetFloat("SquishyHappiness");
        //  // update timer when real time passes 
        //  HappinessCountDown[6] -= TimeMasterScript.instance.CheckDate() / 25;
       
        //Cronos Happiness Timer
          HappinessCountDown[7] = PlayerPrefs.GetFloat("CronosHappiness");
          // update timer when real time passes 
          HappinessCountDown[7] -= TimeMasterScript.instance.CheckDate() / 25;
        /////////////////////////////////////////////////////////////////////

        HappinessGameObj.GetComponent<HappyMultlpier>().CheckMultplier();

        if (SuperMultiplier.MultlpierTimer > -1)
        {
            SuperMultiplier.MultlpierTimer = PlayerPrefs.GetFloat("SMTIMER");
            SuperMultiplier.MultlpierTimer -= TimeMasterScript.instance.CheckDate();
        }
 
        // loads companion happiness save        
        switch (HappinessManagerScript.CompanionSave)

        {
            case "GobuHappiness":

                HappinessManagerScript.HappinessSliderValue = HappinessCountDown[0];
                companionName = "GobuHappiness";

                break;
            case "BinkyHappiness":

                HappinessManagerScript.HappinessSliderValue = HappinessCountDown[1];
                companionName = "BinkyHappiness";


                break;
            case "KokoHappiness":

                HappinessManagerScript.HappinessSliderValue = HappinessCountDown[2];
                companionName = "KokoHappiness";

                break;
            case "CriusHappiness":

                HappinessManagerScript.HappinessSliderValue = HappinessCountDown[3];
                companionName = "CriusHappiness";

                break;

            case "SaucoHappiness":

                HappinessManagerScript.HappinessSliderValue = HappinessCountDown[4];
                companionName = "SaucoHappiness";

                break;

            case "ChickPeaHappiness":

                HappinessManagerScript.HappinessSliderValue = HappinessCountDown[5];
                companionName = "ChickPeaHappiness";

                break;
            case "CronosHappiness":

                HappinessManagerScript.HappinessSliderValue = HappinessCountDown[7];
                companionName = "CronosHappiness";

                break;
        }
    }
    // Counts down the happiness of each moobling
    // Update is called once per frame
    void Update()
    {
        // changes the HappinessSlider to that companions happiness
        if (companionName == "GobuHappiness")
        {
            HappinessCountDown[0] = HappinessManagerScript.HappinessSliderValue;
            PlayerPrefs.SetFloat("GobuHappiness", HappinessManagerScript.HappinessSliderValue);

        }
        else if (companionName == "BinkyHappiness")
        {
            HappinessCountDown[1] = HappinessManagerScript.HappinessSliderValue;

          //  HappinessCountDown[1] = HappinessManagerScript.HappinessSliderValue;

        }
        else if (companionName == "KokoHappiness")
        {
            HappinessCountDown[2] = HappinessManagerScript.HappinessSliderValue;

          //  HappinessCountDown[2] = HappinessManagerScript.HappinessSliderValue;


        }
        else if (companionName == "CriusHappiness")
        {
            HappinessCountDown[3] = HappinessManagerScript.HappinessSliderValue;

        }
        else if (companionName == "SaucoHappiness")
        {
            HappinessCountDown[4] = HappinessManagerScript.HappinessSliderValue;

        }
        else if (companionName == "ChickPeaHappiness")
        {
            HappinessCountDown[5] = HappinessManagerScript.HappinessSliderValue;

        }
        else if (companionName == "CronosHappiness")
        {
            HappinessCountDown[7] = HappinessManagerScript.HappinessSliderValue;

        }
        // COUNTS DOWN ALL COMPANION HAPPINESS WHILE NOT IN SCENE
        HappinessCountDown[0] = Mathf.Clamp(HappinessCountDown[0], 0, 100);
        // Update timer each frame by delay
        HappinessCountDown[0] -= Time.deltaTime / 10;
        PlayerPrefs.SetFloat("GobuHappiness", HappinessCountDown[0]);

        HappinessCountDown[1] = Mathf.Clamp(HappinessCountDown[1], 0, 100);
        // Update timer each frame by delay
        HappinessCountDown[1] -= Time.deltaTime / 10;
        PlayerPrefs.SetFloat("BinkyHappiness", HappinessCountDown[1]);

        HappinessCountDown[2] = Mathf.Clamp(HappinessCountDown[2], 0, 100);
        // Update timer each frame by delay
        HappinessCountDown[2] -= Time.deltaTime / 10;
        PlayerPrefs.SetFloat("KokoHappiness", HappinessCountDown[2]);

        HappinessCountDown[3] = Mathf.Clamp(HappinessCountDown[3], 0, 100);
        // Update timer each frame by delay
        HappinessCountDown[3] -= Time.deltaTime / 10;
        PlayerPrefs.SetFloat("CriusHappiness", HappinessCountDown[3]);

        HappinessCountDown[4] = Mathf.Clamp(HappinessCountDown[4], 0, 100);
        // Update timer each frame by delay
        HappinessCountDown[4] -= Time.deltaTime / 10;
        PlayerPrefs.SetFloat("SaucoHappiness", HappinessCountDown[4]);

        HappinessCountDown[5] = Mathf.Clamp(HappinessCountDown[5], 0, 100);
        // Update timer each frame by delay
        HappinessCountDown[5] -= Time.deltaTime / 10;
        PlayerPrefs.SetFloat("ChickPeaHappiness", HappinessCountDown[5]);

        HappinessCountDown[7] = Mathf.Clamp(HappinessCountDown[7], 0, 100);
        // Update timer each frame by delay
        HappinessCountDown[7] -= Time.deltaTime / 10;
        PlayerPrefs.SetFloat("CronosHappiness", HappinessCountDown[7]);
    }
 
    // Resets clock based on current hunger and time instance
    public void ResetClock()
    {
        // GOBU
        TimeMasterScript.instance.SaveDate();
        HappinessCountDown[0] = PlayerPrefs.GetFloat("GobuHappiness");
        HappinessCountDown[0] -= TimeMasterScript.instance.CheckDate();
 
    }

}
