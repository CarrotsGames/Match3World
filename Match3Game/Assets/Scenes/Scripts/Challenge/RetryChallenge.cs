using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryChallenge : MonoBehaviour
{
    public string ChallengeScene;

    // used to retry during the challange
    public void Retry()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        ChallengeScene = CurrentScene.name;
        SceneManager.LoadScene(ChallengeScene);
        Lives.LiveCount -= 1;
        PlayerPrefs.SetInt("LIVECOUNT", Lives.LiveCount);
    }
    // used to retry after challange
    public void RetryAfterChallange()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        ChallengeScene = CurrentScene.name;
        SceneManager.LoadScene(ChallengeScene);
    }

}
