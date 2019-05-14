using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailySpinArrow : MonoBehaviour
{
     public GameObject DailySpinWheel;
     private DailySpin DailySpinScript;
     private string Colour;

    // Use this for initialization
    void Start()
    {
        DailySpinScript = DailySpinWheel.GetComponent<DailySpin>();
    }

 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (DailySpinScript.IsDailyOver)
        {

            Colour = collision.gameObject.tag ;
            switch (Colour)
            {
                case "Blue":
                    Debug.Log("BLUE");
                    break;
                case "Red":
                    Debug.Log("RED");
                    break;
                case "Green":
                    Debug.Log("GREEN");
                    break;
                case "Yellow":
                    Debug.Log("YELLOW");
                    break;
                case "Purple":
                    Debug.Log("PURPLE");
                    break;
                case "PurpleGrad":
                    Debug.Log("PURPLEGRAD");
                    break;
                case "LightBlue":
                    Debug.Log("LIGHTBLUE");
                    break;
                case "White":
                    Debug.Log("WHITE");
                    break;
                case "Orange":
                    Debug.Log("ORANGE");
                    break;

            }
            DailySpinScript.TimeToStopWheel = DailySpinScript.TimeToStopWheelStore;
            DailySpinScript.DailyEvent.CanDoDaily = false;
            PlayerPrefs.SetInt(DailySpinScript.Events.GetComponent<PlayFabServerTime>().SaveBool, (DailySpinScript.DailyEvent.CanDoDaily ? 1 : 0));

            DailySpinScript.DailyEvent.DailySpinner.SetActive(false);

            DailySpinScript.IsDailyOver = false;
            DailySpinScript.StopSpinning = false;
        }
    }
}