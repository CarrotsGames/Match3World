using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PowerUpManager : MonoBehaviour
{
    public int NumOfShuffles;
    public int NumOfSCR;
    public int NumOfBombs;
    public int NumOfMultilpiers;
 
    public GameObject OutOfItemCanvas;
    public GameObject OutOfSCR;
    public GameObject OutOfBombs;
    public GameObject OutOfShuffle;
    public GameObject OutOfMultlpier;
    public GameObject OutOfCoins;

    public int Currency;
    private int FirstTimeLogin;

    public bool HasShuffles;
    public bool HasSCR;
    public bool HasBombs;
    public bool HasMultlpliers;
    public bool HasFreezeMultlpliers;

    public Text NumOfShufflesText;
    public Text NumOfSCRText;
    public Text NumOfBombsText;
    public Text NumOfSMText;
 
    public Text CurrencyText;
    // Use this for initialization
    void Start()
    {
        Currency = PlayerPrefs.GetInt("CURRENCY");

        FirstTimeLogin = 0;
        FirstTimeLogin = PlayerPrefs.GetInt("FirstTime");
        NumOfShuffles = 5;
        NumOfSCR = 5;
        NumOfBombs = 5;
        NumOfMultilpiers = 5;
 
        if (FirstTimeLogin > 0)
        {
            NumOfShuffles = PlayerPrefs.GetInt("NUMSHUFFLE");
            NumOfSCR = PlayerPrefs.GetInt("NUMSRC");
            NumOfBombs = PlayerPrefs.GetInt("NUMBOMB");
            NumOfMultilpiers = PlayerPrefs.GetInt("NUMSM");
 
        }
        FirstTimeLogin += 1;
        PlayerPrefs.SetInt("FirstTime", FirstTimeLogin);


        HasShuffles = false;
        HasSCR = false;
        HasBombs = false;
        PowerUpChecker();
        PowerUpSaves();
    }

 
    public void PowerUpSaves()
    {
        PlayerPrefs.SetInt("NUMSHUFFLE", NumOfShuffles);
        PlayerPrefs.SetInt("NUMSRC", NumOfSCR);
        PlayerPrefs.SetInt("NUMBOMB", NumOfBombs);
        PlayerPrefs.SetInt("NUMSM", NumOfMultilpiers);
         PlayerPrefs.SetInt("CURRENCY", Currency);
        CurrencyText.text = " " + Currency;
        NumOfShufflesText.text = "" + NumOfShuffles;
        NumOfSCRText.text = "" + NumOfSCR;
        NumOfBombsText.text = "" + NumOfBombs;
        NumOfSMText.text = "" + NumOfMultilpiers;
     }
    public void PowerUpChecker()
    {        
        if (NumOfShuffles > 0)
        {
            HasShuffles = true;
        }
        else
        {
            HasShuffles = false;
        }

        if (NumOfSCR > 0)
        {
            HasSCR = true;
        }
        else
        {
            HasSCR = false;
        }

        if (NumOfBombs > 0)
        {
            HasBombs = true;
        }
        else
        {
            HasBombs = false;
        }
        if (NumOfMultilpiers > 0)
        {
            HasMultlpliers = true;
        }
        else
        {
            HasMultlpliers = false;
        }
    
    }
    public void PowerUpEmpty(string PowerUpName)
    {
        PowerUpSaves();
        OutOfItemCanvas.SetActive(true);
        switch (PowerUpName)
        {
            case "SCR":
                {
                    if (Currency > StoreScript.SuperColourRemoverAmount)
                    {
                        Debug.Log("Out of SCR Buy more??");
                        OutOfSCR.SetActive(true);
                        // YOU ARE OUT OF ME 
                        // BUY MORE OF ME?
                    }
                    else
                    {
                        // IF NO CLOSE UI
                        OutOfCoins.SetActive(true);
                        OutOfItemCanvas.SetActive(false);

                    }
                }
                break;
            case "Shuffle":
                {
                    if (Currency > StoreScript.SuperShuffleAmount)
                    {
                        OutOfShuffle.SetActive(true);
                    }
                    else
                    {
                        OutOfCoins.SetActive(true);
                        OutOfItemCanvas.SetActive(false);

                        Debug.Log("NEED MORE CASHHHHH");
                    }
                }
                break;
            case "BOMB":
                {
                    if (Currency > StoreScript.SuperBombAmount)
                    {
                        OutOfBombs.SetActive(true);
                    }
                    else
                    {
                        OutOfCoins.SetActive(true);
                        OutOfItemCanvas.SetActive(false);

                        Debug.Log("Sorry sir or madam but it appears you are low on funds. Would you care to aquire more?.");

                    }
                }
                break;
            case "SM":
                {
                    if (Currency > StoreScript.SuperShuffleAmount)
                    {
                        OutOfMultlpier.SetActive(true);
                    }
                    else
                    {
                        OutOfCoins.SetActive(true);
                        OutOfItemCanvas.SetActive(false);
                        Debug.Log("NEED MORE CASHHHHH");
                    }
                }
                break;
        }
        // TELL PLAYER POWER UP IS EMPTY

        // ASK PLAYER TO GO TO STORE

        // BRING UP STORE
    }
  
}
