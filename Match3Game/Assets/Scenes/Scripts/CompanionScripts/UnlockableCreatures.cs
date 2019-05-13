using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnlockableCreatures : MonoBehaviour
{
    public string CompanionName;
    private string NewGobuUnlocked;
    public string CriusUnlocked;
    public string[] UnlockableMoobling;
    private GameObject CompanionStorage;
    public GameObject[] Companions;
    private int NEWGOBU;
    private CompanionNavigation CompNav;
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

        UnlockableMoobling[1] = PlayerPrefs.GetString("BINKY");
        UnlockableMoobling[2] = PlayerPrefs.GetString("KOKO");

        // Activates unlocked characters
        Unlock();
        // unlocks the character 
        GetUnlocked();

    }
 
    // Goes through an checks which companins are unlocked
    public void GetUnlocked()
    {
        if (NewGobuUnlocked == "NEWGOBU")
        {
                                            // int UnlockNUM
            GameObject Creature = Instantiate(Companions[0], CompanionStorage.transform.position, Quaternion.identity);
            Creature.transform.parent = CompanionStorage.transform;
           // CompNav.Companions.Add(Creature.transform.gameObject);
            Creature.SetActive(false);
        }
        if (CriusUnlocked == "CRIUS")
        {
            // int UnlockNUM
            GameObject Creature = Instantiate(Companions[1], CompanionStorage.transform.position, Quaternion.identity);
            Creature.transform.parent = CompanionStorage.transform;
            // CompNav.Companions.Add(Creature.transform.gameObject);
            Creature.SetActive(false);
        }
        if(UnlockableMoobling[1] == "BINKY")
        {
            GameObject Creature = Instantiate(Companions[2], CompanionStorage.transform.position, Quaternion.identity);
            Creature.transform.parent = CompanionStorage.transform;
            Creature.SetActive(false);
        }
        else if (UnlockableMoobling[2] == "KOKO")
        {

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
                    UnlockableMoobling[1] = CompanionName;
                    PlayerPrefs.SetString("BINKY", UnlockableMoobling[2]);
                }
                break;
            case "KOKO":
                {
                    UnlockableMoobling[2] = CompanionName;
                    PlayerPrefs.SetString("KOKO", UnlockableMoobling[2]);
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