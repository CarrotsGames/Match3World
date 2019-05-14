using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailySpinArrow : MonoBehaviour
{
     public GameObject DailySpinWheel;
     private DailySpin DailySpinScript;
    public GameObject PowerUpManagerGameObj;
    private PowerUpManager PowerUpManagerScript;
    private string Colour;

    // Use this for initialization
    void Start()
    {
        PowerUpManagerGameObj = GameObject.FindGameObjectWithTag("PUM");
        PowerUpManagerScript = PowerUpManagerGameObj.GetComponent<PowerUpManager>();
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
                    PowerUpManagerScript.NumOfSCR += 5;
                    Debug.Log("BLUE");
                    break;
                case "Red":
                    Debug.Log("RED");
                    PowerUpManagerScript.NumOfBombs += 2;
                    break;
                case "Green":
                    PowerUpManagerScript.Currency += 25;
                    Debug.Log("GREEN");
                    break;
                case "Yellow":
                    PowerUpManagerScript.Currency += 100;
                    Debug.Log("YELLOW");
                    break;
                case "Purple":
                    PowerUpManagerScript.NumOfSCR += 2;
                    Debug.Log("PURPLE");
                    break;
                case "PurpleGrad":
                    PowerUpManagerScript.NumOfMultilpiers += 5;
                    Debug.Log("PURPLEGRAD");
                    break;
                case "LightBlue":
                    Debug.Log("LIGHTBLUE");
                    PowerUpManagerScript.NumOfMultilpiers += 1;
                    break;
                case "White":
                    PowerUpManagerScript.NumOfShuffles += 5;
                    Debug.Log("WHITE");
                    break;
                case "Orange":
                    PowerUpManagerScript.NumOfShuffles += 2;
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