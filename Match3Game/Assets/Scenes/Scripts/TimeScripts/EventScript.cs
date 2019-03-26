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
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoDailyButton()
    {
        if (DailyTimer < 0)
        {
            //SPIN WHEEL
            // RESET TIMER
            DailyTimer = 300;
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
