using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonthlyChallenge : MonoBehaviour {
    public float ChallengeScore;
    DotManagerScript DotManagerScriptRef;
    GameObject DotManagerGameObj;
    public GameObject PrizeCompanion;
    int UnlockGift;
    bool HasUnlockedGift;
	// Use this for initialization
	void Start () {
        DotManagerGameObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScriptRef = DotManagerGameObj.GetComponent<DotManagerScript>();
        UnlockGift = PlayerPrefs.GetInt("MONTHLYPRIZE");
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
	void Update ()
    {
        if (!HasUnlockedGift)
        {
            if (DotManagerScriptRef.TotalScore > ChallengeScore)
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
