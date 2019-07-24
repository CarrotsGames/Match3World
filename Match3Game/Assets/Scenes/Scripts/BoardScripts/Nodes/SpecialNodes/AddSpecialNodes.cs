using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpecialNodes : MonoBehaviour
{

    public List<GameObject> SpecialNode;
   // private List<GameObject> NumberOfNodes = new List<GameObject>();
    private GameObject Board;
    int NumberofNodes;

    private void Start()
    {
      // for (int i = 0; i < 5; i++)
      // {
      //  GameObject Go =  Instantiate(SpecialNode[0], transform.position, Quaternion.identity);
      //  Go.transform.parent = this.transform;
      // }

    }
   public void SpawnNode()
    {
        int SpawnOdds = Random.Range(0, 10);
        if (SpawnOdds == 3)
        {
            if (transform.childCount < 5)
            {
                // Creates dots for positions
                GameObject Go = Instantiate(SpecialNode[0], transform.position, Quaternion.identity);
                Go.transform.parent = this.transform;
            }
        }
    }
    private void Update()
    {
      
    }
 
 //  public void AddNode()
 //  {
 //  
 //      Board = GameObject.FindGameObjectWithTag("BoardSpawn");
 //
 //      int UseSpecialNode = Random.Range(0,5);
 //      if(UseSpecialNode == 7 && NumberofNodes < 5)
 //      {
 //         GameObject Go = Instantiate(SpecialNode[0], transform.position, Quaternion.identity);
 //          Go.transform.parent = this.transform;
 //
 //      }
 //  }
}
