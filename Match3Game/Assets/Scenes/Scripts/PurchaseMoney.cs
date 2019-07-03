using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseMoney : MonoBehaviour {

    public PowerUpManager PowerUpManagerGameObj;
   
    public void GrantGold(int Gold)
    {
        PowerUpManagerGameObj.GetComponent<PowerUpManager>().Currency += Gold;
        Debug.Log("You have recieved" + Gold + "Gold!!!");
    }
    public void GrantBundle(int Gold)
    {
        PowerUpManagerGameObj.GetComponent<PowerUpManager>().Currency += Gold;
        // Bombs
        PowerUpManagerGameObj.GetComponent<PowerUpManager>().NumOfBombs += 1;
        //Super Colour Remover
        PowerUpManagerGameObj.GetComponent<PowerUpManager>().NumOfSCR += 1;
        //Super Shuffle
        PowerUpManagerGameObj.GetComponent<PowerUpManager>().NumOfShuffles += 1;
        //Super Multlpier
        PowerUpManagerGameObj.GetComponent<PowerUpManager>().NumOfMultilpiers += 1;
        Debug.Log("You have recieved" + Gold + "Gold!!! " +
            "\n You have receiced PowerUps ");

    }
    public void GrantSuperBundle(int Gold)
    {
        PowerUpManagerGameObj.GetComponent<PowerUpManager>().Currency += Gold;
        // Bombs
        PowerUpManagerGameObj.GetComponent<PowerUpManager>().NumOfBombs += 10;
        //Super Colour Remover
        PowerUpManagerGameObj.GetComponent<PowerUpManager>().NumOfSCR += 10;
        //Super Shuffle
        PowerUpManagerGameObj.GetComponent<PowerUpManager>().NumOfShuffles += 10;
        //Super Multlpier
        PowerUpManagerGameObj.GetComponent<PowerUpManager>().NumOfMultilpiers += 10;
        Debug.Log("You have recieved" + Gold + "Gold!!! " +
            "\n You have receiced PowerUps ");

    }
}
