using UnityEngine;
using System.Collections;
using PlayFab;
using PlayFab.ClientModels;
public class PlayFabCurrency : MonoBehaviour
{
    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;
    GameObject DotManagerObj;
    DotManager DotManagerScript;
    int amount;
    int Versions;

    // Use this for initialization
    void Start()
    {
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        Versions = PlayerPrefs.GetInt("VERSIONVALUE");

        LoggedIn();
    }

    public void LoggedIn()
    {
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
            Debug.Log("Logged in");
            AddPremiumCurrency();
            // Refresh available items 
        }, error => Debug.LogError(error.GenerateErrorReport()));


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
    public void AddPremiumCurrency()
    {
        AddUserVirtualCurrencyRequest request = new AddUserVirtualCurrencyRequest();
        request.VirtualCurrency = "GC";
        PlayFabClientAPI.AddUserVirtualCurrency(request, AddPreimiumCurrencySuccess, AddPremiumCurrencyFailure);

        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest()
        {
            StatisticName = "TournamentScore",
        }, result =>
        {
            Debug.Log("Leaderboard version: " + result.Version);
            // foreach (var entry in result.Leaderboard)
            // {
            //     Debug.Log(entry.DisplayName + " " + entry.StatValue);
            // }
            // if the leaderboard has changed version tournament is over
            if (Versions != result.Version)
            {
                Versions = result.Version;

                Debug.Log("NEW VERSION");
                DotManagerScript.TotalScore = 0;
                // gives players currency
                DotManagerScript.HighScore.text = "" + DotManagerScript.TotalScore;
                PlayerPrefs.SetFloat("SCORE", DotManagerScript.TotalScore);
                PlayerPrefs.SetInt("VERSIONVALUE", Versions);
            }

        }, SubtractPremiumCurrencyFailure);



    }
    void AddPreimiumCurrencySuccess(ModifyUserVirtualCurrencyResult result)
    {

        Debug.Log("SUCCESS");
        amount = result.Balance;
        PowerUpManagerScript.Currency += result.Balance;
       
        SubtractUserVirtualCurrencyRequest SubRequest = new SubtractUserVirtualCurrencyRequest();
        SubRequest.VirtualCurrency = "GC";
        SubRequest.Amount = amount;
        PlayFabClientAPI.SubtractUserVirtualCurrency(SubRequest, SubtractPremiumCurrencySuccess, SubtractPremiumCurrencyFailure);

    }
    void AddPremiumCurrencyFailure(PlayFabError error)
    {
        Debug.LogError("ERROR GETTING GAME CURRENCY" + error.Error + "" + error.ErrorMessage);
    }
    void SubtractPremiumCurrencySuccess(ModifyUserVirtualCurrencyResult result)
    {
        result.Balance = amount;
        Debug.Log("Success1");
    }
    void SubtractPremiumCurrencyFailure(PlayFabError error)
    {
        Debug.Log("NO MONEY EARNED");
       // Debug.LogError("ERROR GETTING GAME CURRENCY" + error.Error + "" + error.ErrorMessage);
    }
   // void AddPreimiumCurrencySuccess(ModifyUserVirtualCurrencyResult result)
   // {
   //
   //     Debug.Log("SUCCESS");
   //     amount = result.Balance;
   //     PowerUpManagerScript.Currency += result.Balance;
   //
   //     SubtractUserVirtualCurrencyRequest SubRequest = new SubtractUserVirtualCurrencyRequest();
   //     SubRequest.VirtualCurrency = "GC";
   //     SubRequest.Amount -= 10;
   //     SubRequest.AuthenticationContext = PlayFabClientAPI.
   //     PlayFabClientAPI.SubtractUserVirtualCurrency(SubRequest, SubtractPremiumCurrencySuccess, SubtractPremiumCurrencyFailure);
   //
   // }
   // void AddPremiumCurrencyFailure(PlayFabError error)
   // {
   //     Debug.LogError("ERROR GETTING GAME CURRENCY" + error.Error + "" + error.ErrorMessage);
   // }
   
}
 

