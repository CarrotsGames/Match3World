using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltingScript : MonoBehaviour {
    public float Test;
    Renderer rend;
    public bool Disolve;
    GameObject Child;
    private GameObject CollidedNode;
    public Material ShaderMat;
    public float DisolveSpeed;
    public float DisolveCountDown;
    private DotScript DotScriptRef;
    private bool IsConnecting;
     
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        DotScriptRef = GetComponent<DotScript>();
        Disolve = false;

    }

    // Update is called once per frame
    void Update () {

        //  gameObject.GetComponent<SpriteRenderer>().sharedMaterial.SetFloat("Progress", Test);
        // rend.material.SetFloat("Progress", Test);
        if (Disolve)
        {
           
            Test -= Time.deltaTime * DisolveSpeed;
            Child.GetComponent<Renderer>().material.SetFloat("_Progress", Test);
            transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime;
            if(Test <= 0.25f)
            {
                Destroy(gameObject);
            }
         
        }
    }
 
    void Melting()
    {
        //TODO
        //CHANGE SCALE TO 0
        //DELETE GAMEOBJECT WHEN TIME IS UP
        rend.material = ShaderMat;
        //MATERIAL mat_DissolveEdge_Zwrite
        rend.gameObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Progress", Test);

        Child = transform.GetChild(0).gameObject;
        Child.GetComponent<Renderer>().material = ShaderMat;
 
        Child.GetComponent<Renderer>().material.SetFloat("_Progress", Test);
 
        if(DotScriptRef.DotManagerScript.Peices.Contains(this.gameObject))    
         {
           //  if (CollidedNode.layer == DotScriptRef.LayerType)
          //  {
                GetComponent<DotScript>().DotManagerScript.CheckConnection = true;
                IsConnecting = false;
                DotScriptRef.DotManagerScript.MouseCursorObj.SetActive(false);
                DotScriptRef.OnMouseUp();
           // }
        }
        else
        {
            Debug.Log("NOTHING");
        }

        Disolve = true;
     }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Fire")
        {
          //  CollidedNode = collision.gameObject;    
            DisolveCountDown -= Time.deltaTime;
            if (DisolveCountDown < 0)
            {
                //     Melting();
                Melting();
                Debug.Log("HIT");
            }
        }
    }
}
