using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
public class ResetProgress : MonoBehaviour {

    public bool Reset;
    public GameObject NodeManager;
    public GameObject Unlockables;
    public GameObject PowerUpManGameObj;

    // Use this for initialization
    void Start () {
        Reset = false;

    }
    private void Update()
    {
         if (Reset)
        {
            Debug.Log("RESET");
         
            // resets score
            NodeManager.GetComponent<DotManager>().TotalScore = 0;
       
            // Resets analytics 
            PlayerPrefs.SetString("BINKY", "Nothing");
            PlayerPrefs.SetString("KOKO", "Nothing");
            PlayerPrefs.SetString("CRIUS", "Nothing");
            PlayerPrefs.SetString("UNLOCKED", "Nothing");
            PlayerPrefs.SetFloat("GOBUSCORETRACK", 0);
            PlayerPrefs.SetFloat("BINKYSCORETRACK", 0);
            PlayerPrefs.SetFloat("KOKOSCORETRACK", 0);
            PlayerPrefs.SetFloat("CRIUSSCORETRACK", 0);
           
            // resets powerups
            PowerUpManGameObj.GetComponent<PowerUpManager>().NumOfShuffles = 5;
            PowerUpManGameObj.GetComponent<PowerUpManager>().NumOfBombs = 5;
            PowerUpManGameObj.GetComponent<PowerUpManager>().NumOfSCR = 5;
            PowerUpManGameObj.GetComponent<PowerUpManager>().NumOfMultilpiers = 5;
            PowerUpManGameObj.GetComponent<PowerUpManager>().Currency = 0;

            PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
            {
                Data = new Dictionary<string, string>()
            {
                { "Gobu"   ,"SCORE: "+  0 },
                { "Binky"   ,"SCORE: "+  0 },
                { "Koko"   ,"SCORE: "+  0 },
                { "Crius"   ,"SCORE: "+  0 },
                { "BinkyTIME"   ,"" + 0},
                { "CriusTIME"   ,"" + 0},
                { "GobuTIME"   ,"" + 0},
                { "KokoTIME"   , "" + 0 }
            },
         
            },
      result => Debug.Log("Analytics Sent"),
      error =>
      {
          Debug.Log("Got error setting user data Ancestory to Jacob");
          Debug.Log(error.GenerateErrorReport());

      });
        }
    }
    // Update is called once per frame
    public void ResetData ()
    {
        Reset = true;
    }
}
