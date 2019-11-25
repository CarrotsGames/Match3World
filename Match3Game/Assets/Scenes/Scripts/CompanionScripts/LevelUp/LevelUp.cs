using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public Text GoldText;
    private Text NewLevel;
    private GameObject HappinessManagerGameObj;
    private HappinessManager HappinessManagerScript;

 
    // Update is called once per frame
    public void ShowNewLevel()
    {
 
        HappinessManagerGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessManagerGameObj.GetComponent<HappinessManager>();
        NewLevel = GetComponent<Text>();
         
        
        NewLevel.text = "" + HappinessManagerScript.Level;
        GoldText.text = "" + HappinessManagerScript.GoldRewardText.text;
    }
}
