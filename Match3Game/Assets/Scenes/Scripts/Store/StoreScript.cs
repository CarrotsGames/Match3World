using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class StoreScript : MonoBehaviour
{

    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;
    public List<GameObject> StoreItems;
    public GameObject ItemStorage;
    public GameObject eggUnlocked;
    public GameObject UnlockMoobling;
// Max "You Unlocked SplashScreen"
    public GameObject youBoughtCanvus;

    public GameObject eggUnlock;
    public GameObject scrUnlock;
    public GameObject shuffleUnlock;
    public GameObject bombUnlock;
    public GameObject multiUnlock;
    public GameObject multiFreezeUnlock;

    //eggIncubation true = Egg in panel falses = egg needs to be bought
    public bool eggIncubation;

    public Sprite[] EggImages;
    // Link the egg hatch button in scene to this
    public GameObject EggHatchButton;
    // Refrences the EggHatchScript
    public GameObject EggHatchScript;
    // Item Quantities
    public int SuperColourRemoverQuantity;
    public int SuperShuffleQuantity;
    public int SuperBombQuantity;
    public int SuperMultiplierQuantity;
    public int FreezeMultplierQuantity;

    public int Navigate;
    // item Cost
    public int SuperColourRemoverAmount;
    public int SuperShuffleAmount;
    public int SuperBombAmount;
    public int SuperMultiplierAmount;
    public int FreezeMultiplierAmount;

    public int[] CompanionPrice;

    public GameObject PurchaseAnalytics;
    private void Start()
    {
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        // Adds all the items to the store
        for (int i = 0; i < ItemStorage.transform.childCount; i++)
        {
            StoreItems.Add(ItemStorage.transform.GetChild(i).gameObject);
        }
        StoreItems[0].SetActive(true);
        DisableEggButton();
    }
    private void Update()
    {
        if(!EggHatch.StartCountDown)
        {
            DisableEggButton();

        }      
    }
    // Navigates through the store items
    public void Navigation(int ArrowNum)
    {
        switch (ArrowNum)
        {
            // left
            case 1:
                Debug.Log("LEFT");

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
                    StoreItems[Navigate].SetActive(true);
                    //   Companions[Navigate].SetActive(true);
                    // Navigation();

                }
                break;
            //right
            case 2:
                Debug.Log("RIGHT");
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
    // Set in store scene
    // HOW TO SET UP COMPANION PURCHASE
    // 1: add a case for that companion and there price
    // 2: set the UNLOCK string to a suitable name for the companion. eg SAUCO 
    //NOTE:UNLOCKED cannot be changed because that saves the unlockables name 
    // 3 Go to unlockable script and give the new companions its own LockedMoobling,UnlockableMoobling index (line 56)
    // 4 now go to the Unlock void in that script and add the unlock string name (set before) to a new case
    // 5 Add that mooblings unlocableMoobling index to equal companion name
    // 6 finally save the string to that unlockableMoobling index and were good to go

    public void Shop(int ButtonNumber)
    {
        // each store button has a number which gives the player
        // their desired item
        switch (ButtonNumber)
        {
            // SuperColourRemover purchase
            case 1:
                if (PowerUpManagerScript.Currency >= SuperColourRemoverAmount)
                {
                    int SCRPurchaseCount = PlayerPrefs.GetInt("SCRPURCHASE");
                    SCRPurchaseCount++;
                    PlayerPrefs.SetInt("SCRPURCHASE", SCRPurchaseCount);
 
                    PowerUpManagerScript.NumOfSCR += SuperColourRemoverQuantity;
                    PowerUpManagerScript.Currency -= SuperColourRemoverAmount;
                    youBoughtCanvus.SetActive(true);
                    scrUnlock.SetActive(true);
                }
                else
                {

                    Debug.Log("Insufficient funds");

                }
                break;
            // SuperShuffleAmount purchase
            case 2:
                if (PowerUpManagerScript.Currency >= SuperShuffleAmount)
                {
                    int ShufflePurchaseCount = PlayerPrefs.GetInt("SHUFFLEPURCHASE");
                    ShufflePurchaseCount++;
                    PlayerPrefs.SetInt("SHUFFLEPURCHASE", ShufflePurchaseCount);
 
                    PowerUpManagerScript.NumOfShuffles += SuperShuffleQuantity;
                    PowerUpManagerScript.Currency -= SuperShuffleAmount;
                    youBoughtCanvus.SetActive(true);
                    shuffleUnlock.SetActive(true);
                }
                else
                {

                    Debug.Log("Insufficient funds");
                }
                break;
            // SuperMultplier purchase
            case 3:
                if (PowerUpManagerScript.Currency >= SuperMultiplierAmount)
                {
                    int SMPurchaseCount = PlayerPrefs.GetInt("SMPURCHASE");
                    SMPurchaseCount++;
                    PlayerPrefs.SetInt("SMPURCHASE", SMPurchaseCount);
 
                    PowerUpManagerScript.NumOfMultilpiers += SuperMultiplierQuantity;
                    PowerUpManagerScript.Currency -= SuperMultiplierAmount;
                    youBoughtCanvus.SetActive(true);
                    multiUnlock.SetActive(true);
                }
                else
                {

                    Debug.Log("Insufficient funds");
                }
                break;
            // SuperBomb purchase
            case 4:
                if (PowerUpManagerScript.Currency >= SuperBombAmount)
                {
                    int SuperBombCount = PlayerPrefs.GetInt("BOMBPURCHASE");
                    SuperBombCount++;
                    PlayerPrefs.SetInt("BOMBPURCHASE", SuperBombCount);
 
                    PowerUpManagerScript.NumOfBombs += SuperBombQuantity;
                    //   PowerUpManagerScript.NumOfSCR += 5;

                    PowerUpManagerScript.Currency -= SuperBombAmount;
                    youBoughtCanvus.SetActive(true);
                    bombUnlock.SetActive(true);

                }
                else
                {

                    Debug.Log("Insufficient funds");
                }
                break;
            // EGG 
            case 5:
                if (!EggHatch.StartCountDown)
                {
                    if (PowerUpManagerScript.Currency >= CompanionPrice[0])
                    {
                        int EggPurchaseCount = PlayerPrefs.GetInt("EGGPURCHASE");
                        EggPurchaseCount++;
                        PlayerPrefs.SetInt("EGGPURCHASE", EggPurchaseCount);

                        EggHatchScript.GetComponent<EggHatch>().CountDownTimer();
                        PowerUpManagerScript.Currency -= CompanionPrice[0];

                        // YOU HAVE PURCHASED AN EGG UI

                        // SHOW EGG ON SCREEN 
                        youBoughtCanvus.SetActive(true);
                        eggUnlock.SetActive(true);
                        eggIncubation = true;
                        DisableEggButton();
                    }
                    else
                    {
                        Debug.Log("Insufficient funds");
                    }
                }
                else
                {
                    // TELL PLAYERS THAT EGG IS CURRENTLY BEING HATCHED
                    Debug.Log("Please wait for the egg to stop egging");

                }
                break;
            case 6:
                if (PowerUpManagerScript.Currency >= FreezeMultiplierAmount)
                {
                    //ANALYTICS
                   // int FreezeMultilpier = PlayerPrefs.GetInt("FREEZEMULTIPURCHASE");
                   // FreezeMultilpier++;
                  //  PlayerPrefs.SetInt("FREEZEMULTIPURCHASE", FreezeMultilpier);

                    PowerUpManagerScript.NumOfFreezeMultilpiers += FreezeMultplierQuantity;
                    //   PowerUpManagerScript.NumOfSCR += 5;

                    PowerUpManagerScript.Currency -= FreezeMultiplierAmount;
                    youBoughtCanvus.SetActive(true);
                    multiFreezeUnlock.SetActive(true);
 
                }
                else
                {

                    Debug.Log("Insufficient funds");
                }
                break;
        }
    }

    void DisableEggButton()
    {
        // disables the egg button and changes picture
        if (EggHatch.StartCountDown)
        {
            //   EggHatchButton.transform.GetChild(0).GetComponent<Button>().enabled = false;
            EggHatchButton.GetComponent<Image>().sprite = EggImages[1];
            EggHatchButton.GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f);
            EggHatchButton.transform.GetChild(0).GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f);

        }
        else
        {
            // EggHatchButton.transform.GetChild(0).GetComponent<Button>().enabled = true;
            EggHatchButton.GetComponent<Image>().sprite = EggImages[0];
            EggHatchButton.GetComponent<Image>().color = new Color(1, 1, 1);
            EggHatchButton.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1);

        }
    }
}
