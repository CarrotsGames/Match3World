using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextChallenge : MonoBehaviour
{
    public string ChallengeScene;
    public void NextChallengeButton()
    {
         
        Scene CurrentScene = SceneManager.GetActiveScene();
        ChallengeScene = CurrentScene.name;
        int Index = PlayerPrefs.GetInt("ChallengeIndex");
        Index += 1;
        PlayerPrefs.SetInt("ChallengeIndex", Index);
        SceneManager.LoadScene(ChallengeScene);

    }
}
