using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.right * Speed * Time.deltaTime);
        transform.Translate(-Vector3.up * Speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Red" || collision.gameObject.tag == "Blue" || collision.gameObject.tag == "Green" ||
            collision.gameObject.tag == "Yellow" )
        {
            //  collision.gameObject.GetComponent<DotScript>().OnMouseUp();
        //    Debug.Log(collision.transform.position);
            collision.transform.position = new Vector2(100, 0);
            collision.gameObject.GetComponent<DotScript>().SelfDestruct = true;
        }
    }
}
