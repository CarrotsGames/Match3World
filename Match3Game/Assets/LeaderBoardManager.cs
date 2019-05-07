using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardManager : MonoBehaviour {

    public bool leaderboardShowing;
    public bool leaderboardNoShow;

    public GameObject leaderboardButton;
    public GameObject leaderboardButton2;

    public GameObject hungerBar;
    public GameObject scoreboard;

    public GameObject inputName;



    // Use this for initialization
    void Awake () {
    }
	
	// Update is called once per frame
	void Update () {
		if(leaderboardShowing == true)
        {
            leaderboardButton.SetActive(true);
            leaderboardButton2.SetActive(false);
        }else if (leaderboardButton2 == true)
        {
            leaderboardButton.SetActive(false);
            leaderboardButton2.SetActive(true);
        }

    }

    public void DesplayLeaderboard()
    {
        leaderboardShowing = false;
        scoreboard.SetActive(true);
        hungerBar.SetActive(false);
        inputName.SetActive(true);
        leaderboardNoShow = true;
    }

    public void TurnOffScoreboard()
    {
        leaderboardNoShow = false;
        scoreboard.SetActive(false);
        hungerBar.SetActive(true);
        inputName.SetActive(false);
        leaderboardShowing = true;
    }

}
