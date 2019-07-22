using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
  public class LeaderBoardScript : MonoBehaviour
{
    GameObject DotManagerObj;
    DotManager DotManagerScript;

    public Text text;
    public List<Text> ListNames;
    public int OffsetY;
    [HideInInspector]
    public int i;
    //FirstTimeStartUp
    public int FirstTimeStartUp;
    public InputField NameTextBox;
    private void Start()
    {
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        
      ///   ListNames = new List<Text>();
        OffsetY = 0;
        // sets up the top 10 on leaderboards position
      
        // logins into playfab with android device ID
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "(DE2C) Superflat Connect 3";
        }
        //creates account if not account is made
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest()
        {
            CreateAccount = true,
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier

        }, result =>
        {
            Debug.Log("Logged in");
            // logs in to playfab and gets top 10 people on leaderboard
            LoggedIn();
            // Player can assign themself a name ( Appears on screen if player has no name)
            UpdateName();

            // Refresh available items 
        }, error => Debug.LogError(error.GenerateErrorReport()));
     }

   public void UpdateName()
    {
        // Players Playfab name is equal to desired name
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest()
        {
             DisplayName = NameTextBox.text

        }, success =>
        {
            // Changes name to desired name
            Debug.Log("Name Changed to " + NameTextBox.text);
            // first time startup is greater than one making it not appear on screen anymore
            FirstTimeStartUp += 1;
            PlayerPrefs.SetFloat("FTS", FirstTimeStartUp);
         }, failure =>
        {
            Debug.Log(failure.ErrorMessage); //this is line 106

        });

    }
   public void LoggedIn()
    {
        // logs player into this specific leaderboard
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest()
        {
            // if you want to write to diffrent leader board change ""
            //eg "Leaderboard1"
            StatisticName = "TournamentScore",
        }, result =>
        {
            // Gets leaderboard version and gets each person in leaderboard statistics
            Debug.Log("Leaderboard version: " + result.Version);
                foreach (var entry in result.Leaderboard)
                {

                    Debug.Log(entry.DisplayName + " " + entry.StatValue);
                    ListNames[i].text = entry.DisplayName + " " + entry.StatValue;
                    i++;
                }
            i = 0;

          // if login is failed throw error
        }, OnLoginFailure);

    }
    // if login was successful
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
    }
    // if login was failure
    private void OnLoginFailure(PlayFabError error)
    {

        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        // tells us what exactly went wrong
        Debug.LogError(error.GenerateErrorReport());
    }
    
}
