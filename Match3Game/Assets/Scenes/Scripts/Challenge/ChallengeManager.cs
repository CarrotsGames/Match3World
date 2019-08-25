using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class ChallengeManager : MonoBehaviour
{
    [Header("Types : Clear, ClearX , BeatScore")]

    public string ChallengeType;
    //Speak Bubbles
    private GameObject DotManagerGameObj;
    private DotManager DotManagerScript;
    public string ChallengeDescription;
    public Text ChallengeText;
    //FINISH IN MOVES
    [Header("CLEAR IN X MOVES CHALLENGE")]
    // Limit of moves
    public int TotalMoves;
    //Moves done
    private int NumberOfMoves;
    [Header("CLEAR BOARD IN TIME CHALLENGE")]
    public float Timer;
    public Text ClearTime;
    private bool ChallengeFinished;
    //BEAT SCORE CHALLENGE
    [Header("BEAT SCORE CHALLENGE")]
    // Limit of moves
    public int TargetScore;
    private int ChallengeScore;
    //CLEAR BOARD CHALLENGE 
    private GameObject Board;
    private BoardScript BoardScriptRef;
    private GameObject Companion;
    private CompanionScript CompanionScriptRef;
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
        BoardScriptRef = Board.GetComponent<BoardScript>();
    }
    private void Update()
    {
        
        ChallengeText.text = ChallengeDescription;
        if (Lives.LiveCount > 0)
        {
            switch (ChallengeType)
            {
                case "Clear":
                    {
                        ClearBoard();
                    }
                    break;
                case "ClearX":
                    {
                        ClearInXMoves();
                    }
                    break;
                case "BeatScore":
                    {
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
            if (NumberOfMoves <= TotalMoves)
            {
                // Canvas included in children so when no nodes 
                // child count is 1
                if (Board.transform.childCount == 1)
                {
                    Debug.Log("COMPLETE");
                }

            }
            else if (NumberOfMoves > TotalMoves)
            {
                Lives.LiveCount -= 1;
                ChallengeFinished = true;
                Debug.Log("FAILED");
            }
        }
         
    }

    void ClearBoard()
    {
        ClearTime.text = "" + Timer;
        if (!ChallengeFinished)
        {
            if (Timer > 0)
            {

                if (Board.transform.childCount == 1)
                {
                    Debug.Log("COMPLETE");
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

                Debug.Log("FAILED");
            }
        }
    }
    void BeatScore()
    {
        ChallengeScore += CompanionScriptRef.Total;
        CompanionScriptRef.Total = 0;
        // Timer?
        if (!ChallengeFinished)
        {
            if (ChallengeScore > TargetScore)
            {
                Debug.Log("CHALLENGE COMPLETE");
            }
        }
    }
}
