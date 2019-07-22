using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CronusMechanic : MonoBehaviour
{
    public GameObject BottomCollider;
    public float ClockTimer;
    private float TimeStore;
    // Start is called before the first frame update
    void Start()
    {
        BottomCollider.SetActive(true);

        TimeStore = ClockTimer;
    }

    // Update is called once per frame
    void Update()
    {
        ClockTimer -= Time.deltaTime;
        if(ClockTimer < 0)
        {
            BottomCollider.SetActive(false);
            if(ClockTimer < -3)
            {
                BottomCollider.SetActive(true);
                ClockTimer = TimeStore;
            }
        }
    }
}
