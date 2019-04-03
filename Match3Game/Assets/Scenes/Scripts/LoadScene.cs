using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour {
    public GameObject scoreboard;
    float FirstTimeStartUp;

    public GameObject hungerBar;

    public void Awake()
    {
        FirstTimeStartUp = PlayerPrefs.GetFloat("FTS");
        if (FirstTimeStartUp > 0)
        {
            scoreboard.SetActive(false);
        }
        hungerBar.SetActive(false);

    }
  
    public void DesplayLeaderboard()
    {
        scoreboard.SetActive(true);
        hungerBar.SetActive(false);
    }

    public void TurnOffScoreboard()
    {
        scoreboard.SetActive(false);
        hungerBar.SetActive(true);
    }

}
