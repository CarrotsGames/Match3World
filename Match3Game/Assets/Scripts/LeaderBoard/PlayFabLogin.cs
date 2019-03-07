using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using System.Collections;
 
public class PlayFabLogin : MonoBehaviour
{
    GameObject DotManagerObj;
    DotManagerScript dotManagerScript;
    float UpdateScoreTimer;
    bool KeepScoreOn;
    public void Start()
    {
        KeepScoreOn = false;
        UpdateScoreTimer = 10;
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
        //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "(DE2C) Superflat Connect 3"; // Please change this value to your own titleId from PlayFab Game Manager
        }
        // var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        // PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        // LoginWithAndroidDeviceIDRequest request = new LoginWithAndroidDeviceIDRequest()
        //
        // 
        // request.AndroidDevice = SystemInfo.deviceModel;
        // request.AndroidDeviceId = SystemInfo.deviceUniqueIdentifier;
        // request.OS = SystemInfo.operatingSystem;
        // request.CreateAccount = true;
        // request.TitleId = "(DE2C) Superflat Connect 3";
        // PlayFabClientAPI.LoginWithAndroidDeviceID(request, OnLoginSuccess, OnLoginFailure);
        
        
        // Login with Android ID
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest()
        {
            CreateAccount = true,
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier
            
        }, result =>
        {
            Debug.Log("Logged in");
            LoggedIn();

            // Refresh available items 
        }, error => Debug.LogError(error.GenerateErrorReport()));
     
    }

    private void Update()
    {
        UpdateScoreTimer -= Time.deltaTime;

        if (UpdateScoreTimer < 0)
        {
            PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
            {

                new StatisticUpdate {StatisticName = "TestScore", Value = dotManagerScript.TotalScore},

            }

            },
              result => { Debug.Log("User statistics updated"); },
              error => { Debug.LogError(error.GenerateErrorReport()); });
            UpdateScoreTimer = 10;
        }
    }

    
    void LoggedIn()
    {
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest()
        {
            StatisticName = "TestScore",
        }, result =>
        {
            Debug.Log("Leaderboard version: " + result.Version);
            foreach (var entry in result.Leaderboard)
            {
                 Debug.Log(entry.PlayFabId + " " + entry.StatValue);
             }
        }, OnLoginFailure);
 
     }
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");    
    }

    private void OnLoginFailure(PlayFabError error)
    {

        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
     }
   
}
