using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HalfTime : MonoBehaviour
{

    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.W))
        {
            HatchEggNow();
        }
    }
    // Update is called once per frame
    void HatchEggNow()
    {
   
    }

   public void SkipTime()
    {
        // Gets the time until egghatches
        long Result = GetComponent<EggHatch>().TimeStamp - GetComponent<EggHatch>().NowTime;
        TimeSpan ts = TimeSpan.FromTicks(Result);
        double MinutesFromTs = ts.TotalMinutes;
        if (MinutesFromTs < 60)
        {
            //SPAWN BUY BUTTON FOR THIS ONE
            Debug.Log("Under60");
            GetComponent<EggHatch>().TimeStamp = GetComponent<EggHatch>().NowTime - 10000000;
        }
        else if (MinutesFromTs >= 60 && MinutesFromTs < 120)
        {
            //SPAWN BUY BUTTON FOR THIS ONE
            Debug.Log("Under120");
            GetComponent<EggHatch>().TimeStamp = GetComponent<EggHatch>().NowTime - 10000000;

        }
        else if (MinutesFromTs >= 120 && MinutesFromTs <= 180)
        {
            //SPAWN BUY BUTTON FOR THIS ONE
            Debug.Log("Under180");
            GetComponent<EggHatch>().TimeStamp = GetComponent<EggHatch>().NowTime - 10000000 ;

        }
     }
  
}
