using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerMovement : MonoBehaviour
{
    public  float speed = 5f;
    //adjust this to change how high it goes
    Vector3 StartPos;
    public float TimeTillShake;
    public float ShakeTime;
    // store default time
    float ShakeStore;
    float TimeStore;
    bool ReturnToStart;
    int A;
    private void Start()
    {
        TimeTillShake = 0.25f;
        TimeStore = TimeTillShake;
        ShakeStore = ShakeTime;
        StartPos = transform.position;
        ReturnToStart = false;
    }

    void Update()
    {
        // How long until Shake
        TimeTillShake -= Time.deltaTime;
        if (TimeTillShake < 0)
        {
          
            ReturnToStart = false;
            // how long the shake will last
            ShakeTime -= Time.deltaTime;
            transform.position = StartPos + new Vector3(0, Mathf.Sin(Time.time * speed) * 12, 0);
            if (ShakeTime < 0)
            {
                TimeTillShake = TimeStore;
                ShakeTime = ShakeStore;
                ReturnToStart = true;
            }
        }
        // returns beaker to starting position
        if(ReturnToStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPos,100);
        }

    }
 
}
