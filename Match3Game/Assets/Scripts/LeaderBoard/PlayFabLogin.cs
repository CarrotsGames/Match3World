using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections;

public class PlayFabLogin : MonoBehaviour
{
    public void Start()
    {
      //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
      if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
      {
          PlayFabSettings.TitleId = "(DE2C) Superflat Connect 3"; // Please change this value to your own titleId from PlayFab Game Manager
      }
        var request = new LoginWithAndroidDeviceIDRequest { AndroidDeviceId = "GettingStartedGuide", CreateAccount = true };
        PlayFabClientAPI.LoginWithAndroidDeviceID(request, OnLoginSuccess, OnLoginFailure);
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
