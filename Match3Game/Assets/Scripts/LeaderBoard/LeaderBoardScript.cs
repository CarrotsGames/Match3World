using UnityEngine;
using System.Collections;
using PlayFab;
 using PlayFab.ClientModels;
  public class LeaderBoardScript : MonoBehaviour
{

    GameObject DotManagerObj;
    DotManagerScript dotManagerScript;

    private void Start()
    {

        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
    }
 


 }
