using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using System.Collections;
 
public class PlayFabLogin : MonoBehaviour
{
    GameObject DotManagerObj;
    DotManager DotManagerScript;
    public GameObject EggHatchGameObj;
    float UpdateScoreTimer;
    public bool HasLoggedIn;
    public void Start()
    {
        UpdateScoreTimer = 3;
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        Login();
        HasLoggedIn = false;
    }
    public void Login()
    {      
        //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "(DE2C) Superflat Connect 3"; // Please change this value to your own titleId from PlayFab Game Manager
        }

        // Login with Android ID
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest()
        {
            CreateAccount = true,
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier

        }, result =>
        {
            HasLoggedIn = true;
        // LOGGED IN
        //  GetLeaderBoard();

            // Refresh available items 
        }, error => Debug.Log("Cannot connect to server"));


    }
    private void Update()
    {
 
        UpdateScoreTimer -= Time.deltaTime;
     
        // Updates player Score to server every x Seconds
        if (UpdateScoreTimer < 0)
        {
 
            PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
            {

                new StatisticUpdate {StatisticName = "TournamentScore", Value = DotManagerScript.TotalScore,},
             }

            },
              result => { Debug.Log("User statistics updated"); },
              error => { Debug.LogError(error.GenerateErrorReport()); });
              UpdateScoreTimer = 10;
        }
    }
 
}
