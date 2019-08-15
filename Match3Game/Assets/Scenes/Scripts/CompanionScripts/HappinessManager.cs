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
    public int Level;
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
    public Text LevelText;

    // Use this for initialization
    void Start()
    {
        //checks if players in main scene
        // if they are then the happinessStates void wont be called to avoid mixing saves
        Scene CurrentScene = SceneManager.GetActiveScene();
        Level = PlayerPrefs.GetInt(Companion.name + "Multiplier", Level);
        LevelText.text = "" + Level;
        // Gets companions current level
        CompanionSave = Companion.name + "Value";
        HappinessSliderValue = PlayerPrefs.GetFloat(CompanionSave);
     
        // Gets current scene
        SceneName = CurrentScene.name;
        SleepAd = GameObject.FindGameObjectWithTag("SleepingAd");

        if (SceneName == "Main Screen" || SceneName == "Gobu Tutorial")
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
 
        HappinessSlider.maxValue = 99;
        HappinessSlider.minValue = 0f;
       
    }
    
    // Update is called once per frame
    void Update()
    {
        LevelText.text = "Level:" + Level;

 
        if (!OnMainScene)
        {
            HappinessStates();
        }
        // Displays hunger value (used in debug)
        //HungerMetre.text = "" + Hunger;

        // clamps hunger of selected companion from 0 to 100
        HappinessSliderValue = Mathf.Clamp(HappinessSliderValue, 0, 100);
        // Slowly counts down Happiness value
        //HappinessSliderValue -= Time.deltaTime / 6;
       
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
          //  PlayerPrefs.SetInt(SaveStrings, (IsSleeping ? 1 : 0));
            PlayLevelAdScript.PlayAdNow();
            Level = PlayerPrefs.GetInt(Companion.name + "Multiplier", Level);
            Level++;
            PlayerPrefs.SetInt(Companion.name +  "Multiplier", Level);

            // Music Change
            // Add multiplier    
            CanEarnGold = true;
            HappinessSliderValue = 0;
          //  NightTime.SetActive(true);
       
         }

    }
  
}
