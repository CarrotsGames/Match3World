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
    public string CompanionSave;
    // Use this for initialization
    void Start()
    {
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        CompanionName = Companion.name;
        CanGetCurrency = false;

        switch (CompanionName)
        {
            case "Gobu":
                CompanionSave = "GobuHappiness";
                break;
            case "Binky":

                CompanionSave = "BinkyHappiness";
                break;
            case "Koko":
                CompanionSave = "KokoHappiness";

                break;
            

        }
    }

    // Update is called once per frame
    void Update()
    {
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



        // if Happiness less than 20
        if (HappinessSliderValue < 20)
        {
            DotManagerScript.Multipier = 1;

        }
        if (HappinessSliderValue > 20 && HappinessSliderValue < 40)
        {
            DotManagerScript.Multipier = multiplier[0];

        }
        if (HappinessSliderValue > 40 && HappinessSliderValue < 60)
        {
            DotManagerScript.Multipier = multiplier[1];

        }
        if (HappinessSliderValue > 60 && HappinessSliderValue < 80)
        {
            DotManagerScript.Multipier = multiplier[2];


        }
        if (HappinessSliderValue > 80 && HappinessSliderValue < 100)
        {
            CanGetCurrency = true;
            DotManagerScript.Multipier = multiplier[3];

        }
    }

    
}
