using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UnlockableCreatures : MonoBehaviour
{
    [HideInInspector]
    public string CompanionName;
    [HideInInspector]
    public string CriusUnlocked;
    private string NewGobuUnlocked;
    // Put all locked companions in here 
    public GameObject[] LockedCompanions;
    // Put all locked companions in here 
    public GameObject[] BuyCompanions;
    // holds all the Available companions in gameobject
    private GameObject CompanionStorage;
    // Has all available companions in list
    public GameObject[] Companions;
    private int NEWGOBU;
    private CompanionNavigation CompNav;
    // Names for Each moobling
    public string[] UnlockableMoobling;
    public Sprite[] CompanionImages;
    private float CheckUnlocks;
     // MOOBLING NUMBERS FOR UNLOCKABLEMOOBLING STRING
    // 0 GOBU
    // 1 BINKY
    // 2 KOKO
    // 3 CRIUS
    // 4 ROBO
    // 5 MONKA
    void Start()
    {
        // find companion list in scene
        CompanionStorage = GameObject.FindGameObjectWithTag("Creatures");
        CompNav = GetComponent<CompanionNavigation>();

        // bools that check if that character is unlocked
        NewGobuUnlocked = PlayerPrefs.GetString("NEWGOBU");

        UnlockableMoobling[0] = PlayerPrefs.GetString("BINKY");
        UnlockableMoobling[1] = PlayerPrefs.GetString("KOKO");
        // TODO: Change to UnlockableMoobling[2]
        CriusUnlocked = PlayerPrefs.GetString("CRIUS");
        UnlockableMoobling[3] = PlayerPrefs.GetString("SAUCO");
        UnlockableMoobling[4] = PlayerPrefs.GetString("CHICKPEA");
        UnlockableMoobling[5] = PlayerPrefs.GetString("SQUISHY");
        UnlockableMoobling[6] = PlayerPrefs.GetString("Cronus Locked");
        UnlockableMoobling[7] = PlayerPrefs.GetString("OKAMI");
        UnlockableMoobling[8] = PlayerPrefs.GetString("Ida Locked");
        // Activates unlocked characters
        Unlock();
        // unlocks the character 
        GetUnlocked();
 
    }
    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.T))
        //{
        //    UnlockableMoobling[8] = "Ida Locked";
        //    PlayerPrefs.SetString("Ida Locked", UnlockableMoobling[8]);
        //    GetUnlocked();
        //}
    }
    public void UnlockAll()
    {
        UnlockableMoobling[0] = "BINKY";
        UnlockableMoobling[1] = "KOKO";
        UnlockableMoobling[3] = "SAUCO";
        UnlockableMoobling[4] = "CHICKPEA";
        CriusUnlocked = "CRIUS";
        PlayerPrefs.SetString("BINKY", UnlockableMoobling[0]);
        PlayerPrefs.SetString("KOKO", UnlockableMoobling[1]);
        PlayerPrefs.SetString("CRIUS", CriusUnlocked);
        PlayerPrefs.SetString("SAUCO", UnlockableMoobling[3]);
        PlayerPrefs.SetString("CHICKPEA", UnlockableMoobling[4]);

    }
    // Goes through an checks which companins are unlocked
    public void GetUnlocked()
    {
        if (LockedCompanions[0].name != "Dummy")
        {
            if (UnlockableMoobling[0] == "BINKY")
            {
                BuyCompanions[0].SetActive(false);
                LockedCompanions[0].SetActive(true);
               
            }
          
            if (UnlockableMoobling[1] == "KOKO")
            {
                BuyCompanions[1].SetActive(false);
                LockedCompanions[1].SetActive(true);

            }
          

            if (CriusUnlocked == "CRIUS")
            {
                BuyCompanions[2].SetActive(false);
                LockedCompanions[2].SetActive(true);
            }
       
            if (UnlockableMoobling[3] == "SAUCO")
            {
                BuyCompanions[3].SetActive(false);
                LockedCompanions[3].SetActive(true);
            }
           
            if (UnlockableMoobling[4] == "CHICKPEA")
            {
                BuyCompanions[4].SetActive(false);
                LockedCompanions[4].SetActive(true);
            }
         
            if (UnlockableMoobling[5] == "SQUISHY")
            {
                BuyCompanions[5].SetActive(false);
                LockedCompanions[5].SetActive(true);
            }
          
            //MONTHLY
            if (UnlockableMoobling[6] == "Cronus Locked")
            {
                BuyCompanions[6].SetActive(false);
                LockedCompanions[6].SetActive(true);
            }
       
            if (UnlockableMoobling[7] == "OKAMI")
            {
                BuyCompanions[7].SetActive(false);
                LockedCompanions[7].SetActive(true);
            }
      
            //MONTHLY
            if (UnlockableMoobling[8] == "Ida Locked")
            {
                BuyCompanions[8].SetActive(false);
                LockedCompanions[8].SetActive(true);
            }
       
        }
    }
    // Checks the companionName strings name and unlocks that character
    public void Unlock()
    {
        // gets the saved string name from "UNLOCKED"
        CompanionName = PlayerPrefs.GetString("UNLOCKED");
        // checks if the companion string is equal to any of these
        switch (CompanionName)
        {
            case "NEWGOBU":
                {
                    // This string is equal to the unlocked name
                    NewGobuUnlocked = CompanionName;
                    PlayerPrefs.SetString("NEWGOBU", NewGobuUnlocked);
                }
                break;
            case "BINKY":
                {
                    UnlockableMoobling[0] = CompanionName;
                    PlayerPrefs.SetString("BINKY", UnlockableMoobling[0]);
                }
                break;
            case "KOKO":
                {
                    UnlockableMoobling[1] = CompanionName;
                    PlayerPrefs.SetString("KOKO", UnlockableMoobling[1]);
                }
                break;
            case "CRIUS":
                {
                    CriusUnlocked = CompanionName;
                    PlayerPrefs.SetString("CRIUS", CriusUnlocked);
                }
                break;
            case "SAUCO":
                {
                    UnlockableMoobling[3] = CompanionName;
                    PlayerPrefs.SetString("SAUCO", UnlockableMoobling[3]);
                }
                break;
            case "CHICKPEA":
                {
                    UnlockableMoobling[4] = CompanionName;
                    PlayerPrefs.SetString("CHICKPEA", UnlockableMoobling[4]);
                }
                break;
            case "SQUISHY":
                {
                    UnlockableMoobling[5] = CompanionName;
                    PlayerPrefs.SetString("SQUISHY", UnlockableMoobling[5]);
                }
                break;
            case "Cronus Locked":
                {
                    UnlockableMoobling[6] = CompanionName;
                    PlayerPrefs.SetString("Cronus Locked", UnlockableMoobling[6]);
                }
                break;
            case "OKAMI":
                {
                    UnlockableMoobling[7] = CompanionName;
                    PlayerPrefs.SetString("OKAMI", UnlockableMoobling[7]);
                }
                break;
        }
        GetUnlocked();
    }
}