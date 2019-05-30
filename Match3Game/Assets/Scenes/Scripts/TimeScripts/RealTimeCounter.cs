using UnityEngine;
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
        //4 Then in update add an else if with that companion name and countdown the time (Make sure HappinessCountdown is set to right array)
        //5 Make that companon array equal the happiness slidervalue(happienssmetre)
        //6 In "happinessmanager" script go to companion save switch (line 51) and add that companion save 
        //7 Make sure the case is equal to the companions name in scene
        //8 Give that companion savestring name(savestring saves the sleeping bool for that companion)
        //9 Finally go to CompanionNaviagion "CompanionSwitch" (Line 125) and add that companions name in the navigation menu 
        //with their arrays 
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
        /////////////////////////////////////////////////////////////////////



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

    }

    private void OnGUI()
    {
        // Time checks for debugging
        // if(GUI.Button(new Rect(10,10,100,50), "SaveTime"))
        // {
        //     ResetClock();
        // }
        // if (GUI.Button(new Rect(10, 150, 100, 50), "CheckTime"))
        // {
        //     print(60 - TimeMasterScript.instance.CheckDate() + "In real Seconds has passed");
        // }
        //
        // GUI.Label(new Rect(10, 150, 100, 50), TimerCountDown.ToString());

    }
    // Resets clock based on current hunger and time instance
    public void ResetClock()
    {
        // GOBU
        TimeMasterScript.instance.SaveDate();
        HappinessCountDown[0] = PlayerPrefs.GetFloat("GobuHappiness");
        HappinessCountDown[0] -= TimeMasterScript.instance.CheckDate();
      //  PlayerPrefs.SetFloat("DAILYTEST1", DailyTimerCountDown);

        //  // BINKY
        //  TimeMasterScript.instance.SaveDate();
        //  // Binkies Happiness Timer
        //  TimerCountDown1 = PlayerPrefs.GetFloat("BinkyHappiness");
        //  // update timer when real time passes 
        //  TimerCountDown1 -= TimeMasterScript.instance.CheckDate();
        // 
        //  // KOKO
        //  TimeMasterScript.instance.SaveDate();
        //  TimerCountDown2 = PlayerPrefs.GetFloat("KokoHappiness");
        //  // update timer when real time passes 
        //  TimerCountDown2 -= TimeMasterScript.instance.CheckDate();
    }

}
