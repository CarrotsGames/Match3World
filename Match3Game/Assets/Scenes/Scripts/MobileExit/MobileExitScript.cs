using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MobileExitScript : MonoBehaviour {

    private GameObject GameTransitionsGameObj;
    private GameObject RealTimerGameObj;
    private RealTimeCounter RealTimeScript;
    GameTransitions GT;
    public GameObject Analytics;
    // Update is called once per frame
    // Exits the game using Android Back Button 

    private void Start()
    {
        GameTransitionsGameObj = GameObject.FindGameObjectWithTag("GameTransition");
        GT = GameTransitionsGameObj.GetComponent<GameTransitions>();
        RealTimerGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = RealTimerGameObj.GetComponent<RealTimeCounter>();

    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GT.HomeButton();
         }
         
         
    }
    private void OnApplicationQuit()
    {
        // Gets moobling data
        Analytics.GetComponent<PlayFabAnalytics>().SetUserData();
        //Sends gold amount and powerups used
        Analytics.GetComponent<PowerUpAnalytics>().SendAnalytics();
        //Sends gold amount and powerups used
        Analytics.GetComponent<PlayFabLogin>().TournamentScore();
       
    }
    private void OnApplicationPause(bool pause)
    {
        
    }
}
