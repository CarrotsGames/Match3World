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
    
    private bool IsDailyOver;
    private bool StopSpinning;

    EventScript DailyEvent;
    GameObject Events;
    // Use this for initialization
    void Start ()
    {
        StartUpSpeed *= 100;
        MaxSpeed *= 100;
   
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
            if(Input.GetMouseButtonDown(0))
            {
                StopSpinning = true;
            }
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
            }
            else
            {
                StartUpSpeed -= Time.deltaTime * 100;
                transform.Rotate(Vector3.forward * WheelVelocity * Time.deltaTime);
            }

        }
        // RESETS script 
        // if daily set CanDoDaily to false and turn off gameobject  
        if (IsDailyOver)
        {
            // TURN ON CHILDREN COLLIDERS

            // TODO  GIVE PRIZE
            TimeToStopWheel = TimeToStopWheelStore;
            DailyEvent.CanDoDaily = false;
            PlayerPrefs.SetInt(Events.GetComponent<PlayFabServerTime>().SaveBool, (DailyEvent.CanDoDaily ? 1 : 0));

            
            IsDailyOver = false;
            StopSpinning = false;
            gameObject.SetActive(false);
        }
    }
}
