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
    public int NumOfFreezeMultilpiers;

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
    public Text NumOfFMText;

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
        NumOfFreezeMultilpiers = 5;

        if (FirstTimeLogin > 0)
        {
            NumOfShuffles = PlayerPrefs.GetInt("NUMSHUFFLE");
            NumOfSCR = PlayerPrefs.GetInt("NUMSRC");
            NumOfBombs = PlayerPrefs.GetInt("NUMBOMB");
            NumOfMultilpiers = PlayerPrefs.GetInt("NUMSM");
            NumOfFreezeMultilpiers = PlayerPrefs.GetInt("NUMFREEZE");

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
        PlayerPrefs.SetInt("NUMFREEZE", NumOfFreezeMultilpiers);
        PlayerPrefs.SetInt("CURRENCY", Currency);
        CurrencyText.text = " " + Currency;
        NumOfShufflesText.text = "" + NumOfShuffles;
        NumOfSCRText.text = "" + NumOfSCR;
        NumOfBombsText.text = "" + NumOfBombs;
        NumOfSMText.text = "" + NumOfMultilpiers;
        NumOfFMText.text = "" + NumOfFreezeMultilpiers;
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
        if (NumOfFreezeMultilpiers > 0)
        {
            HasFreezeMultlpliers = true;
        }
        else
        {
            HasFreezeMultlpliers = false;
        }
    }
    public void PowerUpEmpty(string PowerUpName)
    {
        switch(PowerUpName)
        {
            case "SCR":
                {
                    if (Currency > StoreScript.SuperColourRemoverAmount)
                    {
                        Debug.Log("Out of SCR Buy more??");

                        // YOU ARE OUT OF ME 
                        // BUY MORE OF ME?
                    }
                    else
                    {
                        Debug.Log("You got no cash boy and im owed 7k");
                        // IF NO CLOSE UI
                    }
                }
                break;
            case "Shuffle":
                {
                    if (Currency > StoreScript.SuperShuffleAmount)
                    {
                        Debug.Log("Out of SHUFFLE");
                    }
                    else
                    {
                        Debug.Log("NEED MORE CASHHHHH");
                    }
                }
                break;
            case "BOMB":
                {
                    if (Currency > StoreScript.SuperBombAmount)
                    {
                        Debug.Log("Out of BOMB");
                    }
                    else
                    {
                        Debug.Log("Sorry sir or madam but it appears you are low on funds. Would you care to aquire more?.");

                    }
                }
                break;
        }
        // TELL PLAYER POWER UP IS EMPTY

        // ASK PLAYER TO GO TO STORE

        // BRING UP STORE
    }
  
}
