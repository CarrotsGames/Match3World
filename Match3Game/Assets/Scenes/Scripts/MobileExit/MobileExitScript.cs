﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;
public class MobileExitScript : MonoBehaviour {

    private GameObject GameTransitionsGameObj;
    private GameObject RealTimerGameObj;
    private RealTimeCounter RealTimeScript;
    GameTransitions GT;
    public GameObject Analytics;
    private GameObject HappinessManagerGameObj;
    // Update is called once per frame
    // Exits the game using Android Back Button 

    private void Start()
    {
        GameTransitionsGameObj = GameObject.FindGameObjectWithTag("GameTransition");
        GT = GameTransitionsGameObj.GetComponent<GameTransitions>();
        RealTimerGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = RealTimerGameObj.GetComponent<RealTimeCounter>();
        HappinessManagerGameObj = GameObject.FindGameObjectWithTag("HM");
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HappinessManagerGameObj.GetComponent<HappinessManager>().SaveMe();
            MobileScoreUpdate();
            GT.HomeButton();
        }
              
    }
    void MobileScoreUpdate()
    {
        RealTimeScript.ResetClock();
        string Scene = SceneManager.GetActiveScene().name;
        if (Scene != "Gobu Tut")
        {
            // Gets moobling data
            Analytics.GetComponent<PlayFabAnalytics>().SetUserData();
            //Sends gold amount and powerups used
            Analytics.GetComponent<PowerUpAnalytics>().SendAnalytics();
            //Sends gold amount and powerups used
            Analytics.GetComponent<PlayFabLogin>().TournamentScore();
        }
    }
    private void OnApplicationQuit()
    {
        RealTimeScript.ResetClock();
        string Scene = SceneManager.GetActiveScene().name;
        if (Scene != "Gobu Tut")
        {
            // Gets moobling data
            Analytics.GetComponent<PlayFabAnalytics>().SetUserData();
            //Sends gold amount and powerups used
            Analytics.GetComponent<PowerUpAnalytics>().SendAnalytics();
            //Sends gold amount and powerups used
            Analytics.GetComponent<PlayFabLogin>().TournamentScore();
        }
    }
 
}
