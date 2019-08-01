using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
public class PurchasesAnalytics : MonoBehaviour
{

    int SCRPurchased;
    int ShufflePurchased;
    int BombPurchased;
    int SMPurchased;
    int EggPurchased;
    float Timer;
    int Currency;
    // Start is called before the first frame update
    void Start()
    {
        SCRPurchased = PlayerPrefs.GetInt("SCRPURCHASE");
        ShufflePurchased = PlayerPrefs.GetInt("SHUFFLEPURCHASE");
        BombPurchased = PlayerPrefs.GetInt("BOMBPURCHASE");
        SMPurchased = PlayerPrefs.GetInt("SMPURCHASE");
        EggPurchased = PlayerPrefs.GetInt("EGGPURCHASE");
    }

    // Update is called once per frame
    void Update()
    {
        Currency = PlayerPrefs.GetInt("CURRENCY");
        SCRPurchased = PlayerPrefs.GetInt("SCRPURCHASE");
        ShufflePurchased = PlayerPrefs.GetInt("SHUFFLEPURCHASE");
        BombPurchased = PlayerPrefs.GetInt("BOMBPURCHASE");
        SMPurchased = PlayerPrefs.GetInt("SMPURCHASE");
        EggPurchased = PlayerPrefs.GetInt("EGGPURCHASE");
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            PurchaseStats();
            Timer = 3;
        }
    }
 
    public void PurchaseStats()
    {
        if (GetComponent<PlayFabLogin>().HasLoggedIn == true)
        {
            
            PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
            {
                Data = new Dictionary<string, string>()
         {
             { "(0)TOTALGOLD","" + Currency  },
             {"(5)TIMEBOUGHT SCR ", "" +  SCRPurchased },
             {"(6)TIMEBOUGHT SHUFFLEPURCHASE ", "" + ShufflePurchased },
             {"(7)TIMEBOUGHT BOMBPURCHASE ", "" +  BombPurchased },
             {"(8)TIMEBOUGHT SMPURCHASE ", "" +  SMPurchased },
             {"(9)TIMEBOUGHT EGGPURCHASE ", "" +  EggPurchased },

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
}
