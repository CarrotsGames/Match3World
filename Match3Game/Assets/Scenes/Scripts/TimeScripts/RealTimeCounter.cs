using UnityEngine;
using System.Collections;

public class RealTimeCounter : MonoBehaviour
{
    //TestTimer
    //TEMP Holds each Happyness value from each companion
    public float TimerCountDown;
    public float TimerCountDown1;
    public float TimerCountDown2;

    private GameObject HappinessGameObj;

    private HappinessManager HappinessManagerScript;
    public float SaveNum;
    // Use this for initialization
    void Start()
    {
        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
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
        // update timer when real time passes 

        switch (HappinessManagerScript.CompanionSave)

        {
            case "GobuHappiness":

                HappinessManagerScript.Happiness = TimerCountDown;


                break;
            case "BinkyHappiness":

                HappinessManagerScript.Happiness = TimerCountDown1;


                break;
            case "KokoHappiness":

                HappinessManagerScript.Happiness = TimerCountDown2;

                break;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimerCountDown = Mathf.Clamp(TimerCountDown, 0, 100);
         // Update timer each frame
        TimerCountDown -= Time.deltaTime / 3;
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
        TimeMasterScript.instance.SaveDate();
        TimerCountDown = PlayerPrefs.GetFloat("CurrentHappiness");
        TimerCountDown -= TimeMasterScript.instance.CheckDate();
    }
   
}
