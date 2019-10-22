using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class ButtonColour : MonoBehaviour
{
    public string MooblingChallengeName;
    private List<int> Test;
    
    void Start()
    {
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
}
