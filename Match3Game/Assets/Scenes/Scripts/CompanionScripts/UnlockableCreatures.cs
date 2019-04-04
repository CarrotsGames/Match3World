using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnlockableCreatures : MonoBehaviour
{
    public string CompanionName;
    private string NewGobuUnlocked;
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
        Unlock();
        GetUnlocked();
    }
    public void GetUnlocked()
    {
        if (NewGobuUnlocked == "NEWGOBU")
        {
            GameObject Creature = Instantiate(Companions[0], CompanionStorage.transform.position, Quaternion.identity);
            Creature.transform.parent = CompanionStorage.transform;
           // CompNav.Companions.Add(Creature.transform.gameObject);
            Creature.SetActive(false);
        }

    }
    public void Unlock()
    {
        CompanionName = PlayerPrefs.GetString("UNLOCKED");
        switch (CompanionName)
        {
            case "NEWGOBU":
                {
                    NewGobuUnlocked = CompanionName;
                    PlayerPrefs.SetString("NEWGOBU", NewGobuUnlocked);
                }
                break;
            case "ROBO":
                {

                }
                break;
            case "SPACE":
                {

                }
                break;
        }
    }
}