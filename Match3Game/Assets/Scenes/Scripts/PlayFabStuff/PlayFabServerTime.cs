using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
public class PlayFabServerTime : MonoBehaviour {
    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;
    GameObject DotManagerObj;
    DotManager DotManagerScript;
    int amount;
    int DailySpinCount;
    EventScript DailyEvent;
    GameObject Events;
    public string SaveBool;
    float DelayTimer;
     // Use this for initialization
    void Start () {
        DailySpinCount = PlayerPrefs.GetInt("DAILYSPINCOUNTER");
        Events = GameObject.FindGameObjectWithTag("ES");
        DailyEvent = Events.GetComponent<EventScript>();
        DailyEvent.CanDoDaily = (PlayerPrefs.GetInt(SaveBool) != 0);
        DelayTimer = 3;
     }

    void Update()
    {
        DelayTimer -= Time.deltaTime;
        if(DelayTimer < 0)
        {
            DailySpin();
            DelayTimer = 3;
        }
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

    // adds currency earned by tournament 
    public void DailySpin()
    {
       

        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest()
        {
            StatisticName = "DailySpin",
        }, result =>
        {
            Debug.Log("DailySpin version: " + result.Version);
            // foreach (var entry in result.Leaderboard)
            // {
            //     Debug.Log(entry.DisplayName + " " + entry.StatValue);
            // }
            // if the leaderboard has changed version tournament is over
            if (DailySpinCount != result.Version)
            {
                DailySpinCount = result.Version;
                DailyEvent.CanDoDaily = true;
                PlayerPrefs.SetInt(SaveBool, (DailyEvent.CanDoDaily ? 1 : 0));

                Debug.Log("CANDAILYSPIN");
           
                // gives players currency
              //  DotManagerScript.HighScore.text = "" + DotManagerScript.TotalScore;
                //PlayerPrefs.SetFloat("SCORE", DotManagerScript.TotalScore);
                PlayerPrefs.SetInt("DAILYSPINCOUNTER", DailySpinCount);
            }

        }, SubtractPremiumCurrencyFailure);



    }
 
    void SubtractPremiumCurrencySuccess(ModifyUserVirtualCurrencyResult result)
    {
        result.Balance = amount;
        Debug.Log("Success1");
    }
    void SubtractPremiumCurrencyFailure(PlayFabError error)
    {
        Debug.Log("DailyNotreset");
        // Debug.LogError("ERROR GETTING GAME CURRENCY" + error.Error + "" + error.ErrorMessage);
    }
}
