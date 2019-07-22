using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriusMechanic : MonoBehaviour
{
    public float TimerSpawn;
    private float TimerStore;
    public GameObject Meteor;
    // Start is called before the first frame update
    void Start()
    {
        TimerStore = TimerSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        TimerSpawn -= Time.deltaTime;
        if(TimerSpawn < 0)
        {
            Instantiate(Meteor, transform.position, Quaternion.identity);
            TimerSpawn = TimerStore;
        }
    }
}
