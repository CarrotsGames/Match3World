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
   // public GameObject NightTime;
    public GameObject AwakeHead;
    // Plays ad when sleeping
    private GameObject SleepAd;
    private PlayLevelAd PlayLevelAdScript;
    public int Level;
    string SceneName;
     private GameObject RealTimeGameObj;
    [HideInInspector]
    public RealTimeCounter RealtTimeScript;
    [HideInInspector]
    public bool OnMainScene;
    bool CanEarnGold;
    [HideInInspector]
    public string SaveStrings;
    public Text LevelText;
    [SerializeField]
    private int HappinessClamp;
    public GameObject SliderGameObj;
    public Text CurrentHappiness;
 
    // Use this for initialization
    void Start()
    {
        //checks if players in main scene
        // if they are then the happinessStates void wont be called to avoid mixing saves
        Scene CurrentScene = SceneManager.GetActiveScene();
        // Gets current scene
        SceneName = CurrentScene.name;
        Level = PlayerPrefs.GetInt(Companion.name + "Multiplier", Level);
        SleepAd = GameObject.FindGameObjectWithTag("SleepingAd");
        // If for somereason level is 0 make it 1
        // this is used as a safety net just incase for somereason its 0
        // if level is 0 score will not go up because nodes * level value equal score
        if(Level == 0)
        {
            Level = 1;
        }
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
        
        //HappinessClamp = 100;
        HappinessClamp += Level * 250;
        LevelText.text = "" + Level;
        // Gets companions current level
        CompanionSave = Companion.name + "Value";
        HappinessSliderValue = PlayerPrefs.GetFloat(CompanionSave);
     
   
      
        Board = GameObject.FindGameObjectWithTag("BoardSpawn");

        if (SceneName != "Gobu Tutorial")
        {
            BoardScriptRef = Board.GetComponent<BoardScript>();
        }
        HappinessBar();
        HappinessSlider.value = HappinessSliderValue;

    }

    public void HappinessBar()
    {
        LevelText.text = "Level:" + Level;
        CurrentHappiness.text = "Current EXP:" + HappinessSliderValue + "/" + HappinessClamp;
        if (!OnMainScene)
        {
            HappinessStates();
        }
        // Displays hunger value (used in debug)
        //HungerMetre.text = "" + Hunger;
        HappinessSlider.value = HappinessSliderValue;

        // clamps hunger of selected companion from 0 to 100
        HappinessSliderValue = Mathf.Clamp(HappinessSliderValue, 0, HappinessClamp);
        // Slowly counts down Happiness value
        //HappinessSliderValue -= Time.deltaTime / 6;
        HappinessSlider.maxValue = HappinessClamp;

        PlayerPrefs.SetFloat(CompanionSave, HappinessSliderValue);
    }
    // Plays animation at happiness states
    void HappinessStates()
    {
        if (Level < 25)
        { 
            //displays current slider information with currently used companion
            HappinessSlider.value = HappinessSliderValue;
            // Slider value stops at -0.01 for somereason so -5 is to make sure it resets 
            if (HappinessSliderValue > -5 && HappinessSliderValue < HappinessClamp / 9)
            {

                Anim.SetBool("<20", true);
                Anim.SetBool("is>33", false);
                Anim.SetBool("is>66", false);
                Anim.SetBool("is sleepy", false);
                // SliderGameObj.GetComponent<SliderTest>().slider[9].SetActive(false);
                // SliderGameObj.GetComponent<SliderTest>().slider[0].SetActive(true);

            }
            else if (HappinessSliderValue > HappinessClamp / 9 && HappinessSliderValue < HappinessClamp / 8)
            {
                //  SliderGameObj.GetComponent<SliderTest>().slider[0].SetActive(false);
                //  SliderGameObj.GetComponent<SliderTest>().slider[1].SetActive(true);
            }
            // if this is between HappyClamp / 4 && happyclamp / 4
            // if this is reached while not sleeping, companion changes animation
            else if (HappinessSliderValue > HappinessClamp / 8 && HappinessSliderValue < HappinessClamp / 7)
            {
                // Animation 
                Anim.SetBool("is>33", true);
                Anim.SetBool("<20", false);
                Anim.SetBool("is>66", false);
                //  SliderGameObj.GetComponent<SliderTest>().slider[1].SetActive(false);
                //  SliderGameObj.GetComponent<SliderTest>().slider[2].SetActive(true);
            }
            else if (HappinessSliderValue > HappinessClamp / 7 && HappinessSliderValue < HappinessClamp / 6)
            {
                // Animation 
                Anim.SetBool("is>33", false);
                Anim.SetBool("<20", false);
                Anim.SetBool("is>66", true);
                //   SliderGameObj.GetComponent<SliderTest>().slider[2].SetActive(false);
                //   SliderGameObj.GetComponent<SliderTest>().slider[3].SetActive(true);

            }
            else if (HappinessSliderValue > HappinessClamp / 6 && HappinessSliderValue < HappinessClamp / 5)
            {
                // Animation 
                Anim.SetBool("is>33", false);
                Anim.SetBool("<20", false);
                Anim.SetBool("is>66", true);
                // SliderGameObj.GetComponent<SliderTest>().slider[3].SetActive(false);
                // SliderGameObj.GetComponent<SliderTest>().slider[4].SetActive(true);

            }
            else if (HappinessSliderValue > HappinessClamp / 5 && HappinessSliderValue < HappinessClamp / 4)
            {
                // Animation 
                Anim.SetBool("is>33", false);
                Anim.SetBool("<20", false);
                Anim.SetBool("is>66", true);
                //  SliderGameObj.GetComponent<SliderTest>().slider[4].SetActive(false);
                //  SliderGameObj.GetComponent<SliderTest>().slider[5].SetActive(true);

            }
            else if (HappinessSliderValue > HappinessClamp / 4 && HappinessSliderValue < HappinessClamp / 3)
            {
                // Animation 
                Anim.SetBool("is>33", false);
                Anim.SetBool("<20", false);
                Anim.SetBool("is>66", true);
                //  SliderGameObj.GetComponent<SliderTest>().slider[5].SetActive(false);
                //  SliderGameObj.GetComponent<SliderTest>().slider[6].SetActive(true);

            }
            else if (HappinessSliderValue > HappinessClamp / 3 && HappinessSliderValue < HappinessClamp / 2)
            {
                // Animation 
                Anim.SetBool("is>33", false);
                Anim.SetBool("<20", false);
                Anim.SetBool("is>66", true);
                // SliderGameObj.GetComponent<SliderTest>().slider[6].SetActive(false);
                // SliderGameObj.GetComponent<SliderTest>().slider[7].SetActive(true);


            }
            else if (HappinessSliderValue > HappinessClamp / 2 && HappinessSliderValue < HappinessClamp)
            {
                // SliderGameObj.GetComponent<SliderTest>().slider[7].SetActive(false);
                //  SliderGameObj.GetComponent<SliderTest>().slider[8].SetActive(true);
            }
            else if (HappinessSliderValue > HappinessClamp)
            {
                //  SliderGameObj.GetComponent<SliderTest>().slider[8].SetActive(false);
                //  SliderGameObj.GetComponent<SliderTest>().slider[9].SetActive(true);


                FillColour.color = Color.green;
                // Animation 
                Anim.SetBool("is sleepy", true);
                //  PlayerPrefs.SetInt(SaveStrings, (IsSleeping ? 1 : 0));
                PlayLevelAdScript.PlayAdNow();
                Level = PlayerPrefs.GetInt(Companion.name + "Multiplier", Level);
                Level++;
                PlayerPrefs.SetInt(Companion.name + "Multiplier", Level);
                CanGetCurrency = true;

                // Music Change
                // Add multiplier    
                HappinessSliderValue = 0;
                //  NightTime.SetActive(true);
                HappinessClamp = 0;
                HappinessClamp += Level * 250;
            }
        }
        else
        {
            Debug.Log("MAXLEVEL REACHED");
        }
    }
  
}
