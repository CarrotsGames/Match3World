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
    // Must cap at 4
    public int[] multiplier;
    
    // max it can go to is 10
    public float[] GrowingSizes;
    public float Happiness;
    public Text HungerMetre;

    public Slider HungerSlider;
    public AudioSource Audio;

    private bool CanGetCurrency;

    private DotManagerScript dotManagerScript;
    private GameObject DotManagerObj;
    private RealTimeCounter RealTimeScript;
    private GameObject RealTimerGameObj;
    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;
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
        // Referneces DotManagerScript
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        // HungerSlider min and max
        HungerSlider.maxValue = 99;
        HungerSlider.minValue = 0f;
        CanGetCurrency = false;
    }

    private void Update()
    {
        // Displays hunger value (used in debug)
        //HungerMetre.text = "" + Hunger;
     
        // clamps hunger from 0 to 100
        Happiness = Mathf.Clamp(Happiness, 0, 100);
     
        // Slowly counts down Happiness value
        Happiness -= Time.deltaTime / 3;
        HungerSlider.value = Happiness;
       
        // Saving Companions Happiness value
        PlayerPrefs.SetFloat("CurrentHappiness", Happiness);
 

        // if Happiness less than 20
        if (Happiness < 20)
        {
             dotManagerScript.Multipier = 1;
 
        }
        if(Happiness > 20 && Happiness < 40)
        {
            dotManagerScript.Multipier = multiplier[0];
 
        }
        if (Happiness > 40 && Happiness < 60)
        {
            dotManagerScript.Multipier = multiplier[1];
 
        }
        if (Happiness > 60 && Happiness < 80)
        {
            dotManagerScript.Multipier = multiplier[2];
         

        }
        if (Happiness > 80 && Happiness < 100)
        {
            CanGetCurrency = true;
            dotManagerScript.Multipier = multiplier[3];
      
        }
    }
  //  public void ShrinkingPeices()
  //  {
  //
  //
  //      StartCoroutine(TEST());
  //
  //      //FeedMonster();
  //  }
  //  IEnumerator TEST()
  //  {
  //      for (Peice = 0; Peice < EatingPeices.Count; Peice++)
  //      {
  //          EatingPeices[Peice].gameObject.transform.localScale -= new Vector3(15, 15, 15) * Time.deltaTime;
  //          yield return new WaitForSeconds(0);
  //          GrowTime = true;
  //          Debug.Log("3 secodns up");
  //      }
  //  }
    public void FeedMonster()
    {
        
        // transforms the peices to the eatingspawner position
        for (int i = 0; i < EatingPeices.Count; i++)
        {
         
             EatingPeices[i].transform.position = EatingPeiceSpawner.transform.position + new Vector3(posX, posY, 0);
             CurrencyChance = HungerMultiplier;
            Destroy(EatingPeices[i].gameObject);
            HungerMultiplier = i / 2;
            Happiness += HungerMultiplier;

        }
        if (CanGetCurrency)
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
    
    }
    private void OnApplicationQuit()
    {
        RealTimeScript.ResetClock();
    }
}
