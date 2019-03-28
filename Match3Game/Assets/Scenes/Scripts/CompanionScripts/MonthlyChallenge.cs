using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonthlyChallenge : MonoBehaviour {
    public float ChallengeScore;
    DotManagerScript DotManagerScriptRef;
    GameObject DotManagerGameObj;
    public GameObject PrizeCompanion;
	// Use this for initialization
	void Start () {
        DotManagerGameObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScriptRef = DotManagerGameObj.GetComponent<DotManagerScript>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(DotManagerScriptRef.TotalScore > ChallengeScore)
        {
            // ADD PRIZE COMPANION TO ROSTER
            Debug.Log("YOU GOT THE PRIZE");
        }
        else
        {
            Debug.Log("RESET OR HAVENT REACHED PRIZE");
        }
	}
}
