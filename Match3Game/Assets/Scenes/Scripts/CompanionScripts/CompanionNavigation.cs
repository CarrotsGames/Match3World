﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompanionNavigation : MonoBehaviour
{
    private RealTimeCounter RealTimeScript;
    private GameObject RealTimerGameObj;
    private string CompanionName;
    public int CompanionNumber;
    public List<GameObject> Companions;
    private GameObject CompanionStorage;
    private UnlockableCreatures Unlocklables;
     public int Navigate;
    float Happiness;
    float Happiness1;
    float Happiness2;
    public Slider HappySlider;
     // Use this for initialization
    void Start()
    {
 
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
        Companions[0].SetActive(true);

    }

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
        }

    }
   public void NavigationControls(int Arrows)
    {
        // each arrow has its own value which navigates through the companions
        switch (Arrows)
        {
            // Left 
            case 0:
                if (Navigate == 0)
                {

                    Companions[Navigate].SetActive(false);
                    Navigate = Companions.Count - 1;
                    Companions[Navigate].SetActive(true);
                    CompanionName = Companions[Navigate].name;
                    //   Companions[Navigate].SetActive(true);
                    //     Navigation();

                }
                else
                {
                    Companions[Navigate].SetActive(false);

                    Navigate -= 1;
                    Companions[Navigate].SetActive(true);
                    CompanionName = Companions[Navigate].name;
                    //   Companions[Navigate].SetActive(true);
                    //   Navigation();

                }
                break;
             // right
            case 1:
                Companions[Navigate].SetActive(false);
                if (Navigate == Companions.Count - 1)
                {
                    Navigate = 0;
                    Companions[Navigate].SetActive(true);
                    CompanionName = Companions[Navigate].name;
                    //     Navigation();
                    //  Companions[CompanionNumber].SetActive(true);
                }
                else
                {
                    Navigate += 1;
                    Companions[Navigate].SetActive(true);
                    CompanionName = Companions[Navigate].name;
                    //    Navigation();
                }
                break;
        }

    }
     
    // Update is called once per frame
    void Update()
    {
        // checks name of companion and displays how much happiness 
        // that specific companion has when highlited 
        switch (CompanionName)
        {
            case "Gobu":
                Happiness = PlayerPrefs.GetFloat("GobuHappiness");
                RealTimeScript.HappinessCountDown[0] = Happiness;
                HappySlider.value = RealTimeScript.HappinessCountDown[0];

                break;
            case "Binky":
                Happiness1 = PlayerPrefs.GetFloat("BinkyHappiness");
                RealTimeScript.HappinessCountDown[1] = Happiness1;
                HappySlider.value = RealTimeScript.HappinessCountDown[1];

                break;
            case "Koko":
                Happiness2 = PlayerPrefs.GetFloat("KokoHappiness");
                //HappinessManagerScript.Happiness = RealTimeScript.TimerCountDown2;
                RealTimeScript.HappinessCountDown[2] = Happiness2;
                HappySlider.value = RealTimeScript.HappinessCountDown[2];

                break;
                //shares happiness with Gobu
            case "NEWGOBU(Clone)":
                Happiness = PlayerPrefs.GetFloat("GobuHappiness");
                RealTimeScript.HappinessCountDown[0] = Happiness;
                HappySlider.value = RealTimeScript.HappinessCountDown[0];

                break;
            case "KRAS(Clone)":
                Happiness = PlayerPrefs.GetFloat("CriusHappiness");
                RealTimeScript.HappinessCountDown[0] = Happiness;
                HappySlider.value = RealTimeScript.HappinessCountDown[0];

                break;
        }
   

    }
}