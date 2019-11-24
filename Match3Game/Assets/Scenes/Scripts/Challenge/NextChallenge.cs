using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextChallenge : MonoBehaviour
{
    public string ChallengeScene;
    [Header("Needed only in challenge scenes")]
    public GameObject OutOfLevelCanvas;

    private void Start()
    {
        string CurrenctScene = SceneManager.GetActiveScene().name;
        if (CurrenctScene != " Main Screen")
        {
            CheckIndex();
        }
    }
    public void CheckIndex()
    {
        int Index = PlayerPrefs.GetInt("ChallengeIndex");
        ChallengeScene = SceneManager.GetActiveScene().name;

        int ChallengesUnlocked = PlayerPrefs.GetInt(ChallengeScene);
        if(ChallengesUnlocked > 20)
        {
            ChallengesUnlocked = 20;
        }
        if (Index >= ChallengesUnlocked - 1)
        {
            OutOfLevelCanvas.SetActive(true);
        }
    }
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
            OutOfLevelCanvas.SetActive(true);
            Debug.Log("no more challenges");
        }
    }
}
