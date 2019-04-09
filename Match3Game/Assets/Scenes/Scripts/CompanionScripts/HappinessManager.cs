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
    bool CanAdd;
    public string CompanionSave;
    public int MultlpierNum;
    public bool ResetTheMultlpier;
    public bool CheckValue;
    // Use this for initialization
    void Start()
    {
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        CompanionName = Companion.name;
        CanGetCurrency = false;
        CheckValue = true;
        MultlpierNum = PlayerPrefs.GetInt("Multiplier");
         Multplier();
        if (MultlpierNum < 1)
        {
            MultlpierNum = 1;
        }


        switch (CompanionName)
        {
            case "Gobu":
                CompanionSave = "GobuHappiness";
                break;
            case "NEWGOBU":
                CompanionSave = "GobuHappiness";
                break;
            case "Binky":
                CompanionSave = "BinkyHappiness";
                break;
            case "Koko":
                CompanionSave = "KokoHappiness";
                break;
            

        }
        CanAdd = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(CheckValue)
        {
            if (HappinessSliderValue < 20)
            {
                Multplier();
                CanAdd = true;
            }
         
            CheckValue = false;
        }
        // Displays hunger value (used in debug)
        //HungerMetre.text = "" + Hunger;

        // clamps hunger of selected companion from 0 to 100
        HappinessSliderValue = Mathf.Clamp(HappinessSliderValue, 0, 100);
        // Slowly counts down Happiness value
        HappinessSliderValue -= Time.deltaTime / 6;
       
        //displays cuttent slider information with currently used companion
        HappinessSlider.value = HappinessSliderValue;
        PlayerPrefs.SetFloat(CompanionSave, HappinessSliderValue);

        // Saving Companions Happiness value

        if(ResetTheMultlpier)
        {
            MultlpierNum = 2;
            PlayerPrefs.SetInt("Multiplier", MultlpierNum);
            ResetTheMultlpier = false;
        }
        if (CanAdd)
        {
            if (HappinessSliderValue > 90)
            {
                // Add multiplier    
                MultlpierNum += 1;
                PlayerPrefs.SetInt("Multiplier", MultlpierNum);
                CanAdd = false;
                Multplier();

            }
           
        }
        if (!CanAdd)
        {
            // if Happiness less than 20
            if (HappinessSliderValue < 20)
            {
                // Deduct multiplier    
                MultlpierNum -= 1;
                PlayerPrefs.SetInt("Multiplier", MultlpierNum);
                CanAdd = true;
                Multplier();
            }
        }
         
    }

    void Multplier()
    {
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

    
}
