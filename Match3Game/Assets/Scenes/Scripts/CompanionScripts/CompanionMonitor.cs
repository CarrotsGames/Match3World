using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    CreatureSelect CreatureSelectScript;
 
    // Use this for initialization
    void Start()
    {
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
        MouseTrail.SetActive(false);
        if (CreatureSelectScript.rightCreature)
        {
            Happiness1 = PlayerPrefs.GetFloat("BinkyHappiness");
            RealTimeScript.TimerCountDown1 = Happiness1;
            HappySlider.value = Happiness1;
        }
        else if (CreatureSelectScript.middleCreature)
        {
            Happiness = PlayerPrefs.GetFloat("GobuHappiness");

            //HappinessManagerScript.Happiness = RealTimeScript.TimerCountDown;
            RealTimeScript.TimerCountDown = Happiness;
            HappySlider.value = Happiness;

        }
        else if(CreatureSelectScript.leftCreature)
        {
            Happiness2 = PlayerPrefs.GetFloat("KokoHappiness");

            //HappinessManagerScript.Happiness = RealTimeScript.TimerCountDown2;
            RealTimeScript.TimerCountDown2 = Happiness2;
            HappySlider.value = Happiness2;

        }

    }
}
