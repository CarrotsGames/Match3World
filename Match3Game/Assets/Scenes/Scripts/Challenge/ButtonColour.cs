using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class ButtonColour : MonoBehaviour
{
    public string MooblingChallengeName;
    private List<int> Test;
    
    void Awake()
    {
        int ChallengesUnlocked = PlayerPrefs.GetInt(MooblingChallengeName);
        if (ChallengesUnlocked == 0)
        {
            ChallengesUnlocked = 5;
           PlayerPrefs.SetInt(MooblingChallengeName, ChallengesUnlocked);

        }
        if(ChallengesUnlocked > 20)
        {
            ChallengesUnlocked = 20;
        }
        for (int i = 0; i < ChallengesUnlocked -1 ; i++)
        {
            transform.GetChild(i).GetComponent<Button>().interactable = true;
            transform.GetChild(i).GetComponent<Button>().image.color = Color.green;

        }

        Test = new List<int>();
        SaveSystem.LoadChallenge(MooblingChallengeName);
        for (int i = 0; i < ChallengeComplete.ChallengeList.Length; i++)
        {
            Test.Add(SaveSystem.LoadChallenge(MooblingChallengeName).CompletedLevels[i]);
            if(Test[i] != 0)
            {
                Debug.Log("YELLOW BUTTON");
                transform.GetChild(i).GetComponent<Button>().image.color = Color.yellow;  
            }
          
        }
      
    }
   public void RefreshHighlite(string MooblingName)
    {
        Test = new List<int>();
       // SaveSystem.LoadChallenge(MooblingChallengeName);
 
        int ChallengesUnlocked = PlayerPrefs.GetInt(MooblingName);

        for (int i = 0; i < ChallengesUnlocked; i++)
        {
            transform.GetChild(i).GetComponent<Button>().interactable = true;
            transform.GetChild(i).GetComponent<Button>().image.color = Color.green;

        }

    }
    //void GetMooblingChallengeInfo(string MooblingChallengeName)
    //{
    //    switch (MooblingChallengeName)
    //    {
    //        case "GobuChallenge":
    //            {

    //            }
    //            break;
    //        case "BinkyChallenge":
    //            {

    //            }
    //            break;
    //        case "KokoChallenge":
    //            {

    //            }
    //            break;
    //        case "CriusChallenge":
    //            {

    //            }
    //            break;
    //        case "SaucoChallenge":
    //            {

    //            }
    //            break;
    //        case "CPChallenge":
    //            {

    //            }
    //            break;
    //        case "SquishyChallenge":
    //            {

    //            }
    //            break;
    //        case "OkamiChallenge":
    //            {

    //            }
    //            break;
    //        case "IdaChallenge":
    //            {

    //            }
    //            break;
    //        case "CronusChallenge":
    //            {

    //            }
    //            break;
    //    }

    // }
}
