using UnityEngine;
using System.Collections;
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
    
    private int TimeTillSave;
    private bool CanEarnGold;
    private string SceneName;
  
    //Unity releated stuff
    public GameObject Board;
    public GameObject Companion;
    public GameObject AudioGameObj;
    public GameObject DayTime;
    public GameObject LevelUpCanvas;
    public Text LevelText;
    public Text NextLevel;
    public Text CurrentMultiplier;
    public Text CurrentHappiness;
    public Image FillColour;
    public Slider HappinessSlider;    
    public Animator Anim;
   
    // Plays ad when sleeping
    private GameObject SleepAd;
    private GameObject RealTimeGameObj;
    private PlayLevelAd PlayLevelAdScript; 
    private BoardScript BoardScriptRef;


    // Use this for initialization
    void Start()
    {
        //checks if players in main scene
        // if they are then the happinessStates void wont be called to avoid mixing saves
        Scene CurrentScene = SceneManager.GetActiveScene();
        // Gets current scene
        SceneName = CurrentScene.name;
      
        SleepAd = GameObject.FindGameObjectWithTag("SleepingAd");
        // If for somereason level is 0 make it 1
        // this is used as a safety net just incase for somereason its 0
    
        if(Level > 1)
        {
            CanGetCurrency = true;
        }
        if (SceneName == "Main Screen" || SceneName == "Gobu Tutorial")
        {
            OnMainScene = true;
        }
        else
        {
            PlayLevelAdScript = SleepAd.GetComponent<PlayLevelAd>();
        }
        
   
        // Gets companions current level
        CompanionSave = Companion.name + "Value";
          
        Board = GameObject.FindGameObjectWithTag("BoardSpawn");

        if (SceneName != "Gobu Tutorial")
        {
            BoardScriptRef = Board.GetComponent<BoardScript>();
        }   // clamps hunger of selected companion from 0 to 100
        // Slowly counts down Happiness value
        //HappinessSliderValue -= Time.deltaTime / 6;
        if (GameObject.Find("CHALLENGE") == null )
        {
            SaveSystem.LoadMoobling();
            Level = SaveSystem.LoadMoobling().Level;
            HappinessSliderValue = SaveSystem.LoadMoobling().EXP;
            HappinessClamp += Level * 250;
            HappinessClamp = SaveSystem.LoadMoobling().TotalEXP;
           // DotManager.TotalScore = SaveSystem.LoadMoobling().TotalScore;
            HappinessBar();     
            LevelUpCanvas.SetActive(false);
        }
        HappinessSlider.maxValue = HappinessClamp;
        HappinessSliderValue = Mathf.Clamp(HappinessSliderValue, 0, HappinessClamp);
        HappinessSlider.value = HappinessSliderValue;
        //HappinessSlider.value = HappinessSliderValue;
        // if level is 0 score will not go up because nodes * level value equal score
        if (Level == 0)
        {
            Level = 1;
        }
        int NextLevelNum = Level + 1;
        NextLevel.text = " " + NextLevelNum;
        //HappinessClamp = 100;
        LevelText.text = "" + Level;
        CurrentMultiplier.text = "" + Level;
     
        if(CompanionSave == "TutorialGobuValue")
        {
            Level = 2;
            HappinessSliderValue = 0;
            HappinessClamp += 250;
            HappinessBar();

        }
    }

  
    public void HappinessBar()
    {
             
        CurrentHappiness.text = "Current EXP:" + HappinessSliderValue + "/" + HappinessClamp;
        if (!OnMainScene)
        {
            HappinessStates();
          //  PlayerPrefs.SetInt(Companion.name + "Multiplier", Level);
        }
        // Displays hunger value (used in debug)
        //HungerMetre.text = "" + Hunger;
        HappinessSlider.value = HappinessSliderValue;

        // clamps hunger of selected companion from 0 to 100
        HappinessSliderValue = Mathf.Clamp(HappinessSliderValue, 0, HappinessClamp);
        // Slowly counts down Happiness value
        //HappinessSliderValue -= Time.deltaTime / 6;
        HappinessSlider.maxValue = HappinessClamp;

      //  PlayerPrefs.SetFloat(CompanionSave, HappinessSliderValue);
         
     
    }
    // Plays animation at happiness states
    void HappinessStates()
    {
        if (Level < 25)
        {
            if (HappinessSliderValue > HappinessClamp)
            {

                LevelUpCanvas.SetActive(true);
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
