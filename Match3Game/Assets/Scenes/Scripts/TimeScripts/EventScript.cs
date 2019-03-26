using UnityEngine;
using System.Collections;

public class EventScript : MonoBehaviour
{
    public float DailyTimer;
    public float WeeklyTimer;
    public float MonthlyTimer;
    public bool CannotDoDaily;
    // Use this for initialization
    private GameObject RealTimerGameObj;
    private RealTimeCounter RealTimeScript;

    private void Start()
    {
        DailyTimer = PlayerPrefs.GetFloat("DAILYTEST1");
        RealTimerGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = RealTimerGameObj.GetComponent<RealTimeCounter>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoDailyButton()
    {
        if (RealTimeScript.DailyTimerCountDown < 0)
        {
            //SPIN WHEEL
            // RESET TIMER
            RealTimeScript.DailyTimerCountDown = 300;
            PlayerPrefs.SetFloat("DAILYTEST1", DailyTimer);
            CannotDoDaily = true;
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
