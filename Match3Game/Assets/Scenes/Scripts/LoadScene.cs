﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour {
    public GameObject scoreboard;

    public void Awake()
    {
        scoreboard.SetActive(false);
    }

    public void SceneLoad()
    {
        SceneManager.LoadScene("Gobu Level");
    }

    public void DesplayLeaderboard()
    {
        scoreboard.SetActive(true);
    }

    public void TurnOffScoreboard()
    {
        scoreboard.SetActive(false);
    }

}