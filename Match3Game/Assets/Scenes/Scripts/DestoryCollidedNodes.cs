using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryCollidedNodes : MonoBehaviour
{


    public float Timer;
    public float DestoryNodeTimer;
    private GameObject CompanionGameObj;
    private CompanionScript CompanionScriptRef;
    Renderer rend;
    public bool Disolve;
    GameObject Child;
    private GameObject CollidedNode;
    private GameObject DotScriptGameObj;

    private DotScript DotScriptRef;
    private bool IsConnecting;

    // Use this for initialization
    void Start()
    {
        CompanionGameObj = GameObject.FindGameObjectWithTag("Companion");
        CompanionScriptRef = CompanionGameObj.GetComponent<CompanionScript>();
        rend = GetComponent<Renderer>();
        DotScriptGameObj = GameObject.FindGameObjectWithTag("DotManager");
        DotScriptRef = DotScriptGameObj.GetComponent<DotScript>();
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

    void CheckNodes()
    {

        //if (DotScriptRef.Peices.Contains(CollidedNode))
        //{
        //
        //    DotScriptRef.CheckConnection = true;
        //    IsConnecting = false;
        //    DotScriptRef.MouseCursorObj.SetActive(false);
        //    DotScriptGameObj.GetComponent<DotScript>().OnMouseUp();
        //}




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollidedNode = collision.gameObject;
        CheckNodes();
        if (DotScriptGameObj.GetComponent<DotManager>().Peices.Contains(CollidedNode))
        {

            CollidedNode.GetComponent<DotScript>().OnMouseUp();
        }
        else if(!CompanionScriptRef.EatingPeices.Contains(CollidedNode) || !DotScriptGameObj.GetComponent<DotManager>().Peices.Contains(CollidedNode))
        {
            Destroy(CollidedNode);
        }
    }
}