using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayFabLogin : MonoBehaviour
{
    GameObject DotManagerObj;
    DotManager DotManagerScript;
    public GameObject EggHatchGameObj;
    float UpdateScoreTimer;
    string SceneName;

    public static bool HasLoggedIn;
    public void Start()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneName = CurrentScene.name;
        if (SceneName != "Money Store" && SceneName != "StoreScene")
        {
            UpdateScoreTimer = 240;
            DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
            DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        }
        
        HasLoggedIn = false;
        Login();
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
        if (SceneName != "Money Store" && SceneName != "StoreScene")
        {

            // Updates player Score to server every x Seconds
            if (UpdateScoreTimer < 0)
            {
                TournamentScore();
            }
        }
    
    }
   // Tournament score push (I know, a weird place to have this but blame playfab tutorials)
    public void TournamentScore()
    {
            PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
            {

                new StatisticUpdate {StatisticName = "TournamentScore", Value =   DotManager.TotalScore,},
             }

            },
                result => { Debug.Log("User statistics updated"); },
                error => { Debug.LogError(error.GenerateErrorReport()); });
            UpdateScoreTimer = 240;
         
    }
 }