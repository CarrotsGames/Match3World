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
    bool StartCountdown;
    // Use this for initialization
    void Start()
    {
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
        CanUseSuperMultiplier = true;
        StartCountdown = false;
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
                int test;
                if (i > 0)
                {
                    test = HappinessGameObj.GetComponent<HappyMultlpier>().multiplier[i - 1];
                    test *= SuperMultiplier;
                    HappinessGameObj.GetComponent<HappyMultlpier>().multiplier[i] = test;
                }
                else
                {
                    HappinessGameObj.GetComponent<HappyMultlpier>().multiplier[i] *= SuperMultiplier;
                }
            }
            StartCountdown = true;
        }
        if (StartCountdown)
        {
            PlayerPrefs.SetFloat("SMTIMER", MultlpierTimer);
            MultlpierTimer -= Time.deltaTime;
            // Disables button so user cannot stack multplier
            CanUseSuperMultiplier = false;
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
                StartCountdown = false;
                MultlpierTimer = TimerStore;
                CanUseSuperMultiplier = false;
                PowerUpManagerScript.HasMultlpliers = true;
                SMTimerUI.SetActive(false);

            }
        }
    }

    public void SuperMultplierButton()
    {
        if (PowerUpManagerScript.HasMultlpliers && !StartCountdown)
        {
            PowerUpManagerScript.NumOfMultilpiers -= 1;
            CanUseSuperMultiplier = true;
        }
    }
}
