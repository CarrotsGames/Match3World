using UnityEngine;
using System.Collections;

public class RealTimeCounter : MonoBehaviour
{
    //TestTimer
    //TEMP Holds each Happyness value from each companion
    public float TimerCountDown;
    public float TimerCountDown1;
    public float TimerCountDown2;
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
        //Gobus Happiness Timer
        TimerCountDown = PlayerPrefs.GetFloat("GobuHappiness");
        // update timer when real time passes 
        TimerCountDown -= TimeMasterScript.instance.CheckDate() / 6;
      
        // Binkies Happiness Timer
        TimerCountDown1 = PlayerPrefs.GetFloat("BinkyHappiness");
        // update timer when real time passes 
        TimerCountDown1 -= TimeMasterScript.instance.CheckDate() / 6;
    
        // Kokos Happiness timer
        TimerCountDown2 = PlayerPrefs.GetFloat("KokoHappiness");
        // update timer when real time passes 
        TimerCountDown2 -= TimeMasterScript.instance.CheckDate() / 6;

        if (SuperMultiplier.MultlpierTimer > -1)
        {
            SuperMultiplier.MultlpierTimer = PlayerPrefs.GetFloat("SMTIMER");
            SuperMultiplier.MultlpierTimer -= TimeMasterScript.instance.CheckDate();
        }

        // SuperMultiplier.MultlpierTimer = MultlpierCountdown;
        // update timer when real time passes 
        
        switch (HappinessManagerScript.CompanionSave)

        {
            case "GobuHappiness":

                HappinessManagerScript.HappinessSliderValue = TimerCountDown;
                companionName = "GobuHappiness";

                break;
            case "BinkyHappiness":

                HappinessManagerScript.HappinessSliderValue = TimerCountDown1;
                companionName = "BinkyHappiness";


                break;
            case "KokoHappiness":

                HappinessManagerScript.HappinessSliderValue = TimerCountDown2;
                companionName = "KokoHappiness";

                break;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (companionName == "GobuHappiness")
        {
            TimerCountDown = HappinessManagerScript.HappinessSliderValue;
            PlayerPrefs.SetFloat("GobuHappiness", HappinessManagerScript.HappinessSliderValue);

        }
        else if (companionName == "BinkyHappiness")
        {
            TimerCountDown1 = HappinessManagerScript.HappinessSliderValue;

            TimerCountDown1 = HappinessManagerScript.HappinessSliderValue;

        }
        else if (companionName == "KokoHappiness")
        {
            TimerCountDown2 = HappinessManagerScript.HappinessSliderValue;

            TimerCountDown2 = HappinessManagerScript.HappinessSliderValue;

        }
        TimerCountDown = Mathf.Clamp(TimerCountDown, 0, 100);
         // Update timer each frame
        TimerCountDown -= Time.deltaTime / 3;
        PlayerPrefs.SetFloat("GobuHappiness", TimerCountDown);

        TimerCountDown1 = Mathf.Clamp(TimerCountDown1, 0, 100);
        // Update timer each frame
        TimerCountDown1 -= Time.deltaTime / 3;
        PlayerPrefs.SetFloat("BinkyHappiness", TimerCountDown1);

        TimerCountDown2 = Mathf.Clamp(TimerCountDown2, 0, 100);
        // Update timer each frame
        TimerCountDown2 -= Time.deltaTime / 3;
        PlayerPrefs.SetFloat("KokoHappiness", TimerCountDown2);

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
        TimerCountDown = PlayerPrefs.GetFloat("GobuHappiness");
        TimerCountDown -= TimeMasterScript.instance.CheckDate();
       
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
