using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickBuy : MonoBehaviour
{
    PowerUpManager PowerUpManagerScript;
    GameObject PowerUpManagerGameObj;
 

   public void SCRPurchase()
    {
        PowerUpManagerGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManagerGameObj.GetComponent<PowerUpManager>();

        PowerUpManagerScript.Currency -= 85;
        PowerUpManagerScript.NumOfSCR += 5;
        PowerUpManagerScript.OutOfSCR.SetActive(false);
        PowerUpManagerScript.OutOfItemCanvas.SetActive(false);
        PowerUpManagerScript.PowerUpSaves();
    }
    public void ShufflePurchase()
    {
        PowerUpManagerGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManagerGameObj.GetComponent<PowerUpManager>();

        PowerUpManagerScript.Currency -= 85;
        PowerUpManagerScript.NumOfShuffles += 5;
        PowerUpManagerScript.OutOfShuffle.SetActive(false);
        PowerUpManagerScript.OutOfItemCanvas.SetActive(false);
        PowerUpManagerScript.PowerUpSaves();
    }
    public void SuperBombPurchase()
    {
        PowerUpManagerGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManagerGameObj.GetComponent<PowerUpManager>();

        PowerUpManagerScript.Currency -= 85;
        PowerUpManagerScript.NumOfBombs += 5;
        PowerUpManagerScript.OutOfBombs.SetActive(false);
        PowerUpManagerScript.OutOfItemCanvas.SetActive(false);
        PowerUpManagerScript.PowerUpSaves();
    }
    public void SuperMultiplierPurchase()
    {
        PowerUpManagerGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManagerGameObj.GetComponent<PowerUpManager>();

        PowerUpManagerScript.Currency -= 85;
        PowerUpManagerScript.NumOfMultilpiers += 5;
        PowerUpManagerScript.OutOfMultlpier.SetActive(false);
        PowerUpManagerScript.OutOfItemCanvas.SetActive(false);
        PowerUpManagerScript.PowerUpSaves();
    }
}
