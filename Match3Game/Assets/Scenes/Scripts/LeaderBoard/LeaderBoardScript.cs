using UnityEngine;
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
    public GameObject Text;
    List<Text> ListNames;
    Vector3 Names;
    int OffsetY;
    private void Start()
    {
     //    DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
     //   dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
        OffsetY = 0;
        for (int i = 0; i < NumberOfNames.Length; i++)
        {
            GameObject Go;
            Go = Instantiate(Text, transform.position + new Vector3(0, OffsetY, 0), Quaternion.identity) as GameObject;
            Go.transform.parent = transform;
            OffsetY += 30;
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
    private void OnLoginFailure(PlayFabError error)
    {

        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
}
