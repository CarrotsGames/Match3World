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
             HappinessManagerScript.Happiness = RealTimeScript.TimerCountDown1;
        }
        else if (CreatureSelectScript.middleCreature)
        {
            HappinessManagerScript.Happiness = RealTimeScript.TimerCountDown;
        }
        else if(CreatureSelectScript.leftCreature)
        {
            HappinessManagerScript.Happiness = RealTimeScript.TimerCountDown2;
        }

    }
}
