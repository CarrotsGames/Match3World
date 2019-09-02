using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltingScript : MonoBehaviour {
    public float Test;
    Renderer rend;
    public bool Disolve;
    GameObject Child;
    private GameObject DotManagerGameObj;
    private GameObject CollidedNode;
    public Material ShaderMat;
    public float DisolveSpeed;
    public float DisolveCountDown;
    private DotScript DotScriptRef;
    private bool IsConnecting;
     
    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<Renderer>();
        DotManagerGameObj = GameObject.FindGameObjectWithTag("DotManager");
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
                if(this.gameObject.tag == "DeadNode")
                {
                    gameObject.transform.position = new Vector3(100, 0, 0);
                    if(Test <= 0)
                    {
                        Destroy(this.gameObject);
                    }
                }
                else if (DotManagerGameObj.GetComponent<DestroyNodes>().ComboList.Count > 5)
                {
                    gameObject.transform.position = new Vector3(100, 0, 0);
                    gameObject.GetComponent<DotScript>().Timer = 3;
                    gameObject.GetComponent<DotScript>().SelfDestruct = true;
                }
                else
                {
                    gameObject.transform.position = new Vector3(100, 0, 0);
                    gameObject.GetComponent<DotScript>().SelfDestruct = true;
                }
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
        // removes child from parent
       // transform.GetChild(0).transform.parent = null;
        // Loads melting shader onto node
        Child.GetComponent<Renderer>().material = ShaderMat;
        // begins melting shader
        Child.GetComponent<Renderer>().material.SetFloat("_Progress", Test);
        // if the fire hits a deadnode melt it differently
        if (this.gameObject.tag == "DeadNode")
        {
            Disolve = true;
        }
        else if(DotScriptRef.DotManagerScript.Peices.Contains(this.gameObject))    
         {
         
            GetComponent<DotScript>().DotManagerScript.CheckConnection = true;
            IsConnecting = false;
            DotScriptRef.DotManagerScript.MouseCursorObj.SetActive(false);
            DotScriptRef.OnMouseUp();
         }
        else if (!DotScriptRef.DotManagerScript.Peices.Contains(this.gameObject) || !DotScriptRef.DotManagerScript.Companion.EatingPeices.Contains(this.gameObject))
        {
            Disolve = true;

         }

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
             }
        }
    }
}
