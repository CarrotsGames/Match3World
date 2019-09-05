using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryChallenge : MonoBehaviour
{
    public string ChallengeScene;

    public void Retry()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        ChallengeScene = CurrentScene.name;
        SceneManager.LoadScene(ChallengeScene);
    }
}
