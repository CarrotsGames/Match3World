using UnityEngine;
using System.Collections;

public class StoreScript : MonoBehaviour
{

    private GameObject PowerUpManGameObj;
    private PowerUpManager PowerUpManagerScript;
    public UnlockableCreatures UnlockScript;
    public int SuperColourRemoverQuantity;
    public int SuperShuffleQuantity;
    public int SuperBombQuantity;
    public int SuperMultiplierQuantity;
    
    public int SuperColourRemoverAmount;
    public int SuperShuffleAmount;
    public int SuperBombAmount;
    public int SuperMultiplierAmount;

    private void Start()
    {
        PowerUpManGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManGameObj.GetComponent<PowerUpManager>();
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
