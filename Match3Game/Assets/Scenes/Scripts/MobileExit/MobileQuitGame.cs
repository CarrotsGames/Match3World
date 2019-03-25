using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileQuitGame : MonoBehaviour {

     private GameObject RealTimerGameObj;
    private RealTimeCounter RealTimeScript;
 
    // Update is called once per frame
    // Exits the game using Android Back Button 

    private void Start()
    { 
        RealTimerGameObj = GameObject.FindGameObjectWithTag("MainCamera");
        RealTimeScript = RealTimerGameObj.GetComponent<RealTimeCounter>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }
    private void OnApplicationQuit()
    {
        RealTimeScript.ResetClock();
    }
}
