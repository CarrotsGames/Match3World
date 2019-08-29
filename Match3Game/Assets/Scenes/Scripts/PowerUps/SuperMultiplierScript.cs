using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SuperMultiplierScript : MonoBehaviour
{
    public Transform MultplierBar;
    private RealTimeCounter RealTimeScript;
    private GameObject MainCamera;

    public static int SuperMultiplier;
    public float MultlpierTimer;
    public GameObject SMTimerUI;
    public Text MultlpierTimerText;
    private float TimerStore;
    private GameObject PowerUpManGameObj;
    private GameObject HappinessGameObj;
    private HappinessManager HappinessManagerScript;
    private PowerUpManager PowerUpManagerScript;
    public bool CanUseSuperMultiplier;
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

        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = MainCamera.GetComponent<RealTimeCounter>();
       // RealTimeScript.SuperMultiplierCountDown();
        SMTimerUI.SetActive(false);
        MultlpierTimer = PlayerPrefs.GetInt("SMTIMER");
        RealTimeScript.SuperMultiplierCountDown();
        if (MultlpierTimer < 0)
        {
            MultlpierTimer = 80;
            CanUseSuperMultiplier = false;
            DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM = false;
            PlayerPrefs.SetInt("DISABLESM", (DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM ? 1 : 0));
            DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableNodes();

        }
     //  DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM = false;
     //  PlayerPrefs.SetInt("DISABLESM", (DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM ? 1 : 0));
     //  DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableNodes();
    }
    

    // Update is called once per frame
    void Update()
    {
        // if the multlpiler powerup is in use start countdown until its over
        if (CanUseSuperMultiplier)
        {
            SMTimerUI.SetActive(true);

            DisablePowerUpGameObj = GameObject.Find("PowerUps");

            // test *= test;
            HappinessManagerScript.HappinessBar();
            SuperMultiplier = HappinessGameObj.GetComponent<HappinessManager>().Level * 2;
            // Multiplier = Text.multiplier
            MultplierBar.GetComponent<Image>().fillAmount = MultlpierTimer / 80;


            MultlpierTimer -= Time.deltaTime;
            PlayerPrefs.SetFloat("SMTIMER", MultlpierTimer);

            if (MultlpierTimer < 0)
            {

                PlayerPrefs.SetFloat("SMTIMER", MultlpierTimer);
                MultlpierTimer -= Time.deltaTime;
                // Disables button so user cannot stack multplier
                SMTimerUI.SetActive(true);
                MultlpierTimerText.text = "" + MultlpierTimer;
                MultplierBar.GetComponent<Image>().fillAmount = MultlpierTimer / 80;

                DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM = false;
                PlayerPrefs.SetInt("DISABLESM", (DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM ? 1 : 0));

                DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableNodes();
                SuperMultiplier = 0;
                EndCountdown = false;
                CanUseSuperMultiplier = false;
                PowerUpManagerScript.HasMultlpliers = true;
                SMTimerUI.SetActive(false);

            }
        }
      
    }

    public void SuperMultplierButton()
    {
        PowerUpManGameObj.GetComponent<PowerUpManager>().PowerUpChecker();

        //Debug.Log("BUTTON PRESSED");
        if (PowerUpManagerScript.HasMultlpliers && !EndCountdown)
        {
            PowerUpManagerScript.NumOfMultilpiers -= 1;
            PowerUpManGameObj.GetComponent<PowerUpManager>().PowerUpSaves();

            DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM = true;
            PlayerPrefs.SetInt("DISABLESM", (DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableSM ? 1 : 0));
            DisablePowerUpGameObj.GetComponent<DisablePowerUps>().DisableNodes();
            MultlpierTimer = TimerStore;

            // Counts how many times player uses this powerup
            TimesUsed++;
            PlayerPrefs.SetInt("SUPERMULTLPIER", TimesUsed);

            MultlpierTimer = 80;
 
            CanUseSuperMultiplier = true;
          //  Debug.Log(CanUseSuperMultiplier);
        }
    }
}
