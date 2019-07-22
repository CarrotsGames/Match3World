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
        TimeToStopWheelStore = TimeToStopWheel;
        StartUpSpeed *= 100;
        StartUpSpeedStore = StartUpSpeed;
        MaxSpeed *= 100;
        MaxSpeedStore = MaxSpeed;
        CreatureList.SetActive(false);
        MenuButtons.SetActive(false);
        IsDailyOver = false;
        StopSpinning = false;
        // Reference EventsScript
        Events = GameObject.FindGameObjectWithTag("ES");
        DailyEvent = Events.GetComponent<EventScript>();

    }

    // Update is called once per frame
    void Update ()
    {
        TimeToStopWheel -= Time.deltaTime;
        WheelVelocity = Mathf.Clamp(StartUpSpeed, StartUpSpeed, MaxSpeed);

        //       StartUpSpeed = Mathf.Clamp(0, 0, MaxSpeed);
        // When Time to stop wheel has reached less than 0 player can stop wheel
        if (TimeToStopWheel < 0)
        {
            
                Events.GetComponent<PlayFabServerTime>().DailySpin();

                StopSpinning = true;
             
        }

      // When wheel starts spinning
        if (!StopSpinning)
        {            
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
                IsDailyOver = true;
                CreatureList.SetActive(true);
                MenuButtons.SetActive(true);
                StartUpSpeed = StartUpSpeedStore;
                MaxSpeed = MaxSpeedStore;
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
