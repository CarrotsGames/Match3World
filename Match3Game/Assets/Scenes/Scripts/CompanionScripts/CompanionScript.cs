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
 
    public Slider HungerSlider;
 
    private GameObject DotManagerObj;
    private GameObject MainCamera;
    private GameObject PowerUpManGameObj;
    private GameObject HappinessGameObj;
    private DotManager DotManagerScriptRef;
    private RealTimeCounter RealTimeScript;
    private PowerUpManager PowerUpManagerScript;
    public HappinessManager HappinessManagerScript;
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
            MainCamera.GetComponent<CameraShake>().ShakeCamera(HappinessManagerScript.MultlpierNum / 1.5f, 0.25f);
            // displays total score to Text
 
            DotManagerScriptRef.HighScore.text = "" + DotManagerScriptRef.TotalScore;
        }

        if (HappinessManagerScript.CanGetCurrency)
        {
            int chance = Random.Range(CurrencyChance, 100);
            if (chance >= 90)
            {
                PowerUpManagerScript.Currency += 1;
            }
            Debug.Log(chance);
            //  DotManagerScript.Currency 
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
    }
 
    // when the pieces collide with the companion it will destory them

    //when game closes save the current hugner and start counting down outside of the app
    private void OnApplicationPause(bool pause)
    {
      // RealTimeScript.ResetClock();
      // pause = true;
    }
    private void OnApplicationQuit()
    {
        RealTimeScript.ResetClock();
    }
}
