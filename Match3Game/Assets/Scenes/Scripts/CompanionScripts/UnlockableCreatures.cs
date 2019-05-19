using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UnlockableCreatures : MonoBehaviour
{
    public string CompanionName;
    private string NewGobuUnlocked;
    public string CriusUnlocked;
    // Put all locked companions in here 
    public GameObject[] LockedCompanions;
    // holds all the Available companions in gameobject
    private GameObject CompanionStorage;
    // Has all available companions in list
    public GameObject[] Companions;
    private int NEWGOBU;
    private CompanionNavigation CompNav;
    // Names for Each moobling
    public string[] UnlockableMoobling;
    public Sprite[] CompanionImages;
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

        CriusUnlocked = PlayerPrefs.GetString("CRIUS");

        UnlockableMoobling[0] = PlayerPrefs.GetString("BINKY");
        UnlockableMoobling[1] = PlayerPrefs.GetString("KOKO");

        // Activates unlocked characters
        Unlock();
        // unlocks the character 
        GetUnlocked();

    }
    private void Update()
    {
       // Unlock();
       // GetUnlocked();
    }
    // Goes through an checks which companins are unlocked
    public void GetUnlocked()
    {
       //if (NewGobuUnlocked == "NEWGOBU")
       //{
       //                                    // int UnlockNUM
       //    GameObject Creature = Instantiate(Companions[0], CompanionStorage.transform.position, Quaternion.identity);
       //    Creature.transform.parent = CompanionStorage.transform;
       //   // CompNav.Companions.Add(Creature.transform.gameObject);
       //    Creature.SetActive(false);
       //}
      
        if(UnlockableMoobling[0] == "BINKY")
        {
            LockedCompanions[0].GetComponent<Image>().sprite = CompanionImages[0];
            LockedCompanions[0].GetComponent<Button>().enabled = true;
        }
         if (UnlockableMoobling[1] == "KOKO")
        {
            LockedCompanions[1].GetComponent<Image>().sprite = CompanionImages[1];
            LockedCompanions[1].GetComponent<Button>().enabled = true;
        }
        if (CriusUnlocked == "CRIUS")
        {
            LockedCompanions[2].GetComponent<Image>().sprite = CompanionImages[2];
            LockedCompanions[2].GetComponent<Button>().enabled = true;
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
        }
    }
}