using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
public class MonthlyChallenge : MonoBehaviour {
    public float ChallengeScore;
    DotManager DotManagerScript;
    GameObject DotManagerGameObj;
    public GameObject PrizeCompanion;
    int UnlockGift;
    private string NameOfPrize;
    bool HasUnlockedGift;
    int MonthlyVersions;
    float DelayTimerCheck;
    // Use this for initialization
    void Start()
    {
        NameOfPrize = "NEWGOBU";
        DotManagerGameObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerGameObj.GetComponent<DotManager>();
        UnlockGift = PlayerPrefs.GetInt("MONTHLYPRIZE");
        PlayerPrefs.SetString("UNLOCKED", NameOfPrize);
        MonthlyVersions = PlayerPrefs.GetInt("MONTHLYVERSIONVALUE");

        if (UnlockGift > 0)
        {
            HasUnlockedGift = true;
        }
        else
        {
            HasUnlockedGift = false;
            UnlockGift = 0;
            PlayerPrefs.SetInt("MONTHLYPRIZE", UnlockGift);

        }
    }

    // Update is called once per frame
    void Update()
    {
        MonthlyChallengeStatus();
        DelayTimerCheck -= Time.deltaTime;

        if(DelayTimerCheck < 0)
        {
            DelayTimerCheck += 4;
            MonthlyChallengeStatus();
        }
        if (!HasUnlockedGift)
        {
            if (DotManagerScript.TotalScore > ChallengeScore)
            {
                // ADD PRIZE COMPANION TO ROSTER
                Debug.Log("YOU GOT THE PRIZE");
                UnlockGift += 1;
                PlayerPrefs.SetInt("MONTHLYPRIZE", UnlockGift);
            }
            else
            {
                UnlockGift = 0;
                PlayerPrefs.SetInt("MONTHLYPRIZE", UnlockGift);
             }
        }
    }
    void MonthlyChallengeStatus()
    {


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
            // if the phone version is not equal to the server version reset
            if (MonthlyVersions != result.Version)
            {
                MonthlyVersions = result.Version;

                Debug.Log("NEW VERSION");
                DotManagerScript.TotalScore = 0;
                // gives players currency
                DotManagerScript.HighScore.text = "" + DotManagerScript.TotalScore;
                PlayerPrefs.SetFloat("SCORE", DotManagerScript.TotalScore);
                PlayerPrefs.SetInt("MONTHLYVERSIONVALUE", MonthlyVersions);
                MonthlyChallengeEnded();
            }

        }, MonthlyChallengeGoing);
    }

    void MonthlyChallengeEnded()
    {
        Debug.Log("MONTHLYCHALLENGE STILL GOING");
    }
    void MonthlyChallengeGoing(PlayFabError Error)
    {
        Debug.Log("MONTHLYCHALLENGE  ENDED");
    }
}