using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class ButtonColour : MonoBehaviour
{
    public GameObject UnlockAll;
    public string MooblingChallengeName;
    private List<int> Test;
    private int NumOfYellow;
    void Awake()
    {
        // to reset all challenges
    //    PlayerPrefs.SetInt(MooblingChallengeName, 0);

        int ChallengesUnlocked = PlayerPrefs.GetInt(MooblingChallengeName);
        if (ChallengesUnlocked <= 0)
        {
            ChallengesUnlocked = 5;
           PlayerPrefs.SetInt(MooblingChallengeName, ChallengesUnlocked);

        }
        if(ChallengesUnlocked > 20)
        {
            ChallengesUnlocked = 20;
        }
        int NumOfUnlocked = 0;

        for (int i = 0; i < ChallengesUnlocked  ; i++)
        {
            transform.GetChild(i).GetComponent<Button>().interactable = true;
            transform.GetChild(i).GetComponent<Button>().image.color = Color.green;
            NumOfUnlocked++;

        }
        if (NumOfUnlocked == 20)
        {
            UnlockAll.SetActive(false);

        }
        Test = new List<int>();
        SaveSystem.LoadChallenge(MooblingChallengeName);
        NumOfYellow = 0;
        for (int i = 0; i < ChallengeComplete.ChallengeList.Length; i++)
        {
            Test.Add(SaveSystem.LoadChallenge(MooblingChallengeName).CompletedLevels[i]);
            if(Test[i] != 0)
            {
               NumOfYellow++;
               transform.GetChild(i).GetComponent<Button>().image.color = Color.yellow;
            }
          
        }
      
    }

 // used after unlocking all challenges
    public void RefreshHighlite(string MooblingName)
    {
        Test = new List<int>();
       // SaveSystem.LoadChallenge(MooblingChallengeName);
 
        int ChallengesUnlocked = PlayerPrefs.GetInt(MooblingName);

        for (int i = NumOfYellow; i < ChallengesUnlocked; i++)
        {
            transform.GetChild(i).GetComponent<Button>().interactable = true;
            transform.GetChild(i).GetComponent<Button>().image.color = Color.green;
        }
        UnlockAll.SetActive(false);


    }
     
}
