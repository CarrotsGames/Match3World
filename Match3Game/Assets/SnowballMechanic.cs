using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballMechanic : MonoBehaviour
{
    public float TimerSpawn;
    private float TimerStore;
    public GameObject Icicle;
    // Start is called before the first frame update
    void Start()
    {
        TimerStore = TimerSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        TimerSpawn -= Time.deltaTime;
        if (TimerSpawn < 0)
        {
            int random = Random.Range(0, 2);
            Instantiate(Icicle, transform.position, Quaternion.identity);
            TimerSpawn = TimerStore;
        }
    }
}
