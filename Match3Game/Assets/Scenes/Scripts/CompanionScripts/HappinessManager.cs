using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HappinessManager : MonoBehaviour
{
    public GameObject Companion;
    public float HappinessSliderValue;
    private GameObject DotManagerObj;
    // Must cap at 4
    public int[] multiplier;
    public Slider HappinessSlider;
    string CompanionName;
    private DotManager DotManagerScript;
    public bool CanGetCurrency;
    bool CanEarnGold;
    public string CompanionSave;
    public int MultlpierNum;
    public bool ResetTheMultlpier;
    public bool CheckValue;
    public bool IsSleeping;
    string SaveStrings;
    public Animator Anim;

    public GameObject DayTime;
    public GameObject NightTime;
    public GameObject AwakeHead;
    // Use this for initialization
    void Start()
    {
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        CompanionName = Companion.name;
        CanGetCurrency = false;
        CheckValue = true;

        

        // Checks which companion is loaded to gather save data 
        switch (CompanionName)
        {
            case "Gobu":
                CompanionSave = "GobuHappiness";
                SaveStrings = "GOBUSAVE";
                break;
            case "NEWGOBU":
                CompanionSave = "GobuHappiness";
                SaveStrings = "GOBUSAVE";
                break;
            case "Binky":
                CompanionSave = "BinkyHappiness";
                SaveStrings = "BINKYSAVE";
                break;
            case "Koko":
                CompanionSave = "KokoHappiness"; 
                SaveStrings = "KOKOSAVE";
                break;
            case "Crius":
                CompanionSave = "CriusHappiness";
                SaveStrings = "CRIUSSAVE";
                break;
            

        }
        // Gets the last known bool for this companion
        IsSleeping = (PlayerPrefs.GetInt(SaveStrings) != 0);
        // checks if bool puts companion to sleep
        Sleeping();
        Multplier();

        if (MultlpierNum < 1)
        {
            MultlpierNum = 1;
        }
     }

    // Update is called once per frame
    void Update()
    {
        HappinessStates();
        if (CheckValue)
        {
            if (HappinessSliderValue < 20)
            {
                Multplier();
                CanEarnGold = false;
            }
         
            CheckValue = false;
        }
        // Displays hunger value (used in debug)
        //HungerMetre.text = "" + Hunger;

        // clamps hunger of selected companion from 0 to 100
        HappinessSliderValue = Mathf.Clamp(HappinessSliderValue, 0, 100);
        // Slowly counts down Happiness value
        HappinessSliderValue -= Time.deltaTime / 6;
       
        //displays current slider information with currently used companion
        HappinessSlider.value = HappinessSliderValue;
        PlayerPrefs.SetFloat(CompanionSave, HappinessSliderValue);

        // Saving Companions Happiness value

        if(ResetTheMultlpier)
        {
            MultlpierNum = 2;
            PlayerPrefs.SetInt("Multiplier", MultlpierNum);
            ResetTheMultlpier = false;
        }
        
        if (!CanEarnGold)
        {
            if (HappinessSliderValue > 95)
            {
                // go to sleep
                // Add multiplier    
                MultlpierNum += 1;
                PlayerPrefs.SetInt("Multiplier", MultlpierNum);
                CanEarnGold = true;
                Multplier();
                IsSleeping = true;
                PlayerPrefs.SetInt(SaveStrings, (IsSleeping ? 1 : 0));

                // yourBool = (PlayerPrefs.GetInt("Name") != 0);
            }

        }
        if (CanEarnGold)
        {
            // if Happiness less than 20
            if (HappinessSliderValue < 33 && IsSleeping)
            {
                // wake up
                // Deduct multiplier    
                MultlpierNum -= 1;
                PlayerPrefs.SetInt("Multiplier", MultlpierNum);
                CanEarnGold = false;
                Multplier();
                IsSleeping = false ;
                // SavesBool
                PlayerPrefs.SetInt(SaveStrings, (IsSleeping ? 1 : 0));

            }
        }
         
    }

    void Multplier()
    {
        // Number of multlpier matches number of creatures in game (10 creatures MAX at the moment
        switch (MultlpierNum)
        {
            case 1:
                DotManagerScript.Multipier = multiplier[0];
                break;
            case 2:
                DotManagerScript.Multipier = multiplier[1];

                break;
            case 3:
                DotManagerScript.Multipier = multiplier[2];

                break;
            case 4:
                DotManagerScript.Multipier = multiplier[3];

                break;
            case 5:
                DotManagerScript.Multipier = multiplier[4];

                break;
            case 6:
                DotManagerScript.Multipier = multiplier[5];

                break;
            case 7:
                DotManagerScript.Multipier = multiplier[6];

                break;
            case 8:
                DotManagerScript.Multipier = multiplier[7];

                break;
            case 9:
                DotManagerScript.Multipier = multiplier[8];

                break;
        }
    }

    void HappinessStates()
    {
        if (HappinessSliderValue > 0 && HappinessSliderValue < 20 && !IsSleeping)
        {
            // Animation 
            Anim.SetBool("<20", true);
            Anim.SetBool("is>33", false);
            Anim.SetBool("is>66", false);
            NightTime.SetActive(false);
            DayTime.SetActive(true);
            AwakeHead.SetActive(true);
            Anim.SetBool("is sleepy", false);

        }
        else if (HappinessSliderValue > 20 && HappinessSliderValue < 66 && !IsSleeping)
        {
            // Animation 
            Anim.SetBool("is>33", true);
            Anim.SetBool("<20", false);
            Anim.SetBool("is>66", false);

        }
        else if (HappinessSliderValue > 66 && HappinessSliderValue < 95 && !IsSleeping) 
        {
            // Animation 
            Anim.SetBool("is>33", false);
            Anim.SetBool("<20", false);
            Anim.SetBool("is>66", true);

        }
        else if (HappinessSliderValue > 95 && HappinessSliderValue < 100)
        {
            // Animation 
            Anim.SetBool("is sleepy", true);
            //Anim.SetBool("is>66", false);
            NightTime.SetActive(true);
            DayTime.SetActive(false);
            AwakeHead.SetActive(false);
            // Music Change
        }

    }

    void Sleeping()
    {
        // checks if Companion is sleeping
        if(IsSleeping)
        {
            Anim.SetBool("is>33", false);

            Anim.SetBool("is sleepy", true);
            NightTime.SetActive(true);
            AwakeHead.SetActive(false);
            CanEarnGold = true;
            MultlpierNum = PlayerPrefs.GetInt("Multiplier");
            NightTime.SetActive(true);
            DayTime.SetActive(false);

            Debug.Log("Sleeping");
        }
        else
        {
            CanEarnGold = false;
            MultlpierNum = PlayerPrefs.GetInt("Multiplier");
            DayTime.SetActive(true);
            NightTime.SetActive(false);
            Anim.SetBool("<20", true);

            Debug.Log("NotSleeping");

        }
    }
}
