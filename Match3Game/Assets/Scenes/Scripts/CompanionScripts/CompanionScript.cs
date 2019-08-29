﻿using UnityEngine;
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
    public GameObject GoldSpawn;
    public GameObject Gold;
    private GameObject DotManagerObj;
    private GameObject MainCamera;
    private GameObject PowerUpManGameObj;
    private GameObject HappinessGameObj;
    private DotManager DotManagerScriptRef;
    private RealTimeCounter RealTimeScript;
    private PowerUpManager PowerUpManagerScript;
    public HappinessManager HappinessManagerScript;
    [HideInInspector]
    public int Total;
    // Update is called once per frame
    private int posX;
    private int posY;
    // Chain multiplier depending on how big your chain is
    private int HungerMultiplier = 1;
    private int CurrencyChance;
    private GameObject AudioManagerGameObj;
    private AudioManager AudioManagerScript;


    void Start()
    {
        AudioManagerGameObj = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManagerScript = AudioManagerGameObj.GetComponent<AudioManager>();
         // References the Realtimescript which is located on camera (TEMP)
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = MainCamera.GetComponent<RealTimeCounter>();

        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
      
        // Referneces DotManagerScript
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScriptRef = DotManagerObj.GetComponent<DotManager>();
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        // HungerSlider min and max

    }
 


    public void FeedMonster()
    {
        // transforms the peices to the eatingspawner position
        for (int i = 0; i < EatingPeices.Count; i++)
        {
            if(EatingPeices[i] == null)
            {
                EatingPeices.RemoveAt(i);
            }
 
            EatingPeices[i].transform.gameObject.layer = 2;

            // Destroy(EatingPeices[i].gameObject);
             HungerMultiplier = HappinessManagerScript.Level / 2 + i;
            // if(SuperMultiplier.CanUseSuperMultiplier)
            //{
            //    HungerMultiplier *= SuperMultiplierScript.SuperMultiplier;
            //}

            MainCamera.GetComponent<CameraShake>().ShakeCamera(HappinessGameObj.GetComponent<HappinessManager>().Level / 10, 0.25f);
            // displays total score to Text

        }
        Total = 0;
        // Mutlplier is equal to player level
        int mulpliernum = HappinessGameObj.GetComponent<HappinessManager>().Level;
 
        // Total amount from the combo is equal to the number of nodes plus combo score
        Total = EatingPeices.Count + DotManagerScriptRef.ComboScore ;
        // Total multlpied by multiplier 
        Total *= mulpliernum;
        // Adds total to score
        DotManagerScriptRef.TotalScore += Total;
        DotManagerScriptRef.HighScore.text = "" + DotManagerScriptRef.TotalScore;

        // If the player can earch currency they will have a Levelvalue out of 70 chance getting a coin
        if (HappinessManagerScript.CanGetCurrency)
        {
            CurrencyChance = HappinessGameObj.GetComponent<HappinessManager>().Level;

            int chance = Random.Range(CurrencyChance, 70);
            if (chance == 42)
            {
                PowerUpManagerScript.Currency += Random.Range(1,3);
                PowerUpManagerScript.PowerUpSaves();
            }
         }
        if (!HappinessManagerScript.IsSleeping)
        {
            // adds happyness to the companion
            // Hunger multlplier = i(Num of peices) / 2 
            HappinessManagerScript.HappinessSliderValue += HungerMultiplier;

           
            int RandomSound = Random.Range(0, AudioManagerScript.MooblingAudio.Length);
            // When fed the companion will play a random sound in list
            AudioManagerScript.MooblingSource.clip = AudioManagerScript.MooblingAudio[RandomSound];
            AudioManagerScript.MooblingSource.Play();    
        }
        HappinessManagerScript.HappinessBar();
        DotManagerObj.GetComponent<DestroyNodes>().CreateComboList();
    }


    //when game closes save the current hugner and start counting down outside of the app
    private void OnApplicationPause(bool pause)
    {
      // RealTimeScript.ResetClock();
      // pause = true;
    }
    private void OnApplicationQuit()
    {
       // RealTimeScript.ResetClock();
    }
}
