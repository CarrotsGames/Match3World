using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyMultlpier : MonoBehaviour {

    private float Timer;
    // Must cap at 4
    public int[] multiplier;
    // Determines what multplier the player is on
    public int MultlpierNum;
    public bool ResetTheMultlpier;
    private GameObject DotManagerObj; 
    private DotManager DotManagerScript;
    private GameObject RealTimeGameObj;
    [HideInInspector]
    public RealTimeCounter RealtTimeScript;
    private string[] SaveStrings = { "GOBUSAVE", "BINKYSAVE", "KOKOSAVE", "CRIUSSAVE" ,"SAUCOSAVE", "CHICKPEASAVE" , "SQUISHYSAVE" , "CRONOSSAVE" , "OKAMISAVE" };
    private List<string> ListOfSaves;
    int AddNewNum;
    private bool TrackMultlpier;
    // Use this for initialization
    void Start ()
    {
        RealTimeGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealtTimeScript = RealTimeGameObj.GetComponent<RealTimeCounter>();
        ListOfSaves = new List<string>();
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        TrackMultlpier = false;
        for (int i = 0; i < SaveStrings.Length; i++)
        {
            ListOfSaves.Add(SaveStrings[i]);
        }
        CheckMultplier();
        Multplier();
    }
 
     // Update is called once per frame
    void Update ()
    {
        MultlpierNum = PlayerPrefs.GetInt("Multiplier");

        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            CheckMultplier();
            Timer += 3;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            CheckMultplier();
        }
        if (ResetTheMultlpier)
        {
            MultlpierNum = 1;
            PlayerPrefs.SetInt("Multiplier", MultlpierNum);
            ResetTheMultlpier = false;
        }
    }
    public void CheckMultplier()
    {
        RealTimeGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealtTimeScript = RealTimeGameObj.GetComponent<RealTimeCounter>();
        TrackMultlpier  = PlayerPrefs.GetInt("FreezeMultlpier") != 0;
        if (!TrackMultlpier)
        {
            for (int i = 0; i < RealTimeGameObj.GetComponent<RealTimeCounter>().HappinessCountDown.Length; i++)
            {
                bool IsSleeping = false;
                if (ListOfSaves.Count > i)
                {
                    IsSleeping = (PlayerPrefs.GetInt(ListOfSaves[i]) != 0);
                }

                if (RealtTimeScript.GetComponent<RealTimeCounter>().HappinessCountDown[i] < 20 && IsSleeping)
                {
                    IsSleeping = false;
                    PlayerPrefs.SetInt(ListOfSaves[i], (IsSleeping ? 1 : 0));

                }
                else if (RealtTimeScript.GetComponent<RealTimeCounter>().HappinessCountDown[i] > 20 && IsSleeping)
                {

                    PlayerPrefs.SetInt(ListOfSaves[i], (IsSleeping ? 1 : 0));

                    AddNewNum += 1;
                }
                // if this creature is not sleeping but greater than 95 
                // then set that companion to sleeping 
                else if (!GetComponent<HappinessManager>().IsSleeping)
                {
                    if (RealtTimeScript.GetComponent<RealTimeCounter>().HappinessCountDown[i] >= 95)
                    {

                        PlayerPrefs.SetInt(GetComponent<HappinessManager>().SaveStrings, (GetComponent<HappinessManager>().IsSleeping ? 1 : 0));

                        AddNewNum += 1;
                    }
                }

                if (MultlpierNum < 0 || MultlpierNum > 10)
                {
                    MultlpierNum = 1;
                }
            }
            MultlpierNum = AddNewNum;
            AddNewNum = 0;
            PlayerPrefs.SetInt("Multiplier", MultlpierNum);

            Multplier();

        }
    
    }
    // Multlpier of companions
    public void Multplier()
    {
      

        // Number of multlpier matches number of creatures in game (10 creatures MAX at the moment
        switch (MultlpierNum)
        {
            case 0:
                DotManagerScript.Multipier = multiplier[0];
                PlayerPrefs.SetInt("SavedMultlpier", multiplier[0]);
                break;
            case 1:
                DotManagerScript.Multipier = multiplier[1];
                PlayerPrefs.SetInt("SavedMultlpier", multiplier[1]);

                break;
            case 2:
                DotManagerScript.Multipier = multiplier[2];
                PlayerPrefs.SetInt("SavedMultlpier", multiplier[2]);

                break;
            case 3:
                DotManagerScript.Multipier = multiplier[3];
                PlayerPrefs.SetInt("SavedMultlpier", multiplier[3]);

                break;
            case 4:
                DotManagerScript.Multipier = multiplier[4];
                PlayerPrefs.SetInt("SavedMultlpier", multiplier[4]);

                break;
            case 5:
                DotManagerScript.Multipier = multiplier[5];
                PlayerPrefs.SetInt("SavedMultlpier", multiplier[5]);

                break;
            case 6:
                DotManagerScript.Multipier = multiplier[6];
                PlayerPrefs.SetInt("SavedMultlpier", multiplier[6]);

                break;
            case 7:
                DotManagerScript.Multipier = multiplier[7];
                PlayerPrefs.SetInt("SavedMultlpier", multiplier[7]);

                break;
            case 8:
                DotManagerScript.Multipier = multiplier[8];
                PlayerPrefs.SetInt("SavedMultlpier", multiplier[8]);

                break;
        }
    }
}
