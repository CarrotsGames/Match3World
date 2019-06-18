using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryCollidedNodes : MonoBehaviour {


    public float Timer;
    public float DestoryNodeTimer;

    Renderer rend;
    public bool Disolve;
    GameObject Child;
    private GameObject CollidedNode;

    private GameObject DotScriptGameObj;

    private DotManager DotScriptRef;
    private bool IsConnecting;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        DotScriptGameObj = GameObject.FindGameObjectWithTag("DotManager");
        DotScriptRef = DotScriptGameObj.GetComponent<DotManager>();
        Disolve = false;

    }

    // Update is called once per frame
    void Update()
    {

        //  gameObject.GetComponent<SpriteRenderer>().sharedMaterial.SetFloat("Progress", Test);
        // rend.material.SetFloat("Progress", Test);
        // if (Disolve)
        // {
        //
        //  
        //     Child.GetComponent<Renderer>().material.SetFloat("_Progress", Test);
        //     transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime;
        //     if (Timer <= 0.25f)
        //     {
        //         Destroy(gameObject);
        //     }
        //
        // }
    }

    void Melting()
    {


      
        

     }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DotScriptRef.Peices.Contains(collision.gameObject))
        {
            //  if (CollidedNode.layer == DotScriptRef.LayerType)
            //  {
            // GetComponent<DotScript>().DotManagerScript.CheckConnection = true;
            DotScriptRef.CheckConnection = true;
            IsConnecting = false;
            DotScriptRef.MouseCursorObj.SetActive(false);
            DotScriptGameObj.GetComponent<DotScript>().OnMouseUp();
            // }
        }
        Melting();
        Destroy(collision.gameObject);
 
    }
}