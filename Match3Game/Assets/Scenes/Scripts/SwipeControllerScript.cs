using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControllerScript : MonoBehaviour
{
    public GameObject HappyManagerGameObj;
     

	// Update is called once per frame
	void Update ()
    {
		if(HappyManagerGameObj.GetComponent<HappinessManager>().HappinessSliderValue > 50)
        {
            HappyManagerGameObj.GetComponent<HappinessManager>().HappinessSliderValue += 10;
        }
	}
}
