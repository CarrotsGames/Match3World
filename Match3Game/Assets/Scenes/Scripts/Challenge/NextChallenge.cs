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

        if (Index != 4)
        {
            Scene CurrentScene = SceneManager.GetActiveScene();
            ChallengeScene = CurrentScene.name;
            Index += 1;
            PlayerPrefs.SetInt("ChallengeIndex", Index);
            SceneManager.LoadScene(ChallengeScene);
        }
    }
}
