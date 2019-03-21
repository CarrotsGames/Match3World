using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDebug : MonoBehaviour {


    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;

    private void Start()
    {
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
    }

    // Update is called once per frame
   public void GivePowerUp ()
    {
        PowerUpManagerScript.NumOfShuffles = 10;
        PowerUpManagerScript.NumOfBombs = 10;
        PowerUpManagerScript.NumOfSCR = 10;
        PowerUpManagerScript.NumOfMultilpiers = 10;

    }
}
