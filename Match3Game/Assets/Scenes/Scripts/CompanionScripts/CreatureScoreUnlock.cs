﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureScoreUnlock : MonoBehaviour {
    public int[] UnlockScore;
    private string UnlockableString;
    public GameObject UnlockableCreaturesGameObj;
    DotManager DotManagerScript;
    GameObject DotManagerGameObj;

    // Use this for initialization
    void Start ()
    {
        DotManagerGameObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerGameObj.GetComponent<DotManager>();
    }
	
	// Update is called once per frame
	void Update () {

        CreatureUnlock();

    }
    // unlcoks the creature when the score has been met
    void CreatureUnlock()
    {

        if (UnlockableCreaturesGameObj.GetComponent<UnlockableCreatures>() != null)
        {
            //Binkies unlock
            if (DotManagerScript.TotalScore > UnlockScore[0] && UnlockableCreaturesGameObj.GetComponent<UnlockableCreatures>().UnlockableMoobling[0] != "BINKY")
            {

                UnlockableString = "BINKY";
                PlayerPrefs.SetString("UNLOCKED", UnlockableString);
                UnlockableCreaturesGameObj.GetComponent<UnlockableCreatures>().Unlock();

            }
            //kokos unlock
            if (DotManagerScript.TotalScore > UnlockScore[1] && UnlockableCreaturesGameObj.GetComponent<UnlockableCreatures>().UnlockableMoobling[0] != "KOKO")
            {

                UnlockableString = "KOKO";
                PlayerPrefs.SetString("UNLOCKED", UnlockableString);
                UnlockableCreaturesGameObj.GetComponent<UnlockableCreatures>().Unlock();

            }
        }
        else
        {
            Debug.Log("NOTHINGHERE");
        }
    }
}