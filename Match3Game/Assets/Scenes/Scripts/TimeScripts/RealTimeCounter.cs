using UnityEngine;
using System.Collections;

public class RealTimeCounter : MonoBehaviour
{
    //TestTimer
    public float TimerCountDown;
    CompanionScript CompScript;
    GameObject CompanionGameObj;
   public float SaveNum;
    // Use this for initialization
    void Start()
    {
        CompanionGameObj = GameObject.FindGameObjectWithTag("Companion");
        CompScript = CompanionGameObj.GetComponent<CompanionScript>();
        // Starting timer amount
        // Update timer with real time passed
        TimerCountDown = PlayerPrefs.GetFloat("CurrentHappiness");
        // update timer when real time passes 
        TimerCountDown -= TimeMasterScript.instance.CheckDate() / 6;
        CompScript.Happiness = TimerCountDown;


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
