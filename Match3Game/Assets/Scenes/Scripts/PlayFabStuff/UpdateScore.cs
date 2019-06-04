using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using System.Collections;
 
public class UpdateScore : MonoBehaviour
{
  
    public void Start()
    {
       
         // Login with Android ID
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest()
        {
            CreateAccount = true,
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier
            
        }, result =>
        {
           //  GetLeaderBoard();

            // Refresh available items 
        }, error => Debug.LogError(error.GenerateErrorReport()));

    }

   
    // 
  // void GetLeaderBoard()
  // {
  //     PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest()
  //     {
  //         StatisticName = "TournamentScore",
  //     }, result =>
  //     {
  //         Debug.Log("Leaderboard version: " + result.Version);
  //         foreach (var entry in result.Leaderboard)
  //         {
  //              Debug.Log(entry.DisplayName + " " + entry.StatValue);
  //         }
  //         
  //     }, OnLoginFailure);
  //
  //  }
  
//
//    private void OnLoginFailure(PlayFabError error)
//    {
//
//        Debug.LogWarning("Something went wrong with your first API call.  :(");
//        Debug.LogError("Here's some debug information:");
//        Debug.LogError(error.GenerateErrorReport());
//     }
//   
}
