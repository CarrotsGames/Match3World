using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SuperMultiplierScript : MonoBehaviour
{
    public Transform MultplierBar;
    
    public int SuperMultiplier;
    public float MultlpierTimer;
    public GameObject SMTimerUI;
    public Text MultlpierTimerText;
    private float TimerStore;
    private GameObject PowerUpManGameObj;
    private GameObject HappinessGameObj;
    private HappinessManager HappinessManagerScript;
    private PowerUpManager PowerUpManagerScript;
    bool CanUseSuperMultiplier;
    public bool EndCountdown;
    int TimesUsed;
    private GameObject DisablePowerUpGameObj;

    // Use this for initialization
    void Start()
    {
        TimesUsed = PlayerPrefs.GetInt("SUPERMULTLPIER");
        DisablePowerUpGameObj = GameObject.Find("PowerUps");

        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
         EndCountdown = false;
        //MultlpierTimer = PlayerPrefs.GetFloat("SMTIMER");
        TimerStore = MultlpierTimer;
        // if its greater than zero continue countdown
        // NOTE: Realtimecounter is always coutning down Multiplier timer 
        // It counts down past 0 to avoid this always being true
        
        MultlpierTimer = PlayerPrefs.GetFloat("SMTIMER");
       
        SMTimerUI.SetActive(false);

        if (MultlpierTimer > 0)
        {
            CanUseSuperMultiplier = true;
        }
        else
        {
            MultlpierTimer = TimerStore;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        // if the multlpiler powerup is in use start countdown until its over
        if (CanUseSuperMultiplier)
        {
            // goes through multiplier list and times each one by super multlplier
            for (int i = 0; i < HappinessGameObj.GetComponent<HappyMultlpier>().multiplier.Length; i++)
            {
                if (i > 0)
                {
                   // test = HappinessGameObj.GetComponent<HappyMultlpier>().multiplier[i];
                   // test *= test;
                    HappinessGameObj.GetComponent<HappyMultlpier>().multiplier[i] = HappinessGameObj.GetComponent<HappyMultlpier>().multiplier[i] * 2;
                    EndCountdown = true;
                 }
                else
                {
                    HappinessGameObj.GetComponent<HappyMultlpier>().multiplier[i] *= SuperMultiplier;
                }
            }
            CanUseSuperMultiplier = false;

        }
        if (EndCountdown)
        {
            PlayerPrefs.SetFloat("SMTIMER", MultlpierTimer);
            MultlpierTimer -= Time.deltaTime;
            // Disables button so user cannot stack multplier
            SMTimerUI.SetActive(true);
            MultlpierTimerText.text = "" + MultlpierTimer;
            MultplierBar.GetComponent<Image>().fillAmount = MultlpierTimer / 80;

            if (MultlpierTimer < 0)
            {

                int test;
              
                 // Goes through multiplier list and returns variables to defual
                for (int i = 0; i < HappinessGameObj.GetComponent<HappyMultlpier>().multiplier.Length; i++)
                {
                    if (i > 0)
                    {
                        test = HappinessGameObj.GetComponent<HappyMultlpier>().multiplier[i - 1];
                        test += 1;
                        HappinessGameObj.GetComponent<HappyMultlpier>().multiplier[i] = test;
                    }
                    else
                    {
                        HappinessGameObj.GetComponent<HappyMultlpier>().multiplier[i] /= SuperMultiplier;
                    }
                }
                DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM = false;
                PlayerPrefs.SetInt("DISABLESM", (DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM ? 1 : 0));
                DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableFreeze = false;
                PlayerPrefs.SetInt("DISABLEFREEZE", (DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableFreeze ? 1 : 0));
                DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableNodes();

                EndCountdown = false;
                CanUseSuperMultiplier = false;
                PowerUpManagerScript.HasMultlpliers = true;
                SMTimerUI.SetActive(false);

            }
        }
    }

    public void SuperMultplierButton()
    {
        //Debug.Log("BUTTON PRESSED");
        if (PowerUpManagerScript.HasMultlpliers && !EndCountdown)
        {
            DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableFreeze = true;
            DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM = true;
            PlayerPrefs.SetInt("DISABLEFREEZE", (DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableFreeze ? 1 : 0));
            PlayerPrefs.SetInt("DISABLESM", (DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM ? 1 : 0));
            DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableNodes();
            MultlpierTimer = TimerStore;

            // Counts how many times player uses this powerup
            TimesUsed++;
            PlayerPrefs.SetInt("SUPERMULTLPIER", TimesUsed);

            MultlpierTimer = 80;
            PowerUpManagerScript.NumOfMultilpiers -= 1;
            CanUseSuperMultiplier = true;
          //  Debug.Log(CanUseSuperMultiplier);
        }
    }
}
