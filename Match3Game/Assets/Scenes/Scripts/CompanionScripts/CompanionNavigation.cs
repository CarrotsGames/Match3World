using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// uses Realtime script to count down happiness
public class CompanionNavigation : MonoBehaviour
{
    private GameObject GameController;
    private LeaderBoardManager LeaderBoardManagerScript;

    private RealTimeCounter RealTimeScript;
    private GameObject RealTimerGameObj;
    // [HideInInspector]
    public string CompanionName;
    public int CompanionNumber;
    // Gets unlcoked companions in list
    public List<GameObject> Companions;
    private GameObject CompanionStorage;
    public int Navigate;
    public float[] Happiness;

    private Vector2 StartPos;
    private Vector2 SwipeDelta;

    private bool SwipeRight;
    private bool Swipeleft;
    private bool IsDragging;
    private HappinessManager HappinessManagerScript;
    private GameObject HappinessGameObj;

    public GameObject pageFlip;
    public GameObject backwardPageFlip;


    public Slider HappySlider;
     // Use this for initialization
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GC");
        LeaderBoardManagerScript = GameController.GetComponent<LeaderBoardManager>();
        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
        //  HappySlider.value = 0;

        RealTimerGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = RealTimerGameObj.GetComponent<RealTimeCounter>();
        CompanionStorage = GameObject.FindGameObjectWithTag("Creatures");
        // Adds all objects in gameobject to the Companions list 
        for (int i = 0; i < CompanionStorage.transform.childCount; i++)
        {
            Companions.Add(CompanionStorage.transform.GetChild(i).gameObject);
        }
        // sets the first avaialble companion to appear on screen(GOBU)
      //  Companions[0].SetActive(true);
      //  CompanionName = Companions[0].name;
        //CompanionSwitch();
    }
   
    // Assigns each Scene a button
    // Change that mooblings button number to the one assisgned eg 
    // Saucos button is 6 in script so it should be 6 in scene
    public void PlayLevel(int Level)
    {
        // each character button has assigned Level value which when pressed loads level
        switch (Level)
        {
            case 1:
                SceneManager.LoadScene("Gobu Level");
                break;
            case 2:
                SceneManager.LoadScene("Circle Scene");
                break;
            case 3:
                SceneManager.LoadScene("Triangle Scene");
                break;
            case 4:
                SceneManager.LoadScene("Royal Gobu Level 1");
                break;
            case 5:
                SceneManager.LoadScene("Crius");
                break;

            case 6:
                SceneManager.LoadScene("Sauco");
                break;
            case 7:
                SceneManager.LoadScene("Chick-Pee");
                break;
            case 8:
                SceneManager.LoadScene("Squishy");
                break;
            case 9:
                SceneManager.LoadScene("Cronus");
                break;
            case 10:
                SceneManager.LoadScene("Okami");
                break;
            case 11:
                SceneManager.LoadScene("Idasaurous");
                break;
            case 12:
                SceneManager.LoadScene("Snowball");
                break;
        }

    }
    //public void NavLeft()
    //{
    //    disable current companion
    //   Companions[Navigate].SetActive(false);
    //    if (Navigate == Companions.Count - 1)
    //    {
    //        go back to first companion in list
    //       Navigate = 0;
    //        activate new companion
    //        Companions[Navigate].SetActive(true);
    //        CompanionName = Companions[Navigate].name;

    //    }
    //    go to next companion in list
    //    else
    //    {
    //        Navigate += 1;
    //        Companions[Navigate].SetActive(true);
    //        CompanionName = Companions[Navigate].name;
    //        Navigation();
    //    }
    //    Reset();
    //    CompanionSwitch();

    //}
    //public void NavRight()
    //{

    //    if companions on right go right
    //    if (Navigate == 0)
    //    {

    //        Companions[Navigate].SetActive(false);
    //        Navigate = Companions.Count - 1;
    //        Companions[Navigate].SetActive(true);
    //        CompanionName = Companions[Navigate].name;
    //        Companions[Navigate].SetActive(true);
    //        Navigation();

    //    }
    //    else
    //    {
    //        Companions[Navigate].SetActive(false);

    //        Navigate -= 1;
    //        Companions[Navigate].SetActive(true);
    //        CompanionName = Companions[Navigate].name;
    //        Companions[Navigate].SetActive(true);
    //        Navigation();

    //    }
    //    Reset();
    //    CompanionSwitch();

    //}

    //Update is called once per frame
    //void CompanionSwitch()
    //{
    //    RealTimeScript.HappinessCountdowns();

    //    checks name of companion and displays how much happiness
    //    that specific companion has when highlited
    //    switch (CompanionName)
    //    {
    //        case "Gobu":
    //            Happiness[0] = PlayerPrefs.GetFloat("GobuHappiness");
    //            RealTimeScript.HappinessCountDown[0] = Happiness[0];
    //            HappinessManagerScript.HappinessSliderValue = RealTimeScript.HappinessCountDown[0];
    //            HappinessManagerScript.CompanionSave = "GobuHappiness";
    //            break;
    //        case "Binkie Locked":
    //            Happiness[1] = PlayerPrefs.GetFloat("BinkyHappiness");
    //            RealTimeScript.HappinessCountDown[1] = Happiness[1];
    //            HappinessManagerScript.HappinessSliderValue = RealTimeScript.HappinessCountDown[1];
    //            HappinessManagerScript.CompanionSave = "BinkyHappiness";

    //            break;
    //        case "Koko Locked":
    //            Happiness[2] = PlayerPrefs.GetFloat("KokoHappiness");
    //            HappinessManagerScript.Happiness = RealTimeScript.TimerCountDown2;
    //            RealTimeScript.HappinessCountDown[2] = Happiness[2];
    //            HappinessManagerScript.HappinessSliderValue = RealTimeScript.HappinessCountDown[2];
    //            HappinessManagerScript.CompanionSave = "KokoHappiness";

    //            break;
    //            shares happiness with Gobu
    //        case "Crius Locked":
    //            Happiness[3] = PlayerPrefs.GetFloat("CriusHappiness");
    //            RealTimeScript.HappinessCountDown[3] = Happiness[3];
    //            HappinessManagerScript.HappinessSliderValue = RealTimeScript.HappinessCountDown[3];
    //            HappinessManagerScript.CompanionSave = "CriusHappiness";

    //            break;

    //        case "Sauco Locked":
    //            Happiness[4] = PlayerPrefs.GetFloat("SaucoHappiness");
    //            RealTimeScript.HappinessCountDown[4] = Happiness[4];
    //            HappinessManagerScript.HappinessSliderValue = RealTimeScript.HappinessCountDown[4];
    //            HappinessManagerScript.CompanionSave = "SaucoHappiness";

    //            break;

    //        case "Chick-Pee Locked":
    //            Happiness[5] = PlayerPrefs.GetFloat("ChickPeaHappiness");
    //            RealTimeScript.HappinessCountDown[5] = Happiness[5];
    //            HappinessManagerScript.HappinessSliderValue = RealTimeScript.HappinessCountDown[5];
    //            HappinessManagerScript.CompanionSave = "ChickPeaHappiness";

    //            break;

    //        case "Squishy Locked":
    //            Happiness[6] = PlayerPrefs.GetFloat("SquishyHappiness");
    //            RealTimeScript.HappinessCountDown[6] = Happiness[6];
    //            HappinessManagerScript.HappinessSliderValue = RealTimeScript.HappinessCountDown[6];
    //            HappinessManagerScript.CompanionSave = "SquishyHappiness";

    //            break;
    //        case "Cronus Locked":
    //            Happiness[7] = PlayerPrefs.GetFloat("CronosHappiness");
    //            RealTimeScript.HappinessCountDown[7] = Happiness[7];
    //            HappinessManagerScript.HappinessSliderValue = RealTimeScript.HappinessCountDown[7];
    //            HappinessManagerScript.CompanionSave = "CronosHappiness";

    //            break;
    //        case "Okami Locked":
    //            Happiness[8] = PlayerPrefs.GetFloat("OkamiHappiness");
    //            RealTimeScript.HappinessCountDown[8] = Happiness[8];
    //            HappinessManagerScript.HappinessSliderValue = RealTimeScript.HappinessCountDown[8];
    //            HappinessManagerScript.CompanionSave = "OkamiHappiness";

    //            break;
    //        case "Idasaurous":
    //            Happiness[9] = PlayerPrefs.GetFloat("IdaHappiness");
    //            RealTimeScript.HappinessCountDown[9] = Happiness[9];
    //            HappinessManagerScript.HappinessSliderValue = RealTimeScript.HappinessCountDown[9];
    //            HappinessManagerScript.CompanionSave = "IdaHappiness";

    //            break;
    //    }
    //    RealTimeScript.LoadCompanionHappiness();

    //}






}