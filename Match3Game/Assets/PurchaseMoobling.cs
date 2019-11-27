using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseMoobling : MonoBehaviour
{
     private GameObject Unlockables;
    private void Start()
    {
        Unlockables = GameObject.Find("UNLOCKABLESMain");
    }
   public void BuyMoobling (string Moobling)
    {
        // Add purchase script to IAP on purchase complete area
        // Look at unlockableCreatures script for naming convetion for that moobling
        
        Unlockables = GameObject.Find("UNLOCKABLESMain");
        PlayerPrefs.SetString("UNLOCKED", Moobling);   
        Unlockables.GetComponent<UnlockableCreatures>().Unlock();
        Debug.Log("Purchased moobling");
        
    }
}
