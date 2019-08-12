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
    int GoldFound;

    public float Score;
    [HideInInspector]
    public string SaveScoreName;
    public float DelayTime;
    int SCR;
    int Shuffle;
    int SuperBomb;
    int SuperMultlpier;
    int Currency;
    int ComboNum;
    int BigComboNum;

    // Use this for initialization
    void Start () {
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        Test = false;
        // Tracks companion Level Time
        CompanionTime = CompanionScore.name + "TIME";
        // Tracks how much gold is found in level
        GoldFoundLevel = CompanionScore.name + "GoldTrack";
        GoldFound = PlayerPrefs.GetInt(GoldFoundLevel);
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
        DelayTime += Time.deltaTime;
        if (DelayTime > 15)
        {
            SetUserData();
            TrackedGold();
             DelayTime = 0;
        }
        // Test = false;
         
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
       ComboNum = PlayerPrefs.GetInt(SaveScoreName + "COMBONUM");
       BigComboNum = PlayerPrefs.GetInt(SaveScoreName + "BIGCOMBONUM");
        
    }

    void SetUserData()
    {
        if (GetComponent<PlayFabLogin>().HasLoggedIn == true)
        {
            PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
            {
                Data = new Dictionary<string, string>()
         {
             {CompanionScore.name,"SCORE: "+  Score },
             {CompanionTime,"" + TimeOnScene },
             {GoldFoundLevel,"" + GoldFound },

             {"(0)TOTALGOLD","" + Currency  },
             {"(1)POWERUP: SCR","" + SCR  },
             {"(2)POWERUP: SHUFFLE","" + Shuffle  },
             {"(3)POWERUP: BOMB","" + SuperBomb  },
             {"(4)POWERUP: SM","" + SuperMultlpier  },
             {CompanionScore.name +  "COMBONUM", "" + ComboNum },
             {CompanionScore.name + "BIGCOMBONUM", "" + BigComboNum }

         }
            },
            result => Debug.Log("AnalyticsSent"),
            error =>
            {
                Debug.Log("Got error setting user data Ancestory to Jacob");
                Debug.Log(error.GenerateErrorReport());

            });
        }
    }
//
  public void TrackedGold()
  {
      PlayFabClientAPI.WritePlayerEvent(new WriteClientPlayerEventRequest()
      {
          Body = new Dictionary<string, object>() {
           {"(0)TOTALGOLD","" + Currency  },
        
     },
          EventName = "CHECKGOLD"
      },
      result => SentOutAnalytics(), //ANALYTICS RESULTS,
  
  
      error => Debug.LogError(error.GenerateErrorReport()));
  }
    public void GraphedData()
    {
        PlayFabClientAPI.WritePlayerEvent(new WriteClientPlayerEventRequest()
        {
            Body = new Dictionary<string, object>() {
        { CompanionScore.name, Score },
        { CompanionTime, "" + TimeOnScene },


    },
            EventName = "TestPlayer_Progression"
        },
        result => SentOutAnalytics(), //ANALYTICS RESULTS,


        error => Debug.LogError(error.GenerateErrorReport()));
    }

    void SentOutAnalytics( )
    {
        // Anayltics sent out
    }
    // void GetUserData()
    // {
    //     PlayFabClientAPI.GetUserData(new GetUserDataRequest()
    //     {
    //         PlayFabId = "This is an ID?",
    //         Keys = null
    //     }, result => {
    //         Debug.Log("Got user data:");
    //         if (result.Data == null || !result.Data.ContainsKey("Ancestor")) Debug.Log("No Ancestor");
    //         else Debug.Log("Ancestor: " + result.Data["Ancestor"].Value);
    //     }, (error) => {
    //         Debug.Log("Got error retrieving user data:");
    //         Debug.Log(error.GenerateErrorReport());
    //     });
    // }

}

 
