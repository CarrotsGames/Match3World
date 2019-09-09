﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
public class CompanionScript : MonoBehaviour
{
    public int TotalConnection;
    // public List<GameObject> NodeCount;
    // Use this for initialization
    public GameObject GoldSpawn;
    public GameObject GoldParticle;

    private GameObject DotManagerObj;
    private GameObject MainCamera;
    private GameObject PowerUpManGameObj;
    private GameObject HappinessGameObj;
    private DotManager DotManagerScriptRef;
    private PowerUpManager PowerUpManagerScript;
    public HappinessManager HappinessManagerScript;
    [HideInInspector]
    public int Total;
    // Update is called once per frame
    private int posX;
    private int posY;
    private int CurrencyChance;
    private GameObject AudioManagerGameObj;
    private AudioManager AudioManagerScript;
    // public GameObject TotalScoreGameObj;
    private GameObject Challenge;
    public Text TotalScore;
    float RemoveTotalTimer;
    int Chance;
    void Start()
    {
        AudioManagerGameObj = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManagerScript = AudioManagerGameObj.GetComponent<AudioManager>();
         // References the Realtimescript which is located on camera (TEMP)
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
 
        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
      
        // Referneces DotManagerScript
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScriptRef = DotManagerObj.GetComponent<DotManager>();
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        TotalScore.enabled = false;
        
        // HungerSlider min and max
        // TotalScoreGameObj.transform.position = new Vector3(500, 0, 0);
    }

    private void Update()
    {
        Debug.Log(this.gameObject);
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            PowerUpManagerScript.Currency += Random.Range(1, 3);
            PowerUpManagerScript.PowerUpSaves();
            Instantiate(GoldParticle, GoldSpawn.transform.position, Quaternion.identity);
        }
         if(RemoveTotalTimer < 0)
        {
            TotalScore.enabled = false;
            //TotalScoreGameObj.transform.position = new Vector3(500, 0, 0);
        }
        else
        {
           
            RemoveTotalTimer -= Time.deltaTime;
        }
    }

    public void PlaySound()
    {
      
        int RandomSound = Random.Range(0, AudioManagerScript.MooblingAudio.Length);
        // When fed the companion will play a random sound in list
        AudioManagerScript.MooblingSource.clip = AudioManagerScript.MooblingAudio[RandomSound];
        AudioManagerScript.MooblingSource.Play();    
    }

   public void ScoreMultiplier(int EXPTotal, int Total, string ConnectionType)
    {
        PlaySound();
        int LevelMultiplier = HappinessGameObj.GetComponent<HappinessManager>().Level;
        EXPTotal += 3;
        if (GameObject.Find("CHALLENGE") == null)
        {
            switch(ConnectionType)
            {
                case "Normal":
                    {
                        if (SuperMultiplierScript.CanUseSuperMultiplier)
                        {
                            Total *= 2;
                        }

                        Total *= LevelMultiplier;
                        Total *= 5;
                        // Adds total to score
                        DotManagerScriptRef.TotalScore += Total;
                        DotManagerScriptRef.HighScore.text = "" + DotManagerScriptRef.TotalScore;
                        // HappinessManagerScript.HappinessSliderValue += EatingPeices.Count + LevelMultiplier;
                        HappinessManagerScript.HappinessSliderValue += EXPTotal;
                        TotalScore.enabled = true;
                        TotalScore.transform.position = DotManagerObj.GetComponent<DestroyNodes>().LastKnownPosition;
                        TotalScore.text = "" + Total;
                        Total = 0;
                        EXPTotal = 0;
                    }
                    break;
                case "SCR":
                    {
                        if (SuperMultiplierScript.CanUseSuperMultiplier)
                        {
                            Total *= 2;
                        }

                        Total *= LevelMultiplier;
                       
                        if (Total > 30000)
                        {
                            Total = 30000;
                        }
                        // Adds total to score
                        DotManagerScriptRef.TotalScore += Total;
                        DotManagerScriptRef.HighScore.text = "" + DotManagerScriptRef.TotalScore;
                        // HappinessManagerScript.HappinessSliderValue += EatingPeices.Count + LevelMultiplier;
                        HappinessManagerScript.HappinessSliderValue += EXPTotal;
                        TotalScore.enabled = true;
                        TotalScore.transform.position = DotManagerObj.GetComponent<DestroyNodes>().LastKnownPosition;
                        TotalScore.text = "" + Total;
                        Total = 0;
                        EXPTotal = 0;
                    }
                    break;
                case "SuperBomb":
                    {

                        if (SuperMultiplierScript.CanUseSuperMultiplier)
                        {
                            Total *= 2;
                        }

                        Total *= LevelMultiplier;
                        if (Total > 25000)
                        {
                            Total = 25000;
                        }
                        // Adds total to score
                        DotManagerScriptRef.TotalScore += Total;
                        DotManagerScriptRef.HighScore.text = "" + DotManagerScriptRef.TotalScore;
                        // HappinessManagerScript.HappinessSliderValue += EatingPeices.Count + LevelMultiplier;
                        HappinessManagerScript.HappinessSliderValue += EXPTotal;
                        TotalScore.enabled = true;
                        TotalScore.transform.position = DotManagerObj.GetComponent<DestroyNodes>().LastKnownPosition;
                        TotalScore.text = "" + Total;
                        Total = 0;
                        EXPTotal = 0;
                    }
                    break;
            }
            //// Mutlplier is equal to player level
            ////EXP is defualt 3
            //// EXP is equal to total connection + level
            //EXPTotal += TotalConnection + HappinessGameObj.GetComponent<HappinessManager>().Level;
            //// Total amount from the combo is equal to the number of nodes plus combo score
            //Total += TotalConnection + DotManagerScriptRef.ComboScore;
            RemoveTotalTimer += 0.5f;

            // MUTLPIER VALUES WITH EXP
            PlayerPrefs.SetInt("SCORE", DotManagerScriptRef.TotalScore);
            // If the player can earch currency they will have a Levelvalue out of 70 chance getting a coin
            if (HappinessManagerScript.CanGetCurrency)

            {
                CurrencyChance = HappinessGameObj.GetComponent<HappinessManager>().Level;
                Chance = Random.Range(CurrencyChance, 70);
                if (Chance == 42)

                {

                    PowerUpManagerScript.Currency += Random.Range(1, 3);
                    PowerUpManagerScript.PowerUpSaves();
                    Instantiate(GoldParticle, GoldSpawn.transform.position, Quaternion.identity);
                }

            }

            //it exists

            HappinessManagerScript.HappinessBar();
          
        }
        else
        {
            GameObject Go = GameObject.Find("CHALLENGE");
            LevelMultiplier = 2;
            Total = TotalConnection + DotManagerScriptRef.ComboScore;
            Total *= LevelMultiplier;
            Go.GetComponent<ChallengeManager>().ChallengeScore += Total;
            Go.GetComponent<ChallengeManager>().CheckForNodes();
             // MULTLPIER 1
            // TIMES TOTAL
        }
    }

}