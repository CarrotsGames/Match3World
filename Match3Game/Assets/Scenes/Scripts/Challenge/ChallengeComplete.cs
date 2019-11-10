using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeComplete : MonoBehaviour
{
    public static bool UnlockingChallenges;

    [HideInInspector]
    public static int[] ChallengeList;
    // Savefile name
    public string ChallengeName;
    // Which challenge completed
    public int CurrentChallenge;
    [Header("This is only filled in Main Screen (CB GameObj in here)")]
    public GameObject ButtonHighlite;
    private string SceneName;
    private void Start()
    {
        ChallengeList = new int[25];
        SceneName = SceneManager.GetActiveScene().name;
        if (SceneName != "Main Screen")
        {
            SaveSystem.LoadChallenge(ChallengeName);
        }
    }
    public void Save()
    {
        CurrentChallenge = GetComponent<ChallengeManager>().ChallengeNumber;
        SaveSystem.SaveChallenge(this);
    }
    public void UnlockAllChallenges(string Moobling)
    {
       // UnlockingChallenges = true;
        switch (Moobling)
        {
            case "Gobu":
                ChallengeName = "GobuChallenge";
                UnlockingChallenges = true;
                SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);
                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite();
                break;
            case "Binky":
                ChallengeName = "BinkyChallenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite();
                break;
            case "Koko":
                ChallengeName = "KokoChallenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite();
                break;
            case "Crius":
                ChallengeName = "CriusChallenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite();
                break;
            case "Sauco":
                ChallengeName = "SaucoChallenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite();
                break;
            case "ChickPea":
                ChallengeName = "CPChallenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite();
                break;
            case "Squishy":
                ChallengeName = "SquishyChallenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite();
                break;
            case "Okami":
                ChallengeName = "OkamiChallenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite();
                break;
            case "Ida":
                ChallengeName = "IdaChallenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite();
                break;
            case "Cronus":
                ChallengeName = "CronusChallenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite();
                break;
        }

    }
}
