using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class DotManagerScript : MonoBehaviour
{

    public List<GameObject> Peices;
    public int ColourPoint;
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
            for (NumOfPeices = 0; NumOfPeices < Peices.Capacity; NumOfPeices++)
            {
                if (Peices[NumOfPeices].tag == "Green")
                {
                    Debug.Log("Green");
                    ColourPoint += 1;
                }
                else
                {
                    CheckConnection = false;
                    Peices.Clear();
                    break;
                }
            }
         
        }
         
    }

 }
