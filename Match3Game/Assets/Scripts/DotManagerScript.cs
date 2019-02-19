using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class DotManagerScript : MonoBehaviour
{

    public List<GameObject> Peices;
    public int RedCount;
    public int BlueCount;
    public int YellowCount;
    public int GreenCount;

    public int NumOfPeices;
    public bool CheckConnection;
    private void Start()
    {
        CheckConnection = false;
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
                }
                else if (Peices[i].tag == "Blue")
                {
                    BlueCount += 1;
                }
                else if (Peices[i].tag == "Yellow")
                {
                    YellowCount += 1;
                }
                else if (Peices[i].tag == "Green")
                {
                    GreenCount += 1;
                }
 
 
            }
        }
    }

 }
