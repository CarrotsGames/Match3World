using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailySpinArrow : MonoBehaviour
{
    public GameObject DailySpinWheel;
    private DailySpin DailySpinScript;
    private GameObject PowerUpManagerGameObj;
    private PowerUpManager PowerUpManagerScript;
    private string Colour;

    //Congratulation Message Colours
    public GameObject orangeCongrats;
    public GameObject purpleCongrats;
    public GameObject redCongrats;
    public GameObject lightBlueCongrats;
    public GameObject yellowGradientCongrats;
    public GameObject greenCongrats;
    public GameObject darkBlueCongrats;
    public GameObject whiteCongrats;
    public GameObject purpleGrandiantCongrats;
    public GameObject congratsMessage;



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

            Colour = collision.gameObject.tag;
            congratsMessage.SetActive(true);
            purpleCongrats.SetActive(false);
            purpleGrandiantCongrats.SetActive(false);
            orangeCongrats.SetActive(false);
            darkBlueCongrats.SetActive(false);
            lightBlueCongrats.SetActive(false);
            redCongrats.SetActive(false);
            whiteCongrats.SetActive(false);
            greenCongrats.SetActive(false);
            yellowGradientCongrats.SetActive(false);

            switch (Colour)
            {
                case "Blue":
                    PowerUpManagerScript.NumOfSCR += 5;
                    darkBlueCongrats.SetActive(true);
                    Debug.Log("BLUE");
                    break;
                case "Red":
                    Debug.Log("RED");
                    PowerUpManagerScript.NumOfBombs += 2;
                    redCongrats.SetActive(true);
                    break;
                case "Green":
                    PowerUpManagerScript.Currency += 25;
                    greenCongrats.SetActive(true);
                    Debug.Log("GREEN");
                    break;
                case "Yellow":
                    PowerUpManagerScript.Currency += 100;
                    yellowGradientCongrats.SetActive(true);
                    Debug.Log("YELLOW");
                    break;
                case "Purple":
                    PowerUpManagerScript.NumOfSCR += 2;
                    purpleCongrats.SetActive(true);
                    Debug.Log("PURPLE");
                    break;
                case "PurpleGrad":
                    PowerUpManagerScript.NumOfMultilpiers += 5;
                    purpleGrandiantCongrats.SetActive(true);
                    Debug.Log("PURPLEGRAD");
                    break;
                case "LightBlue": 
                    Debug.Log("LIGHTBLUE");
                    PowerUpManagerScript.NumOfMultilpiers += 1;
                    lightBlueCongrats.SetActive(true);
                    break;
                case "White":
                    PowerUpManagerScript.NumOfShuffles += 5;
                    whiteCongrats.SetActive(true);
                    Debug.Log("WHITE");
                    break;
                case "Orange":
                    PowerUpManagerScript.NumOfShuffles += 2;
                    orangeCongrats.SetActive(true);
                    Debug.Log("ORANGE");
                    break;

            }
            PowerUpManagerScript.PowerUpSaves();
           // DailySpinScript.TimeToStopWheel = DailySpinScript.TimeToStopWheelStore;
            DailySpinScript.DailyEvent.CanDoDaily = false;
            PlayerPrefs.SetInt(DailySpinScript.Events.GetComponent<PlayFabServerTime>().SaveBool, (DailySpinScript.DailyEvent.CanDoDaily ? 1 : 0));

            DailySpinScript.DailyEvent.DailySpinner.SetActive(false);

            DailySpinScript.RandomiseWheelProperties();
            DailySpinScript.IsDailyOver = false;
            DailySpinScript.StopSpinning = false;
        }
    }
}