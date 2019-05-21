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
        leaderboardNoShow = true;
    }
	
	// Update is called once per frame
	void Update () {
		if(leaderboardShowing == true)
        {
            DesplayLeaderboard();
            leaderboardButton.SetActive(false);
            leaderboardButton2.SetActive(true);

        }else if (leaderboardNoShow == true)
        {
            TurnOffScoreboard();
            leaderboardButton.SetActive(true);
            leaderboardButton2.SetActive(false);
        }

    }

    public void DesplayLeaderboard()
    {
        leaderboardShowing = true;
        scoreboard.SetActive(true);
        hungerBar.SetActive(false);
        inputName.SetActive(true);
        leaderboardNoShow = false;
    }

    public void TurnOffScoreboard()
    {
        leaderboardNoShow = true;
        scoreboard.SetActive(false);
        hungerBar.SetActive(true);
        inputName.SetActive(false);
        leaderboardShowing = false;
    }

}
