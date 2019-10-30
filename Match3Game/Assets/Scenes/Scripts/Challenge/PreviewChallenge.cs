using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PreviewChallenge : MonoBehaviour
{
   
   public Text ChallengeNumber;
   public Text ChallengeText;
   public Text LivesLeft;
   private GameObject ChallengeGameobject;
    // shows ui text
    public void ShowUI()
    {
        // Challenge manager
        ChallengeGameobject = GameObject.Find("CHALLENGE");
        // current challenge index
        int IndexNumber = PlayerPrefs.GetInt("ChallengeIndex");
        IndexNumber += 1;
        ChallengeNumber.text = "Challenge:" + IndexNumber;
        string ChallengeName = ChallengeGameobject.GetComponent<ChallengeManager>().ChallengeType[IndexNumber - 1];
        ChallengeManager ChallengeScript = ChallengeGameobject.GetComponent<ChallengeManager>();
        if (ChallengeName == "ClearX")
        {           
            // Displays challenge number player is doing
            // Index - 1 is to load the correct challenge according to array
            ChallengeText.text = ChallengeScript.ChallengeObjectives[IndexNumber - 1]+  " : "   + ChallengeScript.TotalMoves + " moves";
            LivesLeft.text = Lives.LiveCount + "";
        }
        else if (ChallengeName == "Clear")
        {
            // Displays challenge number player is doing
            // Index - 1 is to load the correct challenge according to array
            ChallengeText.text = ChallengeScript.ChallengeObjectives[IndexNumber - 1] + " : "  + ChallengeScript.Timer + " Seconds";
            LivesLeft.text = Lives.LiveCount + "";
        }
        else if (ChallengeName == "BeatScore")
        {
            // Displays challenge number player is doing
            // Index - 1 is to load the correct challenge according to array
            ChallengeText.text = ChallengeScript.ChallengeObjectives[IndexNumber - 1] + " "  + ChallengeScript.TargetScore;
            LivesLeft.text = Lives.LiveCount + "";
        }
    }

   public void StopTime()
    {
        Time.timeScale = 0;
        ShowUI();
    }
   public void StartTime()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
