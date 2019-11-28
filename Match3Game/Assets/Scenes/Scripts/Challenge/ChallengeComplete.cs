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
    private GameObject PowerUpManagerGameObj;
   // public GameObject Reward;
    private void Start()
    {
        // Creates a list for challenge save 
        ChallengeList = new int[25];
        SceneName = SceneManager.GetActiveScene().name;
        if (SceneName != "Main Screen")
        {
            // loads challenge with list template
            SaveSystem.LoadChallenge(ChallengeName);
           // Reward.SetActive(true);
        }
    }
    public void Save()
    {
        // saves current challenge index to complete
        CurrentChallenge = GetComponent<ChallengeManager>().ChallengeNumber;
        if (ChallengeList[CurrentChallenge] == 0)
        {
            PowerUpManagerGameObj = GameObject.FindGameObjectWithTag("PUM");
            PowerUpManagerGameObj.GetComponent<PowerUpManager>().Currency += 5;
            PowerUpManagerGameObj.GetComponent<PowerUpManager>().PowerUpSaves();
            Debug.Log("Money");
        }
        SaveSystem.SaveChallenge(this);
    
    }
    
    public void UnlockAllChallenges(string Moobling)
    {
        Debug.Log("ChallengesUnlocked");
       // UnlockingChallenges = true;
        switch (Moobling)
        {
            case "Gobu":
                ChallengeName = "Gobu Challenges";
                UnlockingChallenges = true;
               // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);
                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite(ChallengeName);
                break;
            case "Binky":
                // Someone made a typo on the scene so just go with it...
                ChallengeName = "Circle Challege";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite(ChallengeName);
                break;
            case "Koko":
                ChallengeName = "Triangle Challenges";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite(ChallengeName);
                break;
            case "Crius":
                // Typo just go with it
                ChallengeName = "Crius Challenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite(ChallengeName);
                break;
            case "Sauco":
                ChallengeName = "Sauco Challenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite(ChallengeName);
                break;
            case "ChickPea":
                ChallengeName = "Chick-Pee Challenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite(ChallengeName);
                break;
            case "Squishy":
                ChallengeName = "Squishy Challenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite(ChallengeName);
                break;
            case "Okami":
                ChallengeName = "Okami Challenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite(ChallengeName);
                break;
            case "Ida":
                ChallengeName = "Idasaurous Challenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite(ChallengeName);
                break;
            case "Cronus":
                ChallengeName = "Cronus Challenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite(ChallengeName);
                break;
            case "Snowball":
                ChallengeName = "Snowball Challenge";
                UnlockingChallenges = true;
                // SaveSystem.SaveChallenge(this);
                PlayerPrefs.SetInt(ChallengeName, 20);

                ButtonHighlite.GetComponent<ButtonColour>().RefreshHighlite(ChallengeName);
                break;
        }

    }
}
