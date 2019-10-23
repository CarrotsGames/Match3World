using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuyEgg : MonoBehaviour
{
    public int Amount;
    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;
    // Refrences the EggHatchScript
    public GameObject EggHatchScript;
    public GameObject youBoughtCanvus;
    public GameObject eggUnlock;
    public bool eggIncubation;
    public GameObject CreatureEggs;
    public GameObject[] EggButtons;

 
    private void FixedUpdate()
    {
        if (PlayFabLogin.HasLoggedIn == true)
        {
            if (EggHatch.StartCountDown)
            {
                if (this.gameObject.name == "BuyEggButton")
                {
                    GetComponent<Button>().enabled = false;
                    gameObject.SetActive(false);
                }
                GetComponent<Image>().color = new Color(1, 0, 0);
                GetComponent<Button>().enabled = false;
            }
            else
            {
                GetComponent<Image>().color = new Color(1, 1, 1);
                GetComponent<Button>().enabled = true;
                gameObject.SetActive(true);
            }
        }
        else
        {
            GetComponent<Button>().enabled = false;
            GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f);
            transform.GetChild(0).GetComponent<Text>().text = "Offline";
        }
    }
    public void PurchaseEgg()
    {
       
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
        if (PowerUpManagerScript.Currency >= Amount)
        {
            CreatureEggs.SetActive(true);
            int EggPurchaseCount = PlayerPrefs.GetInt("EGGPURCHASE");
            EggPurchaseCount++;
            PlayerPrefs.SetInt("EGGPURCHASE", EggPurchaseCount);

            EggHatchScript.GetComponent<EggHatch>().CountDownTimer();
            PowerUpManagerScript.Currency -= Amount;
            PowerUpManagerScript.PowerUpSaves();
            // YOU HAVE PURCHASED AN EGG UI

            // SHOW EGG ON SCREEN 
            youBoughtCanvus.SetActive(true);
            eggUnlock.SetActive(true);
            eggIncubation = true;
        }
    }
 
}
