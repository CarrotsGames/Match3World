using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextChallenge : MonoBehaviour
{
    public string ChallengeScene;
    public void NextChallengeButton()
    {
        int Index = PlayerPrefs.GetInt("ChallengeIndex");
        ChallengeScene = SceneManager.GetActiveScene().name;
        int ChallengesUnlocked = PlayerPrefs.GetInt(ChallengeScene);

        if (Index < ChallengesUnlocked - 1)
        {
            Scene CurrentScene = SceneManager.GetActiveScene();
            ChallengeScene = CurrentScene.name;
            Index += 1;
            PlayerPrefs.SetInt("ChallengeIndex", Index);
            SceneManager.LoadScene(ChallengeScene);
        }
        else
        {
            Debug.Log("no more challenges");
        }
    }
}
