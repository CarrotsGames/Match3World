using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockChallenges : MonoBehaviour
{
    public static int MaxChallenges = 20;
    [HideInInspector]
    public int[] UnlockedLevels;
    private void Start()
    {
        
    }
    void UnlockAllChallenges(string Moobling)
    {
        //UnlockingChallenges = true;
        //switch (Moobling)
        //{
        //    case "GobuChallenge":
        //        for (int i = 0; i < MaxChallenges - 1; i++)
        //        {
        //            UnlockedLevels[i] = 1;
        //            UnlockingChallenges = false;
        //            SaveSystem
        //        }
        //        break;

        //}

    }

}
