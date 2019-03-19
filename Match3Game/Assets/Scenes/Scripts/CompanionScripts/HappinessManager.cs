using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HappinessManager : MonoBehaviour
{
    public GameObject Companion;
    public float Happiness;
    private GameObject DotManagerObj;
    // Must cap at 4
    public int[] multiplier;
    public Slider HappinessSlider;
    string CompanionName;
    private DotManagerScript dotManagerScript;
    public bool CanGetCurrency;
    public string CompanionSave;
    // Use this for initialization
    void Start()
    {
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
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

        // clamps hunger from 0 to 100
        Happiness = Mathf.Clamp(Happiness, 0, 100);

        // Slowly counts down Happiness value
        Happiness -= Time.deltaTime / 3;
        HappinessSlider.value = Happiness;
        PlayerPrefs.SetFloat(CompanionSave, Happiness);

        // Saving Companions Happiness value


        // if Happiness less than 20
        if (Happiness < 20)
        {
            dotManagerScript.Multipier = 1;

        }
        if (Happiness > 20 && Happiness < 40)
        {
            dotManagerScript.Multipier = multiplier[0];

        }
        if (Happiness > 40 && Happiness < 60)
        {
            dotManagerScript.Multipier = multiplier[1];

        }
        if (Happiness > 60 && Happiness < 80)
        {
            dotManagerScript.Multipier = multiplier[2];


        }
        if (Happiness > 80 && Happiness < 100)
        {
            CanGetCurrency = true;
            dotManagerScript.Multipier = multiplier[3];

        }
    }
}
