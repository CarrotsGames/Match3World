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
    public float Score;
    private string SaveScoreName;
    public float DelayTime;
    // Use this for initialization
    void Start () {
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        Test = false;
        CompanionTime = CompanionScore.name + "TIME";
        TimeOnScene = PlayerPrefs.GetFloat(CompanionTime);
        switch (CompanionScore.name)
        {
            case "Gobu":
            {
                    SaveScoreName = "GOBUSCORETRACK";
                    DotManagerScript.SceneScore = PlayerPrefs.GetFloat(SaveScoreName);
            }
            break;
            case "Binky":
                {
                    SaveScoreName = "BINKYSCORETRACK";
                    DotManagerScript.SceneScore = PlayerPrefs.GetFloat(SaveScoreName);

                }
                break;
            case "Koko":
                {
                    SaveScoreName = "KOKOSCORETRACK";
                    DotManagerScript.SceneScore = PlayerPrefs.GetFloat(SaveScoreName);

                }
                break;
            case "Crius":
                {
                    SaveScoreName = "CRIUSSCORETRACK";
                    DotManagerScript.SceneScore = PlayerPrefs.GetFloat(SaveScoreName);

                }
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        TimeOnScene += Time.deltaTime;
        DelayTime += Time.deltaTime;
        if (DelayTime > 5)
        {
            SetUserData();
            DelayTime = 0;
        }
        // Test = false;
         
      Score = DotManagerScript.SceneScore;
       PlayerPrefs.SetFloat(SaveScoreName, Score);
       PlayerPrefs.SetFloat(CompanionTime, TimeOnScene);

    }

    void SetUserData()
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
          Data = new Dictionary<string, string>()
         {
             {CompanionScore.name,"SCORE: "+  Score },
             {CompanionTime,"" + TimeOnScene }
         }
        },
        result => Debug.Log("Damn"),
        error =>
        {
            Debug.Log("Got error setting user data Ancestory to Jacob");
            Debug.Log(error.GenerateErrorReport());

        });
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

 
