﻿using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
  public class LeaderBoardScript : MonoBehaviour
{

    GameObject DotManagerObj;
    DotManagerScript dotManagerScript;
    public int[] NumberOfNames;
    public Text text;
    List<Text> ListNames;
    Vector3 Names;
    int OffsetY;
    int i;
     public InputField NameTextBox;
    private void Start()
    {
        //    DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        //   dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
        ListNames = new List<Text>();
        OffsetY = 0;
        for (int i = 0; i < NumberOfNames.Length; i++)
        {
            Text Go;
            Go = Instantiate(text, transform.position + new Vector3(0, OffsetY, 0), Quaternion.identity) as Text;
            Go.transform.parent = transform;
            ListNames.Add(Go);
            OffsetY -= 35;
        }
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "(DE2C) Superflat Connect 3";
        }
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest()
        {
            CreateAccount = true,
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier

        }, result =>
        {
            Debug.Log("Logged in");
            LoggedIn();
            UpdateName();

            // Refresh available items 
        }, error => Debug.LogError(error.GenerateErrorReport()));

    }

   public void UpdateName()
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest()
        {
             DisplayName = NameTextBox.text

        }, success =>
        {
            Debug.Log("Name Changed to " + NameTextBox.text);
         }, failure =>
        {
            Debug.Log(failure.ErrorMessage); //this is line 106

        });
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

                    Debug.Log(entry.DisplayName + " " + entry.StatValue);
                    ListNames[i].text = entry.DisplayName + " " + entry.StatValue;
                    i++;
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