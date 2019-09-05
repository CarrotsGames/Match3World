using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class LoadChallenge : MonoBehaviour
{
    [Header("Challenge scene name")]
    public string ChallengeScene;
    [Header("Types : Clear, ClearX , BeatScore")]
    public string ChallengeType;
    [Header("What should the challenge say?")]
    public string ChallengeDescription;
    public float ChallengeTimer;
    public int TotalMoves;
    public int ChallengeScore;
  
    public void SelectChallenge(int Index)
    {
     //   PlayerPrefs.SetString("ChallengeType", ChallengeType);
        SceneManager.LoadScene(ChallengeScene);
        PlayerPrefs.SetInt("ChallengeIndex", Index);
      // PlayerPrefs.SetString("ChallengeDescription", ChallengeDescription);
      // PlayerPrefs.SetFloat("ChallengeTime", ChallengeTimer);
      // PlayerPrefs.SetInt("TotalMoves", TotalMoves);
      // PlayerPrefs.SetInt("ChallengeScore", ChallengeScore);

    }

}
