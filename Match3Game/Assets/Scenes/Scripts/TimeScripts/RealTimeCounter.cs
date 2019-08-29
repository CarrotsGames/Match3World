using UnityEngine;
using System.Collections;
// Counts down happiness of each moobling
// used in HappinessManager, CompanionMonitorScript and CompanionNavigation
// Used in main scene
public class RealTimeCounter : MonoBehaviour
{
 
 

    private float MultlpierCountdown;
    private GameObject HappinessGameObj;
    private GameObject MultiplierGameOb;
    private HappinessManager HappinessManagerScript;
    private SuperMultiplierScript SuperMultiplier;
    string companionName;
    public float SaveNum;
 
    // Use this for initialization
    void Awake()
    {
        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
        // Starting timer amount
        // Update timer with real time passed
        //TODO [Find a better way of doing this]
        this.gameObject.GetComponent<TimeMasterScript>().CheckInstance();
     }
 

    public void SuperMultiplierCountDown()
    {      
      //  HappinessGameObj.GetComponent<HappyMultlpier>().CheckMultplier();

        MultiplierGameOb = GameObject.FindGameObjectWithTag("SM");
        SuperMultiplier = MultiplierGameOb.GetComponent<SuperMultiplierScript>();
        if (SuperMultiplier.MultlpierTimer > -1)
        {
            SuperMultiplier.MultlpierTimer = PlayerPrefs.GetFloat("SMTIMER");
 
            SuperMultiplier.MultlpierTimer -= TimeMasterScript.instance.CheckDate();
            PlayerPrefs.SetFloat("SMTIMER", SuperMultiplier.MultlpierTimer);
            SuperMultiplierScript.CanUseSuperMultiplier = true;

        }
    }
   

 
    // Resets clock based on current hunger and time instance
    public void ResetClock()
    {
       // this.gameObject.GetComponent<TimeMasterScript>().CheckInstance();
        TimeMasterScript.instance.SaveDate();
    }

}
