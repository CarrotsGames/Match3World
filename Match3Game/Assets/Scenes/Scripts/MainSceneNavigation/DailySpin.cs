using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailySpin : MonoBehaviour
{
    public float StartUpSpeed;
    public float MaxSpeed;
    // Counts down how long until player can stop wheel
    public float TimeToStopWheel;
    // Caps velocity of wheel using startUpspeed and maxSpeed
    public  float WheelVelocity;
    // Stores values 
    [HideInInspector]
    public float TimeToStopWheelStore;
    [HideInInspector]
    public float MaxSpeedStore;
    [HideInInspector]
    public float StartUpSpeedStore;
    [HideInInspector]
    public bool IsDailyOver;
    [HideInInspector]
    public bool StopSpinning;
    public GameObject CreatureList;
    public GameObject MenuButtons;
    public EventScript DailyEvent;
    public GameObject Events;
   
     // Use this for initialization
    void Start ()
    {
        RandomiseWheelProperties();
        //TimeToStopWheel = Random.Range(0,3);
        //StartUpSpeed *= Random.Range(100, 150);
        //  StartUpSpeedStore = StartUpSpeed;
        //MaxSpeed *= 100;
        //MaxSpeedStore = MaxSpeed;
        CreatureList.SetActive(false);
        MenuButtons.SetActive(false);
        IsDailyOver = false;
        StopSpinning = false;
        // Reference EventsScript
        Events = GameObject.FindGameObjectWithTag("ES");
        DailyEvent = Events.GetComponent<EventScript>();

    }

   public void RandomiseWheelProperties()
    {
        MaxSpeed = 10;
        StartUpSpeed = 10;
        TimeToStopWheel = Random.Range(1, 2);
        StartUpSpeed *= Random.Range(50, 75);
        MaxSpeed *= Random.Range(50, 75);

    }
    // Update is called once per frame
    void Update ()
    {

        WheelVelocity = Mathf.Clamp(StartUpSpeed, StartUpSpeed, MaxSpeed);
        Debug.Log(WheelVelocity);
        //       StartUpSpeed = Mathf.Clamp(0, 0, MaxSpeed);
        // When Time to stop wheel has reached less than 0 player can stop wheel


        // When wheel starts spinning
        if (!StopSpinning)
        {

            TimeToStopWheel -= Time.deltaTime;
            if (TimeToStopWheel < 0)
            {

                Events.GetComponent<PlayFabServerTime>().DailySpin();

                StopSpinning = true;

            }
            transform.Rotate(Vector3.forward * WheelVelocity * Time.deltaTime);
            if (StartUpSpeed < MaxSpeed)
            {
                StartUpSpeed += Time.deltaTime * 70;
            }
         
        }
        // when wheel stops 
        else
        {
            
            // if the wheel has reached a velocity less than zero the daily is over
            if (WheelVelocity < 1)
            {
                // Wheel Properties are gonna reset when wheel is done in the off chance
                // the player leaves the game open for 24 hours and tries to do another spin 
                // if this happens and values arent set and the wheel will not move
               // RandomiseWheelProperties();

                IsDailyOver = true;
                CreatureList.SetActive(true);
                MenuButtons.SetActive(true);
                TimeToStopWheel = TimeToStopWheelStore;
            }
            else
            {

                StartUpSpeed -= Time.deltaTime * 100;
                transform.Rotate(Vector3.forward * WheelVelocity * Time.deltaTime);
            }

        }
 
    }
}
