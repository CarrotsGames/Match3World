using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoreScript : MonoBehaviour
{

    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;
    public List<GameObject> StoreItems;
    public GameObject ItemStorage;

    public int SuperColourRemoverQuantity;
    public int SuperShuffleQuantity;
    public int SuperBombQuantity;
    public int SuperMultiplierQuantity;
    public int Navigate;

    public int SuperColourRemoverAmount;
    public int SuperShuffleAmount;
    public int SuperBombAmount;
    public int SuperMultiplierAmount;

    private void Start()
    {
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        for (int i = 0; i < ItemStorage.transform.childCount; i++)
        {
            StoreItems.Add(ItemStorage.transform.GetChild(i).gameObject);
        }
        StoreItems[0].SetActive(true);
    }
   
    // Navigates through the store items
    public void Navigation(int ArrowNum)
    {
        switch(ArrowNum)
        {
            // left
            case 1:
                if (Navigate == 0)
                {

                    StoreItems[Navigate].SetActive(false);
                    Navigate = StoreItems.Count - 1;
                    StoreItems[Navigate].SetActive(true);
                    //   Companions[Navigate].SetActive(true);
                  //  Navigation();

                }
                else
                {

                    StoreItems[Navigate].SetActive(false);
                    Navigate -= 1;
                    //   Companions[Navigate].SetActive(true);
                   // Navigation();

                }
                break;
                //right
            case 2:
                StoreItems[Navigate].SetActive(false);
                if (Navigate == StoreItems.Count - 1)
                {
                    Navigate = 0;
                    StoreItems[Navigate].SetActive(true);
                    //CompanionName = Companions[Navigate].name;
                    //     Navigation();
                    //  Companions[CompanionNumber].SetActive(true);
                }
                else
                {
                    Navigate += 1;
                    StoreItems[Navigate].SetActive(true);
                    //CompanionName = Companions[Navigate].name;
                    //    Navigation();
                }
                break;
        }
    }

    public void Shop(int ButtonNumber)
    {
        // each store button has a number which gives the player
        // their desired item
        switch (ButtonNumber)
        {
                // SuperColourRemover purchase
            case 1:
                if (PowerUpManagerScript.Currency > SuperColourRemoverAmount)
                {
                    PowerUpManagerScript.NumOfSCR += SuperColourRemoverQuantity;
                    PowerUpManagerScript.Currency -= SuperColourRemoverAmount;
                }
                else
                {

                    Debug.Log("Insufficient funds");

                }
                break;
                // SuperShuffleAmount purchase
            case 2:
                if (PowerUpManagerScript.Currency > SuperShuffleAmount)
                {
                    PowerUpManagerScript.NumOfShuffles += SuperShuffleQuantity;
                    PowerUpManagerScript.Currency -= SuperShuffleAmount;
                }
                else
                {

                    Debug.Log("Insufficient funds");
                }
                break;
                // SuperMultplier purchase
            case 3:
                if (PowerUpManagerScript.Currency > SuperMultiplierAmount)
                {
                    PowerUpManagerScript.NumOfMultilpiers += SuperMultiplierQuantity;
                    PowerUpManagerScript.Currency -= SuperMultiplierAmount;
                }
                else
                {

                    Debug.Log("Insufficient funds");
                }
                break;
                // SuperBomb purchase
            case 4:
                if (PowerUpManagerScript.Currency > SuperBombAmount)
                {
                    PowerUpManagerScript.NumOfBombs += SuperBombQuantity;
                 //   PowerUpManagerScript.NumOfSCR += 5;

                    PowerUpManagerScript.Currency -= SuperBombAmount;
                }
                else
                {

                    Debug.Log("Insufficient funds");
                }
                break;
                // Cruis Creature purchase
            case 5:
                if (PowerUpManagerScript.Currency > 5)
                {
                    PlayerPrefs.SetString("UNLOCKED", "CRIUS");
                    Debug.Log("YOU HAVE PURCHASED KRRRRAASSS");

                }
                else
                {

                    Debug.Log("Insufficient funds");
                }

                break;

        }
    }

}
