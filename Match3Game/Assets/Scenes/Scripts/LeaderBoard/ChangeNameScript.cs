using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeNameScript : MonoBehaviour
{
    GameObject LeaderBoardGameObj;
    LeaderBoardScript LeaderScript;
    
    // Use this for initialization
    void Start()
    {
        LeaderBoardGameObj = GameObject.FindGameObjectWithTag("LeaderBoard");
        LeaderScript = LeaderBoardGameObj.GetComponent<LeaderBoardScript>();
    }

    // Update is called once per frame
    public void ChangeName()
    {
         LeaderScript.UpdateName();
    }
}
