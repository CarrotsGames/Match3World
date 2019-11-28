using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RedeemCode : MonoBehaviour
{
    public int Gold;
    public string SpecialCode;
    private GameObject PowerUpManagerGameObj;
    private bool RedeemedCode = false;
    public InputField Code;


    public void RedemptionCode()
    {
        RedeemedCode = (PlayerPrefs.GetInt("CodeRedeemed1") != 0);
        
        if (Code.text == SpecialCode && !RedeemedCode)
        {
            PowerUpManagerGameObj = GameObject.FindGameObjectWithTag("PUM");
            PowerUpManagerGameObj.GetComponent<PowerUpManager>().Currency += Gold;
            PowerUpManagerGameObj.GetComponent<PowerUpManager>().PowerUpSaves();
            RedeemedCode = true;
            PlayerPrefs.SetInt("CodeRedeemed1", (RedeemedCode ? 1 : 0));
        }  
        else if (Code.text != SpecialCode)
        {
            Debug.Log("Invalid code");

        }
        else if (RedeemedCode)
        {
            Debug.Log("code Redeemed");
        }
    }

}
