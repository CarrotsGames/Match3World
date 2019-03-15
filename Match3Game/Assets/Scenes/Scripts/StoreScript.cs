using UnityEngine;
using System.Collections;

public class StoreScript : MonoBehaviour
{

    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;

    // Use this for initialization
    void Start()
    {
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
    }

 
    public void Shop(int ButtonNumber)
    {
        switch (ButtonNumber)
        {
            case 1:
                if (PowerUpManagerScript.Currency > 85)
                {
                    PowerUpManagerScript.NumOfSCR += 5;
                    PowerUpManagerScript.Currency -= 85;
                }
                else
                {

                    Debug.Log("Insufficient funds");

                }
                break;
            case 2:
                if (PowerUpManagerScript.Currency > 85)
                {
                    PowerUpManagerScript.NumOfShuffles += 5;
                    PowerUpManagerScript.Currency -= 85;
                }
                else
                {

                    Debug.Log("Insufficient funds");
                }
                break;
            case 3:
                if (PowerUpManagerScript.Currency > 150)
                {
                    PowerUpManagerScript.NumOfShuffles += 5;
                    PowerUpManagerScript.NumOfSCR += 5;

                    PowerUpManagerScript.Currency -= 150;
                }
                else
                {

                    Debug.Log("Insufficient funds");
                }
                break;
            case 4:
           

                break;

        }
    }

}
