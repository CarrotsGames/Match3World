using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeComplete : MonoBehaviour
{
    [HideInInspector]
    public static int[] ChallengeList;
    // Savefile name
    public string ChallengeName;
    // Which challenge completed
    public int CurrentChallenge;

    private void Start()
    {
        ChallengeList = new int[25];
        SaveSystem.LoadChallenge(ChallengeName);
        
    }
    public void Save()
    {
        CurrentChallenge = GetComponent<ChallengeManager>().ChallengeNumber;
        SaveSystem.SaveChallenge(this);
    }
}
