using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class ChallengeSave
{
    public string Moobling;
    public int ChallengeNum;
    public int[] CompletedLevels;
  
    public ChallengeSave(ChallengeComplete Ch)
    {
         
         // makes challenge num equal current challenge
         ChallengeNum = Ch.CurrentChallenge;
         // Converts challenge num to original counting instead of array (Easier to track)
         ChallengeNum += 1;
         ChallengeComplete.ChallengeList[Ch.CurrentChallenge] = ChallengeNum;
         CompletedLevels = ChallengeComplete.ChallengeList;
             
    }

}
//if (ChallengeComplete.ChallengeList[Ch.CurrentChallenge] != 1)
//{
//   PowerUpManagerGameObj = GameObject.FindGameObjectWithTag("PUM");
//   PowerUpManagerGameObj.GetComponent<PowerUpManager>().Currency += 5;
//   PowerUpManagerGameObj.GetComponent<PowerUpManager>().PowerUpSaves();
//   Debug.Log("Money");
//}