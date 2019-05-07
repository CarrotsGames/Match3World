using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnlockableCreatures : MonoBehaviour
{
    public string CompanionName;
    private string NewGobuUnlocked;
    public string CriusUnlocked;

    private GameObject CompanionStorage;
    public GameObject[] Companions;
    private int NEWGOBU;
    private CompanionNavigation CompNav;
    // Use this for initialization
    void Start()
    {
        CompanionStorage = GameObject.FindGameObjectWithTag("Creatures");
        CompNav = GetComponent<CompanionNavigation>();

        NewGobuUnlocked = PlayerPrefs.GetString("NEWGOBU");
        CriusUnlocked = PlayerPrefs.GetString("CRIUS");

        Unlock();
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
            case "ROBO":
                {
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