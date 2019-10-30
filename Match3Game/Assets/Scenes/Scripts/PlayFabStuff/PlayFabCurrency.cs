using UnityEngine;
using System.Collections;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
public class PlayFabCurrency : MonoBehaviour
{
    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;
    private PlayFabLogin PlayFabLoginScript;
    GameObject DotManagerObj;
    DotManager DotManagerScript;
    int amount;
    int Versions;
    float Timer;
    string SceneName;
    // Use this for initialization
    void Start()
    {
        // if they are then the happinessStates void wont be called to avoid mixing saves
        Scene CurrentScene = SceneManager.GetActiveScene();
        // Gets current scene
        SceneName = CurrentScene.name;
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();

    }

    public void Update()
    {

        if (Timer <= 0)
        {
            Versions = PlayerPrefs.GetInt("VERSIONVALUE");

            if (PlayFabLogin.HasLoggedIn == true)
            {
                GetCurrency();
            }
            else
            {
              //  Debug.Log("Not logged into servers");
            }

            Timer = 10;
        }
        else
        {
            // if on the main screen keep checking if moneys coming in
            if (SceneName == "Main Screen")
            {
                Timer -= Time.deltaTime;
            }
        }
    }
    public void GetCurrency()
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
 
           
            //// NOTE : Not sure it this is needed since its in the monthly script  
            //if (Versions != result.Version)
            //{
            //    Versions = result.Version;

            //    Debug.Log("NEW VERSION");
            //    DotManager.TotalScore = 0;
            //    // gives players currency
            //    DotManagerScript.HighScore.text = "" + DotManager.TotalScore;
            //    PlayerPrefs.SetFloat("SCORE", DotManager.TotalScore);
            //    PlayerPrefs.SetInt("VERSIONVALUE", Versions);
            //}

        }, SubtractPremiumCurrencyFailure);



    }
    void AddPreimiumCurrencySuccess(ModifyUserVirtualCurrencyResult result)
    {

         amount = result.Balance;
        PowerUpManagerScript.Currency += result.Balance;
        PowerUpManagerScript.PowerUpSaves();

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
     }
    void SubtractPremiumCurrencyFailure(PlayFabError error)
    {
 
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
 

