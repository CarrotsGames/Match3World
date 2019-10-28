using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpecialNodes : MonoBehaviour
{

    public List<GameObject> SpecialNode;
   // private List<GameObject> NumberOfNodes = new List<GameObject>();
    private GameObject Board;
    public int NumberofNodes;

    private void Start()
    {
         
    }
    public void SpawnNode()
    {
        int SpawnOdds = Random.Range(0, 10);
        if (SpawnOdds == 3)
        {
            if (transform.childCount < NumberofNodes)
            {
                // Creates dots for positions
                GameObject Go = Instantiate(SpecialNode[0], transform.position, Quaternion.identity);
                Go.transform.parent = this.transform;
            }
        }
    }
 
}
