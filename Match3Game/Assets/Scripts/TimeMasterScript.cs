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
        instance = this;

        // set our player prefs to save location
        SaveLocation = "LastSavedDate1";

    }
  

}
