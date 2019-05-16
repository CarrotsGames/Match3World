using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HappinessManager : MonoBehaviour
{
    public GameObject Board;
       // CHANGE NAME BOARDSCRIPT TO BOARD//
    private BoardScript BoardScriptRef;
    private AudioSource Source;
    public GameObject Companion;
    public GameObject AudioGameObj;
    public float HappinessSliderValue;
    private GameObject DotManagerObj;
    // Must cap at 4
    public int[] multiplier;

    public Slider HappinessSlider;
    string CompanionName;
    private DotManager DotManagerScript;
    public bool CanGetCurrency;
    bool CanEarnGold;
    // gets a companions name which loads their save
    public string CompanionSave;
    // Determines what multplier the player is on
    public int MultlpierNum;
    // Reset multplier for DEBUG purposes 
    public bool ResetTheMultlpier;
     [HideInInspector]
    public bool IsSleeping;
    
    string SaveStrings;
    public Animator Anim;

    public GameObject DayTime;
    public GameObject NightTime;
    public GameObject AwakeHead;
    // Use this for initialization
    void Start()
    {
        Board = GameObject.FindGameObjectWithTag("BoardSpawn");
        BoardScriptRef = Board.GetComponent<BoardScript>();
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        CompanionName = Companion.name;
        CanGetCurrency = false;
        // CompanionSounds = GetComponent<AudioClip[]>();
        Source = GetComponent<AudioSource>();

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
        
        if (CanEarnGold)
        {
            BoardScriptRef.Gold = 0;
        }
        else
        {
            BoardScriptRef.Gold = 1;
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
        // Slider value stops at -0.01 for somereason so -5 is to make sure it resets 
        if (HappinessSliderValue > -5 && HappinessSliderValue < 20)
        {
       
            // Animation 
            Anim.SetBool("<20", true);
            Anim.SetBool("is>33", false);
            Anim.SetBool("is>66", false);
            Anim.SetBool("is sleepy", false);
            NightTime.SetActive(false);
            DayTime.SetActive(true);
            AwakeHead.SetActive(true);
          
            //Changes the track in the SceneAudio script
            if (IsSleeping)
            {
                // plays wake up sound

                // Decreases multiplierNum
                MultlpierNum -= 1;
                PlayerPrefs.SetInt("Multiplier", MultlpierNum);
                AudioGameObj.GetComponent<SceneAudio>().PlayMusic();

            }
            // Adds multplier
            CanEarnGold = false;
            Multplier();

            //sets bool to false and saves
            IsSleeping = false;
            PlayerPrefs.SetInt(SaveStrings, (IsSleeping ? 1 : 0));
        }
        // if this is reached while not sleeping, companion changes animation
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
        // Goes to sleep
        else if (HappinessSliderValue > 95 && HappinessSliderValue < 100)
        {

            // Animation 
            Anim.SetBool("is sleepy", true);

            DayTime.SetActive(false);
            AwakeHead.SetActive(false);
            // Music Change
            if (!IsSleeping)
            {
                // increases multlpier number and saves it
                MultlpierNum += 1;
                PlayerPrefs.SetInt("Multiplier", MultlpierNum);
                //Changes the track in the SceneAudio script
                AudioGameObj.GetComponent<SceneAudio>().PlayMusic();

            }
            // Add multiplier    
            CanEarnGold = true;
            Multplier();
            NightTime.SetActive(true);
            //sets bool to false and saves
            PlayerPrefs.SetInt(SaveStrings, (IsSleeping ? 1 : 0));
            IsSleeping = true;
        }

    }

    void Sleeping()
    {
        // checks if Companion is sleeping
        if(IsSleeping)
        {
            NightTime.SetActive(true);

            Anim.SetBool("is>33", false);
           // AudioGameObj.GetComponent<SceneAudio>().Daymode = true;

            Anim.SetBool("is sleepy", true);
            AwakeHead.SetActive(false);
            CanEarnGold = true;
            MultlpierNum = PlayerPrefs.GetInt("Multiplier");
            DayTime.SetActive(false);
            AudioGameObj.GetComponent<SceneAudio>().Daymode = false;
            AudioGameObj.GetComponent<SceneAudio>().PlayMusic();
            PlayerPrefs.SetInt(AudioGameObj.GetComponent<SceneAudio>().MorningSave, (AudioGameObj.GetComponent<SceneAudio>().Daymode ? 1 : 0));

            Debug.Log("Sleeping");
        }
        else
        {
            NightTime.SetActive(false);

            CanEarnGold = false;
            MultlpierNum = PlayerPrefs.GetInt("Multiplier");
            DayTime.SetActive(true);
            Anim.SetBool("<20", true);
            AudioGameObj.GetComponent<SceneAudio>().Daymode = true;
            AudioGameObj.GetComponent<SceneAudio>().PlayMusic();
            PlayerPrefs.SetInt(AudioGameObj.GetComponent<SceneAudio>().MorningSave, (AudioGameObj.GetComponent<SceneAudio>().Daymode ? 1 : 0));

            Debug.Log("NotSleeping");

        }
    }
}
