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
        
        Unlockables = GameObject.Find("UNLOCKABLESMain");
        PlayerPrefs.SetString("UNLOCKED", Moobling);   
        Unlockables.GetComponent<UnlockableCreatures>().Unlock();
        Debug.Log("Purchased moobling");
        
    }
}
