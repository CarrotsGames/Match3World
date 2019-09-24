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
       // Physics2D.IgnoreLayerCollision(18, 12);

    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollidedNode = collision.gameObject;
        
        if (DotScriptGameObj.GetComponent<DotManager>().Peices.Contains(CollidedNode))
        {
            CollidedNode.GetComponent<DotScript>().OnMouseUp();
        }
        else if (collision.gameObject.tag == "Rainbow")
        {
            Destroy(collision.gameObject);
        }
        else if(!DotScriptGameObj.GetComponent<DestroyNodes>().ComboList.Contains(CollidedNode) || !DotScriptGameObj.GetComponent<DotManager>().Peices.Contains(CollidedNode))
        {
             collision.gameObject.transform.position += new Vector3(100, 0, 0);
             collision.gameObject.GetComponent<DotScript>().SelfDestruct = true;
        }
    }
}