using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

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
    public Text ClearTime;
   
    // Limit of moves
    private float TotalMoves;
    //Moves done
    private int NumberOfMoves;
    private float Timer;
    private bool ChallengeFinished;
    //BEAT SCORE CHALLENGE
    // Limit of moves
    private int ChallengeScore;
    //CLEAR BOARD CHALLENGE 
    private GameObject Board;
    private GameObject Companion;
    private CompanionScript CompanionScriptRef;
    private GameObject Go;
    private int ChallengeNumber;
    private GameObject DotManagerGameObj;
    private DotManager DotManagerScript;
    private int TargetScore;
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
    private void Update()
    {
        
        if (Lives.LiveCount > 0)
        {
            switch (ChallengeType[ChallengeNumber])
            {
                case "Clear":
                    {
                        ClearTime.text = ChallengeObjectives[ChallengeNumber]  + "\n" + Timer;
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

                        BeatScore();
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
        }
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
            if (NumberOfMoves < TotalMoves)
            {
                // Canvas included in children so when no nodes 
                // child count is 1
                if (Go.transform.childCount < 1)
                {
                    WinGameObject.SetActive(true);

                    Debug.Log("COMPLETE");
                }

            }
            else if (NumberOfMoves >= TotalMoves)
            {
                Lives.CurrentTime = 0;

                Lives.LiveCount -= 1;
                ChallengeFinished = true;
                LoseGameObject.SetActive(true);

                Debug.Log("FAILED");
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
                    Debug.Log("COMPLETE");
                    WinGameObject.SetActive(true);

                }
                else
                {
                    Timer -= Time.deltaTime;
                }
            }
            else
            {
                Lives.LiveCount -= 1;
                ChallengeFinished = true;
                Lives.CurrentTime = 0;
                Debug.Log("FAILED");
                LoseGameObject.SetActive(true);

            }
        }
    }
    void BeatScore()
    {
        ChallengeScore += CompanionScriptRef.Total;
        CompanionScriptRef.Total = 0;
         if (!ChallengeFinished)
        {
           // Timer -= Time.deltaTime;

            if (ChallengeScore > TargetScore)
            {
                Debug.Log("CHALLENGE COMPLETE");
                WinGameObject.SetActive(true);
            }
            else if(Timer < 0)
            {
                Debug.Log("CHALLENGE FAILED");
                Lives.LiveCount -= 1;
                ChallengeFinished = true;
                Lives.CurrentTime = 0;
                LoseGameObject.SetActive(true);

            }
        }
    }
}
