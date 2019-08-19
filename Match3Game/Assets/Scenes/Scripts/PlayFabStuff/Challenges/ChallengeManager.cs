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
    void ClearInXMoves()
    {
        if(DotManagerScript.ConnectionMade)
        {
            NumberOfMoves++;
            DotManagerScript.ConnectionMade = false;
        }
        if(NumberOfMoves <= TotalMoves)
        {
            // Canvas included in children so when no nodes 
            // child count is 1
            if(Board.transform.childCount == 1)
            {
                Debug.Log("COMPLETE");
            }
            
        }
        else if (NumberOfMoves > TotalMoves)
        {
            Debug.Log("FAILED");
        }
         
    }

    void ClearBoard()
    {
        if (Board.transform.childCount == 0)
        {
            Debug.Log("COMPLETE");
        }
    }
    void BeatScore()
    {
        ChallengeScore += CompanionScriptRef.Total;
        CompanionScriptRef.Total = 0;
        // Timer?
        if (ChallengeScore > TargetScore)
        {
            Debug.Log("CHALLENGE COMPLETE");
        }
    }
}
