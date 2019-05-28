using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.AuthenticationModels;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine;
using System;

public class EggHatch : MonoBehaviour
{

    DateTime Target;
    public Text TimerText;
    public float Timer;
    private float CurrentTime;
    private int TargetTime;
    private int EggNumber;
    private float DefaultTime;
    private float RefreshTimer;

    // Use this for initialization
    void Start()
    {
        TargetTime = PlayerPrefs.GetInt("EggHatch" + 1);


    }
    private void Update()
    {
        Debug.Log(TargetTime);
        // Debug purpose 
        // checks what the current time is 
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log(CurrentTime);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCountdownTimer();
        }

        if (CurrentTime < 3)
        {
            GetCurrentTime();
        }

        // works similarly to the distance from x position from y
        // Current time counts up to get difference
        CurrentTime += Time.deltaTime;
        // gets the difference between target time and current time 
        Timer = TargetTime - CurrentTime;

        // Displays as timer
        string minutes = Mathf.Floor(Timer / 60).ToString("00");
        string seconds = (Timer % 60).ToString("00");
        TimerText.text = "Time Left: " + minutes + ":" + seconds + ":";

        if (CurrentTime > TargetTime)
        {
            Debug.Log("EGGHATCH CONGRATS");
        }
    }
    // checks the current time on server
    void GetCurrentTime()
    {
        // gets the current time for countdown
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            // Gets current time to countup 
            DateTime now = result.Time.AddHours(1); // GMT+1
            CurrentTime = now.Hour * 60 + now.Minute * 60;

        }, null);
    }
    // begins countdown 
    void StartCountdownTimer()
    {
        PlayFabClientAPI.GetTime(new GetTimeRequest(), (GetTimeResult result) =>
        {
            // Eggnumber is the current egg being hatched (WILL CHANGE TO ARRAY THE MORE EGGS WE HAVE)
            EggNumber = 1;
            DateTime now = result.Time.AddHours(1); // GMT+1
            // The target time is set to be 2 hours ahead
            Target = result.Time.AddHours(3);
            CurrentTime = now.Hour * 60 + now.Minute * 60;
            //180 so it coutns down to 3 hours
            TargetTime = Target.Hour * 180 + Target.Minute * 180;
            // save target time
            //                          PLUS ARRAY NUM
            PlayerPrefs.SetInt("EggHatch" + 1, TargetTime);

        }, null);

    }

}
