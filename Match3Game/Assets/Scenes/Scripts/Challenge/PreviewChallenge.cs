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
        // Displays challenge number player is doing
        // Index - 1 is to load the correct challenge according to array
        ChallengeText.text = ChallengeGameobject.GetComponent<ChallengeManager>().ChallengeObjectives[IndexNumber - 1 ]  ;
        LivesLeft.text = Lives.LiveCount + "" ;
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
