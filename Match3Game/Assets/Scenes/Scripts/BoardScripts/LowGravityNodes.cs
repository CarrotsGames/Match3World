using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowGravityNodes : MonoBehaviour
{
    public float TimeTillZeroG;
    Rigidbody2D Rb2d;
    public GameObject Lid;
    private void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        Lid = GameObject.FindGameObjectWithTag("Lid");
    }
    // Update is called once per frame
    void Update ()
    {

        if (TimeTillZeroG < 0)
        {
            Rb2d.gravityScale = 0;
            Physics2D.IgnoreCollision(Lid.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);

        }
        else
        {
            TimeTillZeroG -= Time.deltaTime;
            Physics2D.IgnoreCollision(Lid.GetComponent<Collider2D>(), GetComponent<Collider2D>(),true);
            Debug.Log("IGNORING PHYSICS");
        }
    }
}
