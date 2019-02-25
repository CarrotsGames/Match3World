using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
public class DotManagerScript : MonoBehaviour
{

    public List<GameObject> Peices;
    public List<GameObject> RedPieces;
    public List<GameObject> BluePieces;
    public List<GameObject> GreenPieces;
    public List<GameObject> YellowPieces;
    public DotScript dotScript;
    public GameObject DotGameObj;

    public Material HighlitedColour;
    public Material Red;
    public Material Blue;
    public Material Green;
    public Material Yellow;

    public int NumberOfNeighbours = 0;
    public int RedScore;
    public int BlueScore;
    public int YellowScore;
    public int GreenScore;
    public int TotalScore;
    public int Limit;
    public int NumOfPeices;
    public Text HighScore;
    public bool CheckConnection;
    public bool ResetDotLayers;

    private int RedCount;
    private int BlueCount;
    private int YellowCount;
    private int GreenCount;

    private void Start()
    {
        CheckConnection = false;
        ResetDotLayers = false;
        HighScore.text = "" + TotalScore;  
          //HighlitedColour = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        HighScore.text = "" + TotalScore;

        if (CheckConnection)
        {
            for (int i = 0; i < Peices.Count; i++)
            {
 
                if (Peices[i].tag == "Red")
                {
                    RedCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Red;
                    RedPieces.Add(Peices[i]);
                }
                else if (Peices[i].tag == "Blue")
                {
                    BlueCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Blue;

                    BluePieces.Add(Peices[i]);

                }
                else if (Peices[i].tag == "Yellow")
                {
                    YellowCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Yellow;

                    YellowPieces.Add(Peices[i]);

                }
                else if (Peices[i].tag == "Green")
                {
                    GreenCount += 1;
                    Peices[i].GetComponent<Renderer>().material = Green;

                    GreenPieces.Add(Peices[i]);
                }


            }
            if (RedCount == Peices.Count && RedCount > Limit)
            {
                RedScore += RedCount;
                RedScore *= Peices.Count;
                TotalScore += RedScore   ;

                for (int i = 0; i < RedCount; i++)
                {
                    RedPieces[i].layer = LayerMask.GetMask("Default");
                    Destroy(RedPieces[i]);
                }
                RedPieces.Clear();
            }
            if (BlueCount == Peices.Count && BlueCount > Limit)
            {
                BlueScore += BlueCount;
                BlueScore *= Peices.Count;
                TotalScore += BlueScore  ;

                for (int i = 0; i < BlueCount; i++)
                {
                    BluePieces[i].layer = LayerMask.GetMask("Default");

                    Destroy(BluePieces[i]);
                }
                BluePieces.Clear();

            }
            if (YellowCount == Peices.Count && YellowCount > Limit)
            {
                YellowScore += YellowCount;
                YellowScore *= Peices.Count;
                TotalScore += YellowScore;
                for (int i = 0; i < YellowCount; i++)
                {
                    YellowPieces[i].layer = LayerMask.GetMask("Default");
                    Destroy(YellowPieces[i]);
                }
                YellowPieces.Clear();
            }
            if (GreenCount == Peices.Count && GreenCount > Limit)
            {
                GreenScore += GreenCount;
                GreenScore *= Peices.Count;
                TotalScore += GreenScore  ;

                for (int i = 0; i < GreenCount; i++)
                {
                    GreenPieces[i].layer = LayerMask.GetMask("Default");

                    Destroy(GreenPieces[i]);
                }
                GreenPieces.Clear();
            }
            if (RedCount != Peices.Count || BlueCount != Peices.Count || GreenCount != Peices.Count || YellowCount != Peices.Count)
            {
                 
              //  Debug.Log("No connection");
                 RedPieces.Clear();
                BluePieces.Clear();
                YellowPieces.Clear();
                GreenPieces.Clear();
                RedCount = 0;
                BlueCount = 0;
                YellowCount = 0;
                GreenCount = 0;
                NumberOfNeighbours = 0;
                RedScore = 0;
                BlueScore = 0;
                YellowScore = 0;
                GreenScore = 0;
              

                // ResetDotLayers = true;
            }
            Peices.Clear();
        }
        CheckConnection = false;
    }

}
