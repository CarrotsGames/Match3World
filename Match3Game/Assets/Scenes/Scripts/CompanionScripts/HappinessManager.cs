using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HappinessManager : MonoBehaviour
{    //TODO
    // CHANGE NAME BOARDSCRIPT TO BOARD//

    private BoardScript BoardScriptRef;
    public GameObject Board;
    public GameObject Companion;
    public GameObject AudioGameObj;
    public Image FillColour;

    public Slider HappinessSlider;

    public float HappinessSliderValue;
    // gets a companions name which loads their save
    public string CompanionSave;

    public bool CanGetCurrency;
    // Reset multplier for DEBUG purposes 
    public bool IsSleeping;   
    public Animator Anim;
    public GameObject DayTime;
    public GameObject NightTime;
    public GameObject AwakeHead;
    // Plays ad when sleeping
    private GameObject SleepAd;
    private PlayLevelAd PlayLevelAdScript;
    string SceneName;
    string CompanionName;
    private GameObject RealTimeGameObj;
    [HideInInspector]
    public RealTimeCounter RealtTimeScript;
    [HideInInspector]
    public bool OnMainScene;
    bool CanEarnGold;
    [HideInInspector]
    public string SaveStrings;
    // Use this for initialization
    void Start()
    {
        //checks if players in main scene
        // if they are then the happinessStates void wont be called to avoid mixing saves
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneName = CurrentScene.name;
        SleepAd = GameObject.FindGameObjectWithTag("SleepingAd");
        if (SceneName == "Main Screen")
        {
            OnMainScene = true;
        }
        else
        {
            PlayLevelAdScript = SleepAd.GetComponent<PlayLevelAd>();
        }
        Board = GameObject.FindGameObjectWithTag("BoardSpawn");

        if (SceneName != "Gobu Tutorial")
        {
            BoardScriptRef = Board.GetComponent<BoardScript>();
        }
        CompanionName = Companion.name;
        CanGetCurrency = false;
        // CompanionSounds = GetComponent<AudioClip[]>();
        RealTimeGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealtTimeScript = RealTimeGameObj.GetComponent<RealTimeCounter>();
        // Gets the last known bool for this companion
        IsSleeping = (PlayerPrefs.GetInt(SaveStrings) != 0);
        LoadCompanionSaves();
        
        // Gets the last known bool for this companion
        IsSleeping = (PlayerPrefs.GetInt(SaveStrings) != 0);
        // checks if bool puts companion to sleep
        Sleeping();
        HappinessSlider.maxValue = 99;
        HappinessSlider.minValue = 0f;
       
    }
    void LoadCompanionSaves()
    {
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
            case "Sauco":
                CompanionSave = "SaucoHappiness";
                SaveStrings = "SAUCOSAVE";
                break;
            case "Chick-Pee":
                CompanionSave = "ChickPeaHappiness";
                SaveStrings = "CHICKPEASAVE";
                break;
            case "Squishy":
                CompanionSave = "SquishyHappiness";
                SaveStrings = "SQUISHYSAVE";
                break;
            case "Cronus":
                CompanionSave = "CronosHappiness";
                SaveStrings = "CRONOSSAVE";
                break;
            case "Okami":
                CompanionSave = "OkamiHappiness";
                SaveStrings = "OKAMISAVE";
                break;
        }
     RealtTimeScript.LoadCompanionHappiness();
    }

    // Update is called once per frame
    void Update()
    {
         if (!OnMainScene)
        {
            HappinessStates();
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
        if (SceneName != "Gobu Tutorial")
        {
            if (CanEarnGold)
            {
                BoardScriptRef.Gold = 0;
            }
            else
            {
                BoardScriptRef.Gold = 1;
            }
        }
         
    }
    // Plays animation at happiness states
    void HappinessStates()
    {
        // Slider value stops at -0.01 for somereason so -5 is to make sure it resets 
        if (HappinessSliderValue > -5 && HappinessSliderValue < 20)
        {
            FillColour.color = Color.yellow;

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
                //Sleeping();
                 PlayerPrefs.SetInt("Multiplier", this.gameObject.GetComponent<HappyMultlpier>().MultlpierNum);
                AudioGameObj.GetComponent<SceneAudio>().CompanionSound.PlayOneShot
                (AudioGameObj.GetComponent<SceneAudio>().WakeUpSound[0]);
                 AudioGameObj.GetComponent<SceneAudio>().PlayMusic();

            }
            // Adds multplier
            CanEarnGold = false;
            this.gameObject.GetComponent<HappyMultlpier>().Multplier();

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
            FillColour.color = Color.green;
             // Animation 
            Anim.SetBool("is sleepy", true);
            if (!IsSleeping)
            {
              //  Sleeping();

                AudioGameObj.GetComponent<SceneAudio>().Daymode = false;
                AudioGameObj.GetComponent<SceneAudio>().PlayMusic();
                IsSleeping = true;
                //sets bool to false and saves
                PlayerPrefs.SetInt(SaveStrings, (IsSleeping ? 1 : 0));
                PlayLevelAdScript.PlayAdNow();
            }
            DayTime.SetActive(false);
            AwakeHead.SetActive(false);
            // Music Change
            // Add multiplier    
            CanEarnGold = true;
            NightTime.SetActive(true);
       
         }

    }
    // Checks if companion is sleeping on startUp
    void Sleeping()
    {
        // checks if Companion is sleeping
        if(IsSleeping)
        {
            NightTime.SetActive(true);
            FillColour.color = Color.green;

            Anim.SetBool("is>33", false);
           // AudioGameObj.GetComponent<SceneAudio>().Daymode = true;

            Anim.SetBool("is sleepy", true);
            AwakeHead.SetActive(false);
            CanEarnGold = true;
            this.gameObject.GetComponent<HappyMultlpier>().MultlpierNum = PlayerPrefs.GetInt("Multiplier");
            DayTime.SetActive(false);
       
             AudioGameObj.GetComponent<SceneAudio>().PlayMusic();
            PlayerPrefs.SetInt(AudioGameObj.GetComponent<SceneAudio>().MorningSave, (AudioGameObj.GetComponent<SceneAudio>().Daymode ? 1 : 0));
         }
        else
        {
            NightTime.SetActive(false);
            FillColour.color = Color.yellow;

            CanEarnGold = false;
            GetComponent<HappyMultlpier>().MultlpierNum = PlayerPrefs.GetInt("Multiplier");
            DayTime.SetActive(true);
            Anim.SetBool("<20", true);
            AudioGameObj.GetComponent<SceneAudio>().Daymode = true;
             AudioGameObj.GetComponent<SceneAudio>().PlayMusic();
            PlayerPrefs.SetInt(AudioGameObj.GetComponent<SceneAudio>().MorningSave, (AudioGameObj.GetComponent<SceneAudio>().Daymode ? 1 : 0));

 
        }
    }
  
}
