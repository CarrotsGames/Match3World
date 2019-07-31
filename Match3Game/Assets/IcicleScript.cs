using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleScript : MonoBehaviour
{
    public float SpeedX;
    public float SpeedY;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(SpeedX, SpeedY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Red" || collision.gameObject.tag == "Blue" || collision.gameObject.tag == "Green" ||
            collision.gameObject.tag == "Yellow")
        {
           
             collision.GetComponent<NodeFreeze>().FreezeNode();
            collision.gameObject.GetComponent<Renderer>().material.color = Color.white;

        }
    }
}
