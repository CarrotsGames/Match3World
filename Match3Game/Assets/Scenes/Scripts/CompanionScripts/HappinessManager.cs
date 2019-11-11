using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HappinessManager : MonoBehaviour
{   
  
    public float HappinessSliderValue;
    [HideInInspector]
    public RealTimeCounter RealtTimeScript;
    [HideInInspector]
    public bool OnMainScene;
    public bool CanGetCurrency;
    public bool IsSleeping;   
    [HideInInspector]
    public int HappinessClamp;
    public int Level;
    [HideInInspector]
    public string SaveStrings;
    // gets a companions name which loads their save
    public string CompanionSave;
    // Unlocks challenges for this mooblings challenge scene
    [Header("Put challenge scene name here to unlock challenges")]
    public string MooblingChallengeSave;
    private int TimeTillSave;
    private bool CanEarnGold;
    private string SceneName;
  
    //Unity releated stuff
    public GameObject Board;
    public GameObject Companion;
    public GameObject AudioGameObj;
    public GameObject DayTime;
    public Text LevelText;
    public Text NextLevel;
    public Text CurrentMultiplier;
    public Text CurrentHappiness;
    public Text GoldRewardText;
    public Image FillColour;
    public Slider HappinessSlider;    
    public Animator Anim;

    // Plays ads
    private GameObject LevelUpCanvasGameObj;
    private LevelUpCanvas LevelUpCanvasScript;
    private GameObject SleepAd;
    private GameObject RealTimeGameObj;
    private GameObject PowerUpManagerGameObj;
    private PlayLevelAd PlayLevelAdScript; 
    private BoardScript BoardScriptRef;
    private PowerUpManager PowerUpManagerScript;
    private List<int> GoldRewardList;

    // Use this for initialization
    void Awake()
    {      
        // if they are then the happinessStates void wont be called to avoid mixing saves
        Scene CurrentScene = SceneManager.GetActiveScene();
        // Gets current scene
        SceneName = CurrentScene.name;
   
        SleepAd = GameObject.FindGameObjectWithTag("SleepingAd");
 
        PowerUpManagerGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManagerGameObj.GetComponent<PowerUpManager>();
        //checks if players in main scene
        if (SceneName == "Main Screen" || SceneName == "Main Screen Tut") 
        {
            OnMainScene = true;
        }
        else
        {
            LevelUpCanvasGameObj = GameObject.Find("Level Up Canvus");
            LevelUpCanvasScript = LevelUpCanvasGameObj.GetComponent<LevelUpCanvas>();
            AssignGold();
            PlayLevelAdScript = SleepAd.GetComponent<PlayLevelAd>();
        }
        
        // Gets companions current level
        CompanionSave = Companion.name + "Value";
          
        Board = GameObject.FindGameObjectWithTag("BoardSpawn");

        if (SceneName != "Gobu Tutorial")
        {
            BoardScriptRef = Board.GetComponent<BoardScript>();
        }
        LoadSaves();
        // this is used as a safety net just incase for somereason its 0
        if (Level > 1)
        {
            CanGetCurrency = true;
        }
        if (SceneName == "Gobu Tut")
        {

            Level = 1;
            HappinessSliderValue = 0;
            HappinessClamp = 249;
            HappinessBar();
        }

        int NextLevelNum = Level + 1;
        NextLevel.text = " " + NextLevelNum;
        LevelText.text = "" + Level;
        CurrentMultiplier.text = "" + Level;
    
    }
   
    void LoadSaves()
    {
        if (GameObject.Find("CHALLENGE") == null)
        {         
           
            SaveSystem.LoadMoobling();
            if (!SaveSystem.NewSave)
            {
                Level = SaveSystem.LoadMoobling().Level;
                HappinessSliderValue = SaveSystem.LoadMoobling().EXP;
            }
            else
            {
                Level = 1;
                SaveSystem.NewSave = false;
            }
            HappinessClamp = Level * 250;
            //HappinessClamp = SaveSystem.LoadMoobling().TotalEXP;
            // DotManager.TotalScore = SaveSystem.LoadMoobling().TotalScore;
            HappinessBar();
 
        }
        HappinessSlider.maxValue = HappinessClamp;
        HappinessSliderValue = Mathf.Clamp(HappinessSliderValue, 0, HappinessClamp);
        HappinessSlider.value = HappinessSliderValue;
    }
    void AssignGold()
    {
        GoldRewardList = new List<int>() ;
        for (int i = 0; i < 25; i++)
        {
            
            if (i <= 20)
            {
                GoldRewardList.Add(5); 
            }
            else
            {
                GoldRewardList.Add(20);
            }
        }
    }
    public void HappinessBar()
    {
             
        CurrentHappiness.text = "Current EXP:" + HappinessSliderValue + "/" + HappinessClamp;
        if (!OnMainScene)
        {
            HappinessStates();
        }
        // Displays hunger value (used in debug)   
        HappinessSlider.maxValue = HappinessClamp;
        HappinessSlider.value = HappinessSliderValue;

        // clamps hunger of selected companion from 0 to 100
        HappinessSliderValue = Mathf.Clamp(HappinessSliderValue, 0, HappinessClamp);
        // Slowly counts down Happiness value
    
         
     
    }
    // Plays animation at happiness states
    void HappinessStates()
    {
        if (Level < 25)
        {
            if (HappinessSliderValue > HappinessClamp)
            {
                FillColour.color = Color.green;
                // Animation 
 
                //  PlayerPrefs.SetInt(SaveStrings, (IsSleeping ? 1 : 0));
                // Level = PlayerPrefs.GetInt(Companion.name + "Multiplier", Level);
                Level++;
                PlayerPrefs.SetInt(Companion.name + "Multiplier", Level);
                CanGetCurrency = true;
                if (Level == 5 || Level == 10 || Level == 15 || Level == 20 || Level == 25)
                {
                    PlayLevelAdScript.PlayAdNow();
                }
                // Music Change
                // Add multiplier    
                HappinessSliderValue = 0;
                //  NightTime.SetActive(true);
                HappinessClamp = 0;
                HappinessClamp += Level * 250;
                // sets the level to new level
                LevelText.text = " " + Level;
                int NextLevelNum = Level + 1;
                NextLevel.text = " " + NextLevelNum;
                CurrentMultiplier.text = "" + Level;
                // sets current exp
                CurrentHappiness.text = "Current EXP:" + HappinessSliderValue + "/" + HappinessClamp;
                PowerUpManagerScript.Currency += GoldRewardList[Level];
                PowerUpManagerScript.PowerUpSaves();

                if (Level >= 5)
                {
                    // Adds challenge to this mooblings challenges
                    int ChallengeUnlocked = 5;
                    ChallengeUnlocked += PlayerPrefs.GetInt(MooblingChallengeSave);
                    ChallengeUnlocked++;
                    PlayerPrefs.SetInt(MooblingChallengeSave, ChallengeUnlocked);
                }
                else
                {
                    int ChallengeUnlocked = PlayerPrefs.GetInt(MooblingChallengeSave);
                    ChallengeUnlocked++;
                    PlayerPrefs.SetInt(MooblingChallengeSave, ChallengeUnlocked);

                }
                GoldRewardText.text = "" + GoldRewardList[Level];
                LevelUpCanvasGameObj = GameObject.Find("Level Up Canvus");
                LevelUpCanvasScript = LevelUpCanvasGameObj.GetComponent<LevelUpCanvas>();
                LevelUpCanvasScript.TurnOnCanvas();
                
            }
        }
        else
        {
            Debug.Log("MAXLEVEL REACHED");
        }
    }

 
    public void SaveMe()
    {
        SaveSystem.SaveMoobling(this);
    }
    private void OnApplicationPause(bool pause)
    {
        PlayerPrefs.SetFloat("AdTimer", 600);
        SaveMe();        
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("AdTimer", 600);
       // SaveMe();
    }
}
