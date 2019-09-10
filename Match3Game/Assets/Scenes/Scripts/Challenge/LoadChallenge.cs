using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class LoadChallenge : MonoBehaviour
{
    [Header("Challenge scene name")]
    public string ChallengeScene;
 
    public void SelectChallenge(int Index)
    {
        if (Lives.LiveCount > 0)
        {
            //   PlayerPrefs.SetString("ChallengeType", ChallengeType);
            SceneManager.LoadScene(ChallengeScene);
            PlayerPrefs.SetInt("ChallengeIndex", Index);
            // PlayerPrefs.SetString("ChallengeDescription", ChallengeDescription);
            // PlayerPrefs.SetFloat("ChallengeTime", ChallengeTimer);
            // PlayerPrefs.SetInt("TotalMoves", TotalMoves);
            // PlayerPrefs.SetInt("ChallengeScore", ChallengeScore);
        }
        else
        {
            Debug.Log("OUT OF LIVES");
        }
    }

}
