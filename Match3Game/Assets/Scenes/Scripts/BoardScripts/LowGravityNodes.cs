using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowGravityNodes : MonoBehaviour
{
    public float TimeTillZeroG;
    Rigidbody2D Rb2d;
    public GameObject Lid;
    private float Gravity;
    private void Start()
    {
        Gravity = 0;
        Rb2d = GetComponent<Rigidbody2D>();
        Lid = GameObject.FindGameObjectWithTag("Lid");
    }
    // Update is called once per frame
    void Update ()
    {

        if (TimeTillZeroG < 0)
        {
            Rb2d.gravityScale = Gravity;
            Physics2D.IgnoreCollision(Lid.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);

        }
        else
        {
            TimeTillZeroG -= Time.deltaTime;
            Physics2D.IgnoreCollision(Lid.GetComponent<Collider2D>(), GetComponent<Collider2D>(),true);
            Debug.Log("IGNORING PHYSICS");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "SquishyCap")
        {
             Gravity = 0.5f;

        }

        if (collision.name == "SquishyGround")
        {
             Gravity = -0.15f;

        }
    }
}
