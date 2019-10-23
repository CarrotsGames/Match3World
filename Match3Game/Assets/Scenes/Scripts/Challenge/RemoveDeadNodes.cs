using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//THIS SCRIPT IS USED TO UNPARENT DEAD NODES IN CHALLENGE SCENES
public class RemoveDeadNodes : MonoBehaviour
{
    
 
    private void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "DeadNode")
            {
                transform.GetChild(i).parent = null;
            }
        }
    }
}
