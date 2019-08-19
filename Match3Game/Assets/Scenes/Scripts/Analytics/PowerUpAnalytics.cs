using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
public class PowerUpAnalytics : MonoBehaviour
{
    int SCR;
    int Shuffle;
    int SuperBomb;
    int SuperMultlpier;
    int Currency;

 

    // Update is called once per frame
    void Update()
    {
       if(PlayFabAnalytics.DelayTime > 14)
        {
            SendAnalytics();
        }
    }
    void SendAnalytics()
    {
        Currency = PlayerPrefs.GetInt("CURRENCY");

        SCR = PlayerPrefs.GetInt("SCR");
        Shuffle = PlayerPrefs.GetInt("SHUFFLE");
        SuperBomb = PlayerPrefs.GetInt("SUPERBOMB");
        SuperMultlpier = PlayerPrefs.GetInt("SUPERMULTLPIER");
        if (GetComponent<PlayFabLogin>().HasLoggedIn == true)
        {
            PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
            {
                Data = new Dictionary<string, string>()
         {
              {"(0)TOTALGOLD","" + Currency  },
             {"(1)POWERUP: SCR","" + SCR  },
             {"(2)POWERUP: SHUFFLE","" + Shuffle  },
             {"(3)POWERUP: BOMB","" + SuperBomb  },
             {"(4)POWERUP: SM","" + SuperMultlpier  },
         }
            },
            result => Debug.Log("PUAnalyticsSent"),
            error =>
            {
                Debug.Log("Analytics not sent");
                Debug.Log(error.GenerateErrorReport());

            });
        }
    }
}
