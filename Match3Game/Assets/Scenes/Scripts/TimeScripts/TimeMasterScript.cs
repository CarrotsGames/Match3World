using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class TimeMasterScript : MonoBehaviour
{

    DateTime CurrentDate;
    DateTime OldDate;

    public String SaveLocation;
    public static TimeMasterScript instance;


    // Use this for initialization
    void Awake()
    {
        // create instance of our DateMaster Script 
        CheckInstance();
        // set our player prefs to save location
        SaveLocation = "LastSavedDate1";
        
    }
    private void Start()
    {
        CheckInstance();
        SaveLocation = "LastSavedDate1";
    }
    public void CheckInstance()
    {
        instance = this;
        
    }
    public float CheckDate()
    {
        SaveLocation = "LastSavedDate1";

        // stores current time when app starts
        CurrentDate = System.DateTime.Now;

        string TempString = PlayerPrefs.GetString(SaveLocation);
        //Grabs the old time from playerprefs 
        long TempLong = Convert.ToInt64(TempString);

        // Convert OldTime from binary to a datetime variable
        DateTime OldDate = DateTime.FromBinary(TempLong);
        // print("OldDate :" + OldDate);

        TimeSpan Difference = CurrentDate.Subtract(OldDate);
        // print("Difference :" + Difference);

        return (float)Difference.TotalSeconds;
    }
    // Saves Current time and date into PlayerPrefs
    public void SaveDate()
    {
        //saves current system time
        PlayerPrefs.SetString(SaveLocation, System.DateTime.Now.ToBinary().ToString());
 
    }
}
