using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyIncrease : MonoBehaviour
{
    public HappinessManager HappinessManagerScript;
    private GameObject HappinessGameObj;

    // Start is called before the first frame update
    void Start()
    {

        HappinessGameObj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessGameObj.GetComponent<HappinessManager>();
    }

    // Update is called once per frame
   public void IncreaseHappy()
    {
        HappinessManagerScript.HappinessSliderValue = 90;
    }
}
