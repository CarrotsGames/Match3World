using UnityEngine;
using System.Collections;

public class EventScript : MonoBehaviour
{
    public GameObject DailySpinner;
    // sets how long to count down Timers
    public float TimeToDoDaily;

    // Counts down timers in script 
    public float DailyTimer;
    private float WeeklyTimer;
    private float MonthlyTimer;
    public bool CanDoDaily;
    // Use this for initialization
    private GameObject RealTimerGameObj;
    private RealTimeCounter RealTimeScript;
    private DailySpin dailySpinScript;
    private void Start()
    {
        DailyTimer = PlayerPrefs.GetFloat("DAILYTEST1");
        RealTimerGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = RealTimerGameObj.GetComponent<RealTimeCounter>();
        DailySpinner.SetActive(false);
        dailySpinScript = DailySpinner.GetComponent<DailySpin>();

    }
   

    public void DoDailyButton()
    {
       //DailyTimer = RealTimeScript.DailyTimerCountDown;
       //if (RealTimeScript.DailyTimerCountDown < 0)
       //{
       //    //SPIN WHEEL
       //    // RESET TIMER
       //    DailyTimer = TimeToDoDaily;
       //    RealTimeScript.DailyTimerCountDown = DailyTimer;
       //    PlayerPrefs.SetFloat("DAILYTEST1", DailyTimer);
       //
       //    RealTimeScript.DailyTimerCountDown = DailyTimer;
       //    CanDoDaily = true;
       //}
        if(CanDoDaily)
        {
             DailySpinner.SetActive(true);
         }
        else
        {
          // dailySpinScript.TimeToStopWheelStore = dailySpinScript.TimeToStopWheel;
          // dailySpinScript.StartUpSpeedStore = dailySpinScript.StartUpSpeed;
          // dailySpinScript.MaxSpeedStore = dailySpinScript.MaxSpeed;
        }
     }

   void ResetClock()
    {
   
      //  WeeklyTimer -= TimeMasterScript.instance.CheckDate();

    }
    private void OnApplicationPause(bool pause)
   {
     ResetClock();
  
   }
   private void OnApplicationQuit()
   {
       ResetClock();
   }
}
