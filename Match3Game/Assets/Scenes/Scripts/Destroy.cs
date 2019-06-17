using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    private GameObject DotManagerObj;

    private DotManager DotManagerScriptRef;
    private void Start()
    {
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScriptRef = DotManagerObj.GetComponent<DotManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
            Destroy(collision.gameObject);
        DotManagerObj.GetComponent<DotScript>().OnMouseUp();

    }
}
