using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
    public int NumberOfNeighbours = 0;

    public int RedCount;
    public int BlueCount;
    public int YellowCount;
    public int GreenCount;
    public int Limit;
    public int NumOfPeices;
    public bool CheckConnection;
    public bool ResetDotLayers;
    private void Start()
    {
        CheckConnection = false;
        ResetDotLayers = false;
         //HighlitedColour = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (CheckConnection)
        {
            for (int i = 0; i < Peices.Count; i++)
            {
 
                if (Peices[i].tag == "Red")
                {
                    RedCount += 1;
                    RedPieces.Add(Peices[i]);
                }
                else if (Peices[i].tag == "Blue")
                {
                    BlueCount += 1;
                    BluePieces.Add(Peices[i]);

                }
                else if (Peices[i].tag == "Yellow")
                {
                    YellowCount += 1;
                    YellowPieces.Add(Peices[i]);

                }
                else if (Peices[i].tag == "Green")
                {
                    GreenCount += 1;
                    GreenPieces.Add(Peices[i]);
                }


            }
            if (RedCount == Peices.Count && RedCount > Limit)
            {
 
                for (int i = 0; i < RedCount; i++)
                {
                    RedPieces[i].layer = LayerMask.GetMask("Default");
                    Destroy(RedPieces[i]);
                }
                RedPieces.Clear();
            }
            if (BlueCount == Peices.Count && BlueCount > Limit)
            {
                 for (int i = 0; i < BlueCount; i++)
                {
                    BluePieces[i].layer = LayerMask.GetMask("Default");

                    Destroy(BluePieces[i]);
                }
                BluePieces.Clear();

            }
            if (YellowCount == Peices.Count && YellowCount > Limit)
            {
                 for (int i = 0; i < YellowCount; i++)
                {
                    YellowPieces[i].layer = LayerMask.GetMask("Default");
                    Destroy(YellowPieces[i]);
                }
                YellowPieces.Clear();
            }
            if (GreenCount == Peices.Count && GreenCount > Limit)
            {
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
                // ResetDotLayers = true;
                
            }
            Peices.Clear();
        }
        CheckConnection = false;
    }

}
