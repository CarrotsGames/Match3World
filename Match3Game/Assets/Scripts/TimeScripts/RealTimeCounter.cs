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
        TimerCountDown = PlayerPrefs.GetFloat("CurrentHunger");
        // update timer when real time passes 
        TimerCountDown -= TimeMasterScript.instance.CheckDate();
        CompScript.Hunger = TimerCountDown;


    }

    // Update is called once per frame
    void Update()
    {
        TimerCountDown = Mathf.Clamp(TimerCountDown, 0, 100);
         // Update timer each frame
        TimerCountDown -= Time.deltaTime;
    }

    private void OnGUI()
    {
         if(GUI.Button(new Rect(10,10,100,50), "SaveTime"))
         {
             ResetClock();
         }
         if (GUI.Button(new Rect(10, 150, 100, 50), "CheckTime"))
         {
             print(60 - TimeMasterScript.instance.CheckDate() + "In real Seconds has passed");
         }
       
         GUI.Label(new Rect(10, 150, 100, 50), TimerCountDown.ToString());

    }

    public void ResetClock()
    {
        TimeMasterScript.instance.SaveDate();
        TimerCountDown = PlayerPrefs.GetFloat("CurrentHunger");
        TimerCountDown -= TimeMasterScript.instance.CheckDate();
    }
   
}
