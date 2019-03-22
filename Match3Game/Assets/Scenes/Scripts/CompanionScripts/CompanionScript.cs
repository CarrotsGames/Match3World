using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
public class CompanionScript : MonoBehaviour
{
    public List<GameObject> EatingPeices;
    // Use this for initialization
    public GameObject EatingPeiceSpawner; 
 
    
    // max it can go to is 10
    public float[] GrowingSizes;

    public Slider HungerSlider;
    public AudioSource Audio;


    private GameObject DotManagerObj;
    private GameObject RealTimerGameObj;
    private GameObject PowerUpManGameObj;
    private GameObject HappinessGameObj;
    private DotManagerScript dotManagerScript;
    private RealTimeCounter RealTimeScript;
    private PowerUpManager PowerUpManagerScript;
    private HappinessManager HappinessManagerScript;
    // Update is called once per frame
    private int posX;
    private int posY;
    private int HungerMultiplier = 1;
    private int CurrencyChance;
    private void Start()
    {
        Audio = GetComponent<AudioSource>();
        // References the Realtimescript which is located on camera (TEMP)
        RealTimerGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = RealTimerGameObj.GetComponent<RealTimeCounter>();

        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
      
        // Referneces DotManagerScript
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        // HungerSlider min and max
        HungerSlider.maxValue = 99;
        HungerSlider.minValue = 0f;
    }

 
    public void FeedMonster()
    {
        
        // transforms the peices to the eatingspawner position
        for (int i = 0; i < EatingPeices.Count; i++)
        {
         
             EatingPeices[i].transform.position = EatingPeiceSpawner.transform.position + new Vector3(posX, posY, 0);
             CurrencyChance = HungerMultiplier;
            Destroy(EatingPeices[i].gameObject);
            HungerMultiplier = i / 2;
            HappinessManagerScript.Happiness += HungerMultiplier;

        }
        if (HappinessManagerScript.CanGetCurrency)
        {
            int chance = Random.Range(CurrencyChance, 100);
            if (chance >= 90)
            {
                PowerUpManagerScript.Currency += 1;
            }
            Debug.Log(chance);
            //  dotManagerScript.Currency 
        }
        dotManagerScript.HighScore.text = "" + dotManagerScript.TotalScore;
        Audio.Play();
    }
// when the pieces collide with the companion it will destory them
 
    //when game closes save the current hugner and start counting down outside of the app
    private void OnApplicationPause(bool pause)
    {
        RealTimeScript.ResetClock();
        pause = true;
    }
    private void OnApplicationQuit()
    {
        RealTimeScript.ResetClock();
    }
}
