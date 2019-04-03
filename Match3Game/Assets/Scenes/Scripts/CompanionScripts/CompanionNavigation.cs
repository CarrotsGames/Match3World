using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CompanionNavigation : MonoBehaviour
{
    public int CompanionNumber;
    public List<GameObject> Companions;
    private GameObject CompanionStorage;
    private UnlockableCreatures Unlocklables;
    // Use this for initialization
    void Start()
    {

        CompanionStorage = GameObject.FindGameObjectWithTag("Creatures");
        for (int i = 0; i < CompanionStorage.transform.childCount; i++)
        {
            Companions.Add(CompanionStorage.transform.GetChild(i).gameObject);
        }
        Companions[0].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            Companions[CompanionNumber].SetActive(false);
            if (CompanionNumber == Companions.Count - 1)
            {
                CompanionNumber = 0;
                Companions[CompanionNumber].SetActive(true);

            }
            else
            {
                CompanionNumber += 1;
                Companions[CompanionNumber].SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Companions[CompanionNumber].SetActive(false);
            if (CompanionNumber == 0)
            {
                CompanionNumber = Companions.Count - 1;
                Companions[CompanionNumber].SetActive(true);

            }
            else
            {
                CompanionNumber -= 1;
                Companions[CompanionNumber].SetActive(true);
            }
        }
        //     switch (CompanionNumber)
        // {
        //     case 1:
        //         Companions[0].SetActive(true);
        //
        //         break;
        //     case 2:
        //         Companions[1].SetActive(true);
        //
        //
        //         break;
        //     case 3:
        //         Companions[2].SetActive(true);
        //
        //
        //         break;
        //     case 4:
        //         Companions[3].SetActive(true);
        //
        //
        //         break;
        //     case 5:
        //         Companions[4].SetActive(true);
        //
        //
        //         break;
        //
        // }
        // 

    }
}