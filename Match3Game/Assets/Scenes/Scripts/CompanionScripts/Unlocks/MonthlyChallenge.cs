﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using PlayFab;
using PlayFab.ClientModels;
public class MonthlyChallenge : MonoBehaviour {
    public float ChallengeScore;
    DotManager DotManagerScript;
    GameObject DotManagerGameObj;
    public GameObject[] PrizeCompanion;
    int UnlockGift;
    public GameObject UnlockableCreatures;
    private GameObject PlayFab;
    private string NameOfPrize;
    bool HasUnlockedGift;
    int MonthlyVersions;
    float DelayTimerCheck;
    string SceneName;
       // UNLOCK SCORE COMPANIONS
    // 0 BINKY
    // 1 KOKO
    // Use this for initialization
    void Start()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();

        SceneName = CurrentScene.name;

        PlayFab = GameObject.FindGameObjectWithTag("PlayFab");
           DotManagerGameObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerGameObj.GetComponent<DotManager>();
        //Saves value to check HasUnlockedGift bool 
        UnlockGift = PlayerPrefs.GetInt("MONTHLYPRIZE");
        MonthlyVersions = PlayerPrefs.GetInt("MONTHLYVERSIONVALUE");
        DelayTimerCheck = 3;
        HasUnlockedGift = (PlayerPrefs.GetInt("HASUNLOCKEDGIFT") != 0);
        // checks if the unlock gift value is greater than 0
        // for the monthly unlock
        //   if (UnlockGift > 0)
        //  {
        //      HasUnlockedGift = true;
        //  }
        //  else
        //  {
        //      HasUnlockedGift = false;
        //      UnlockGift = 0;
        //      PlayerPrefs.SetInt("MONTHLYPRIZE", UnlockGift);
        //
        //  }
    }

    // Update is called once per frame
    void Update()
    {
         if (PlayFabLogin.HasLoggedIn == true)
         {
            if(SceneName == "Main Screen" && !HasUnlockedGift)
            {
                if (DelayTimerCheck > 0)
                {
                    DelayTimerCheck -= Time.deltaTime;
                }
                else
                {
                    DelayTimerCheck += 4;
                    MonthlyChallengeStatus();
                }
            }
            ////reset Unlock array
            //if (Input.GetKeyDown(KeyCode.R))
            //{
                //HasUnlockedGift = false;
                //PlayerPrefs.SetInt("HASUNLOCKEDGIFT", (HasUnlockedGift ? 1 : 0));

                //UnlockGift = 0;
                //PlayerPrefs.SetInt("MONTHLYPRIZE", UnlockGift);
            //}
            // checks if the tournament is still going
            //DelayTimerCheck -= Time.deltaTime;
            // Cooldown for checking tournament status to avoid sending to much information 
            if (DotManager.TotalScore > ChallengeScore && !HasUnlockedGift)
            {
                MonthlyChallengeStatus();
                CheckMonthlyUnlock();
            }
           
         }
    }
   public void CheckMonthlyUnlock()
    {
        // checks if the player unlocked the monthly gift
        if (!HasUnlockedGift)
        {
            

                string UnlockName = PrizeCompanion[UnlockGift].name;
                PlayerPrefs.SetString("UNLOCKED", UnlockName);

                // ADD PRIZE COMPANION TO ROSTER
                Debug.Log("YOU GOT THE PRIZE");
                UnlockGift += 1;
                PlayerPrefs.SetInt("MONTHLYPRIZE", UnlockGift);
                HasUnlockedGift = true;
                PlayerPrefs.SetInt("HASUNLOCKEDGIFT", (HasUnlockedGift ? 1 : 0));
                UnlockableCreatures.GetComponent<UnlockableCreatures>().Unlock();
      
        }
    }
    // UNLOCK THE MONTHLY COMPANION
    void MonthlyChallengeStatus()
    {

        // checks tournament for the current leaderboard
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest()
        {
            StatisticName = "TournamentScore",
        }, result =>
        {
 
 
            // if the phone version is not equal to the server version reset
            if (MonthlyVersions != result.Version)
            {
                HasUnlockedGift = false;
                PlayerPrefs.SetInt("HASUNLOCKEDGIFT", (HasUnlockedGift ? 1 : 0));
                MonthlyVersions = result.Version;
                PlayerPrefs.SetInt("MONTHLYVERSIONVALUE", MonthlyVersions);
                Debug.Log("NEW VERSION");
                // Changes MonthlyCompanion array to next companion

                DotManager.TotalScore = 0;
                // gives players currency
                DotManagerScript.HighScore.text = "" + DotManager.TotalScore;
                PlayerPrefs.SetFloat("SCORE", DotManager.TotalScore);
                MonthlyChallengeEnded();
            }

        }, MonthlyChallengeGoing);
    }
  
    // informs player that tournament is over
    void MonthlyChallengeEnded()
    {
        //PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest()
        HasUnlockedGift = false;
        //CheckMonthlyUnlock();
        PlayerPrefs.SetInt("HASUNLOCKEDGIFT", (HasUnlockedGift ? 1 : 0));

        Debug.Log("MONTHLYCHALLENGE STILL Ended");
    }
    //inform player how long until tournament is over
    void MonthlyChallengeGoing(PlayFabError Error)
    {
      //  Debug.Log("MONTHLYCHALLENGE  still going");
    }
    // UNLOCK NORMAL COMPANIONS
  
}