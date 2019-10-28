using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabAnalytics : MonoBehaviour {

    public bool Test;
    private DotManager DotManagerScript;
    private GameObject DotManagerObj;
    public float TimeOnScene;
    public GameObject CompanionScore;
    private string CompanionTime;
    private string GoldFoundLevel;
    private string CompanionLevel;
    private GameObject HappinessManagerGameObj;
    private HappinessManager HappinessManagerScript;
    int GoldFound;

    public float Score;
    [HideInInspector]
    public string SaveScoreName;
    public static float DelayTime;
    int SCR;
    int Shuffle;
    int SuperBomb;
    int SuperMultlpier;
    int Currency;
    int ComboNum;
    int BigComboNum;

    // Use this for initialization
    void Start () {
        HappinessManagerGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessManagerGameObj.GetComponent<HappinessManager>();
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        Test = false;
        // Tracks companion Level Time
        CompanionLevel = CompanionScore.name + "Level";
        CompanionTime = CompanionScore.name + "TIME";
        //// Tracks how much gold is found in level
        //GoldFoundLevel = CompanionScore.name + "GoldTrack";
        //GoldFound = PlayerPrefs.GetInt(GoldFoundLevel);
        DotManagerScript.GoldScore = GoldFound;
        TimeOnScene = PlayerPrefs.GetFloat(CompanionTime);
        // Tracks companion Level Score
        SaveScoreName = CompanionScore.name + "TRACK";
        Score = PlayerPrefs.GetFloat(SaveScoreName);
        DotManagerScript.SceneScore = Score;
     
    }
	
	// Update is called once per frame
	 void Update () {
     
         TimeOnScene += Time.deltaTime;
       // DelayTime += Time.deltaTime;
       // if (DelayTime > 20)
       // {
       //     SetUserData();
       //     TrackedGold();
       //      DelayTime = 0;
       // }
         // Test = false;
          
      
         
     }

    public void SetUserData()
    {
        
        Score = DotManagerScript.SceneScore;
        GoldFound = DotManagerScript.GoldScore;
        PlayerPrefs.SetFloat(SaveScoreName, Score);
        PlayerPrefs.SetFloat(CompanionTime, TimeOnScene);
        PlayerPrefs.SetInt(GoldFoundLevel, GoldFound);

        SCR = PlayerPrefs.GetInt("SCR");
        Shuffle = PlayerPrefs.GetInt("SHUFFLE");
        SuperBomb = PlayerPrefs.GetInt("SUPERBOMB");
        SuperMultlpier = PlayerPrefs.GetInt("SUPERMULTLPIER");
        Currency = PlayerPrefs.GetInt("CURRENCY");
       // ComboNum = PlayerPrefs.GetInt(SaveScoreName + "COMBONUM");
       // BigComboNum = PlayerPrefs.GetInt(SaveScoreName + "BIGCOMBONUM");
        if (PlayFabLogin.HasLoggedIn == true)
        {
            PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
            {
                Data = new Dictionary<string, string>()
         {
             {CompanionScore.name,"SCORE: "+  Score },
             {CompanionTime,"" + TimeOnScene },
          
             { CompanionLevel , "" + HappinessManagerScript.Level }

         }
            },
            result => Debug.Log("AnalyticsSent"),
            error =>
            {
                Debug.Log("Analytics not sent");
                Debug.Log(error.GenerateErrorReport());

            });
        }
    }
//
  public void PushAnalytics()
  {
        // Gets moobling data
        GetComponent<PlayFabAnalytics>().SetUserData();
        //Sends gold amount and powerups used
        GetComponent<PowerUpAnalytics>().SendAnalytics();
        //Sends gold amount and powerups used
        GetComponent<PlayFabLogin>().TournamentScore();
        //Checks if theyres any money coming in
        GetComponent<PlayFabCurrency>().GetCurrency();
    }
    
}

 
