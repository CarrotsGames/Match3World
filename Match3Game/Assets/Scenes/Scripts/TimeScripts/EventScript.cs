using UnityEngine;
using System.Collections;

public class EventScript : MonoBehaviour
{
    public float DailyTimer;
    public float WeeklyTimer;
    public float MonthlyTimer;
    public bool CannotDoDaily;
    // Use this for initialization


    private void Start()
    {
        WeeklyTimer = PlayerPrefs.GetFloat("TEST");
        WeeklyTimer -= TimeMasterScript.instance.CheckDate();
        DailyTimer = WeeklyTimer;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("TEST", DailyTimer);
        DailyTimer -= Time.deltaTime;


    }

    public void DoDailyButton()
    {
        if(!CannotDoDaily)
        {
            //SPIN WHEEL
            // RESET TIMER
            DailyTimer = 300;
            CannotDoDaily = true;
        }
     }

   void ResetClock()
    {
        TimeMasterScript.instance.SaveDate();
        DailyTimer = PlayerPrefs.GetFloat("TEST");
        DailyTimer -= TimeMasterScript.instance.CheckDate();

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
