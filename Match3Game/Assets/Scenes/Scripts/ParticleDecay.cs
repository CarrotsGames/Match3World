using UnityEngine;
using System.Collections;

public class ParticleDecay : MonoBehaviour
{
    float DecayTimer;

    // Use this for initialization
    void Start()
    {
        DecayTimer = 1.25f;
    }

    // Update is called once per frame
    void Update()
    {
        DecayTimer -= Time.deltaTime;
        if(DecayTimer < 0)
        {
            Destroy(gameObject);
        }
    }
}
