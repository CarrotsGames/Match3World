using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonthlyChallenge : MonoBehaviour {
    public float ChallengeScore;
    DotManager DotManagerScript;
    GameObject DotManagerGameObj;
    public GameObject PrizeCompanion;
    int UnlockGift;
    private string NameOfPrize;
    bool HasUnlockedGift;
    // Use this for initialization
    void Start()
    {
        NameOfPrize = "NEWGOBU";
        DotManagerGameObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerGameObj.GetComponent<DotManager>();
        UnlockGift = PlayerPrefs.GetInt("MONTHLYPRIZE");
        PlayerPrefs.SetString("UNLOCKED", NameOfPrize);

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
                Debug.Log("RESET OR HAVENT REACHED PRIZE");
            }
        }
    }
}