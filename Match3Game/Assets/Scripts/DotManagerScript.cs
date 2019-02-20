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
    public Material HighlitedColour;
    public int NumberOfNeighbours;

    public int RedCount;
    public int BlueCount;
    public int YellowCount;
    public int GreenCount;

    public int NumOfPeices;
    public bool CheckConnection;
    private void Start()
    {
        CheckConnection = false;
        //HighlitedColour = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (CheckConnection)
        {
            for (int i = 0; i < Peices.Count; i++)
            {
                Debug.Log(Peices.Count);
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
            if (RedCount == Peices.Count && RedCount > 2)
            {
                Debug.Log("RedCOMPLETE");
                for (int i = 0; i < RedCount; i++)
                {
                    Destroy(RedPieces[i]);
                }
                RedPieces.Clear();
            }
            if (BlueCount == Peices.Count && BlueCount > 2)
            {
                Debug.Log("BlueCOMPLETE");
                for (int i = 0; i < BlueCount; i++)
                {
                    Destroy(BluePieces[i]);
                }
                BluePieces.Clear();

            }
            if (YellowCount == Peices.Count && YellowCount > 2)
            {
                Debug.Log("YellowCOMPLETE");
                for (int i = 0; i < YellowCount; i++)
                {
                    Destroy(YellowPieces[i]);
                }
                YellowPieces.Clear();
            }
            if (GreenCount == Peices.Count && GreenCount > 2)
            {
                Debug.Log("GreenCOMPLETE");
                for (int i = 0; i < GreenCount; i++)
                {
                    Destroy(GreenPieces[i]);
                }
                GreenPieces.Clear();
            }
            if (RedCount != Peices.Count || BlueCount != Peices.Count || GreenCount != Peices.Count || YellowCount != Peices.Count)
            {
                Debug.Log("No connection");
                 RedPieces.Clear();
                BluePieces.Clear();
                YellowPieces.Clear();
                GreenPieces.Clear();
                RedCount = 0;
                BlueCount = 0;
                YellowCount = 0;
                GreenCount = 0;

            }
            Peices.Clear();
        }
        CheckConnection = false;
    }

}
