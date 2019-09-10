﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeManager : MonoBehaviour
{
    [Header("WHAT DO YOU DO IN CHALLENGE")]
    public List<string> ChallengeObjectives;
    [Header("OBJECTIVE NUMBER GOAL")]
    public List<float> ChallengeObjectiveScore;
    [Header("Types : Clear, ClearX ,BeatScore")]
    public string[] ChallengeType;
    [Header("Order the level challenges IN ORDER")]
    public GameObject[] ChallengePrefabs;
    public GameObject WinGameObject;
    public GameObject LoseGameObject;
    public GameObject winLoseCanvus;
    public Text ClearTime;
    public Text FailText;

    private GameObject PowerUpManagerObj;
    // Limit of moves
    private float TotalMoves;
    //Moves done
    private int NumberOfMoves;
    private float Timer;
    private bool ChallengeFinished;
    //BEAT SCORE CHALLENGE
    // Limit of moves
    [HideInInspector]
    public int ChallengeScore;
    //CLEAR BOARD CHALLENGE 
    private GameObject Board;
    private GameObject Companion;
    private CompanionScript CompanionScriptRef;
    private GameObject Go;
    private int ChallengeNumber;
    private GameObject DotManagerGameObj;
    private DotManager DotManagerScript;
    private int TargetScore;
    // Used to check how many of each colour nodes are in scene
    private int Red;
    private int Blue;
    private int Green;
    private int Pink;

    // Start is called before the first frame update
    void Start()
    {
        Companion = GameObject.FindGameObjectWithTag("Companion");
        CompanionScriptRef = Companion.GetComponent<CompanionScript>();
        // Finds gameobject with tag in hierarchy 
        DotManagerGameObj = GameObject.FindGameObjectWithTag("DotManager");
        // Grabs dotmanager script on that gameobject to get info
        DotManagerScript = DotManagerGameObj.GetComponent<DotManager>();
        Board = GameObject.FindGameObjectWithTag("BoardSpawn");
        ChallengeNumber = PlayerPrefs.GetInt("ChallengeIndex");
        TargetScore = PlayerPrefs.GetInt("ChallengeScore");
        Go = Instantiate(ChallengePrefabs[ChallengeNumber], ChallengePrefabs[ChallengeNumber].transform.position, Quaternion.identity);

        // ChallengeDescription = PlayerPrefs.GetString("ChallengeDescription");
        Timer = ChallengeObjectiveScore[ChallengeNumber];
        TotalMoves = ChallengeObjectiveScore[ChallengeNumber];
        TargetScore = (int)ChallengeObjectiveScore[ChallengeNumber];
    }

    public void CheckForNodes()
    {
        Red = 0;
        Blue = 0;
        Green = 0;
        Pink = 0;
        for (int i = 0; i < Go.gameObject.transform.childCount; i++)
        {
            if (Go.gameObject.transform.GetChild(i).tag == "Red")
            {
                Red++;
            }
            else if (Go.gameObject.transform.GetChild(i).tag == "Blue")
            {
                Blue++;
            }
            else if (Go.gameObject.transform.GetChild(i).tag == "Green")
            {
                Green++;
            }
            else if (Go.gameObject.transform.GetChild(i).tag == "Yellow")
            {
                Pink++;
            }

        }
        if (ChallengeType[ChallengeNumber] != "BeatScore")
        {
           
         if (Red > 0 && Red < 3)

            {
                FailChallenge();
                FailText.text = "Not enough red nodes";
            }
            else if (Blue > 0 && Blue < 3)
            {
                FailChallenge();
                FailText.text = "Not enough blue nodes";

            }
            else if (Green > 0 && Green < 3)
            {
                FailChallenge();
                FailText.text = "Not enough green nodes";

            }
            else if (Pink > 0 && Pink < 3)
            {
                FailChallenge();
                FailText.text = "Not enough pink nodes";

            }
            // if the beat score challenge is out of nodes
            else if (Red == 0 && Blue == 0 & Green == 0 && Pink == 0 && ChallengeType[ChallengeNumber] == "BeatScore" && ChallengeScore < TargetScore)
            {
                FailChallenge();
                FailText.text = " out of nodes ";
            }
        }
        else
        {
            BeatScore();
        }
        
    }
    private void Update()
    {

        if (Lives.LiveCount > 0)
        {
            switch (ChallengeType[ChallengeNumber])
            {
                case "Clear":
                    {
                        ClearTime.text = ChallengeObjectives[ChallengeNumber] + "\n" + Timer;
                        ClearBoard();
                    }
                    break;
                case "ClearX":
                    {
                        ClearTime.text = ChallengeObjectives[ChallengeNumber] + TotalMoves + " moves \n Moves :" + NumberOfMoves;

                        ClearInXMoves();
                    }
                    break;
                case "BeatScore":
                    {
                        ClearTime.text = ChallengeObjectives[ChallengeNumber] + TargetScore + "\n Total score : " + ChallengeScore;

                       // BeatScore();
                    }
                    break;
                case "":
                    {

                        Debug.LogError("No challenge Set");
                    }

                    break;
            }
        }
        else
        {
            //DISPLAY LIFE COUNT?
            Debug.Log("Out of lives soz");
            SceneManager.LoadScene("Main Screen");
        }
    }
    void CompleteChallenge()
    {
        PowerUpManagerObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerObj.GetComponent<PowerUpManager>().Currency += 10;
        winLoseCanvus.SetActive(true);
        WinGameObject.SetActive(true);
        ChallengeFinished = true;
    }
    void ClearInXMoves()
    {
        if (!ChallengeFinished)
        {
            if (DotManagerScript.ConnectionMade)
            {
                NumberOfMoves++;
                DotManagerScript.ConnectionMade = false;
            }
            if (NumberOfMoves <= TotalMoves)
            {
                // Canvas included in children so when no nodes 
                // child count is 1
                if (Go.transform.childCount < 1)
                {
                    CompleteChallenge();
                }

            }
            else if (NumberOfMoves > TotalMoves)
            {
                FailChallenge();
            }
        }
         
    }

    void ClearBoard()
    {
      //  ClearTime.text = "" + Timer;
        if (!ChallengeFinished)
        {
            if (Timer > 0)
            {

                if (Go.transform.childCount < 1)
                {
                    CompleteChallenge();
                }
                else
                {
                    Timer -= Time.deltaTime;
                }
            }
            else
            {
                FailChallenge();
            }
        }
    }
   public void BeatScore()
    {
        ChallengeScore += CompanionScriptRef.Total;
         if (!ChallengeFinished)
        {
           // Timer -= Time.deltaTime;

            if (ChallengeScore > TargetScore)
            {
                CompleteChallenge();

            }
            else if(Timer < 0)
            {
                FailChallenge();
            }
        }
    }

    void FailChallenge()
    {
        if (!ChallengeFinished)
        {
            Debug.Log("CHALLENGE FAILED");
            Lives.LiveCount -= 1;
            ChallengeFinished = true;
            Lives.CurrentTime = 0;
            winLoseCanvus.SetActive(true);
            LoseGameObject.SetActive(true);
        }
    }
}
