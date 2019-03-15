using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour
{
    public int NumOfShuffles;
    public int NumOfSCR;
    int FirstTimeLogin;
    public bool HasShuffles;
    public bool HasSCR;
    // Use this for initialization
    void Start()
    {
        FirstTimeLogin = 0;
        FirstTimeLogin = PlayerPrefs.GetInt("FirstTime");
        NumOfShuffles = 5;
        NumOfSCR = 5;
        if (FirstTimeLogin > 0)
        {
            NumOfShuffles = PlayerPrefs.GetInt("NUMSHUFFLE");
            NumOfSCR = PlayerPrefs.GetInt("NUMSRC");
        }
        FirstTimeLogin += 1;
        PlayerPrefs.SetInt("FirstTime", FirstTimeLogin);


        HasShuffles = false;
        HasSCR = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("NUMSHUFFLE", NumOfShuffles);
        PlayerPrefs.SetInt("NUMSRC", NumOfSCR);
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
    }

    public void PowerUpEmpty()
    {
        // TELL PLAYER POWER UP IS EMPTY

        // ASK PLAYER TO GO TO STORE

        // BRING UP STORE
    }
}
