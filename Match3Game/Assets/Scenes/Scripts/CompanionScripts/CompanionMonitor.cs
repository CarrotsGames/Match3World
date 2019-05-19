using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// OBSOLETE SCRIPT 
//USED IN MAIN SCENE TO CHECK COMPANION STATS
public class CompanionMonitor : MonoBehaviour
{
    private RealTimeCounter RealTimeScript;
    public GameObject MouseTrail;
    private GameObject RealTimerGameObj;
    public Slider HappySlider;
    private HappinessManager HappinessManagerScript;
    private GameObject HappinessGameObj;
    private GameObject CreatureSelectGameObj;
    float Happiness;
    float Happiness1;
    float Happiness2;
    float Happiness3;

    CreatureSelect CreatureSelectScript;
 
    // Use this for initialization
    void Start()
    {
        HappySlider.value = 0;
        RealTimerGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = RealTimerGameObj.GetComponent<RealTimeCounter>();
        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
        CreatureSelectGameObj = GameObject.FindGameObjectWithTag("GC");
        CreatureSelectScript = CreatureSelectGameObj.GetComponent<CreatureSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        // Displays specific Creatures happiness on the main scene 
        // with a slider bar
         if (CreatureSelectScript.rightCreature)
        {
            Happiness1 = PlayerPrefs.GetFloat("BinkyHappiness");
            RealTimeScript.HappinessCountDown[1] = Happiness1;
            HappySlider.value = RealTimeScript.HappinessCountDown[1];
        }
        else if (CreatureSelectScript.middleCreature)
        {
            Happiness = PlayerPrefs.GetFloat("GobuHappiness");

            //HappinessManagerScript.Happiness = RealTimeScript.TimerCountDown;
            RealTimeScript.HappinessCountDown[0] = Happiness;
            HappySlider.value = RealTimeScript.HappinessCountDown[0];

        }
        else if(CreatureSelectScript.leftCreature)
        {
            Happiness2 = PlayerPrefs.GetFloat("KokoHappiness");

            //HappinessManagerScript.Happiness = RealTimeScript.TimerCountDown2;
            RealTimeScript.HappinessCountDown[2] = Happiness2;
            HappySlider.value = RealTimeScript.HappinessCountDown[2];

        }
        else if (CreatureSelectScript.leftCreature)
        {
            Happiness3 = PlayerPrefs.GetFloat("CriusHappiness");

            //HappinessManagerScript.Happiness = RealTimeScript.TimerCountDown2;
            RealTimeScript.HappinessCountDown[3] = Happiness3;
            HappySlider.value = RealTimeScript.HappinessCountDown[3];

        }
        MouseTrail.SetActive(false);

    }
}
