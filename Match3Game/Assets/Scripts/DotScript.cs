using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DotScript : MonoBehaviour
{

    public int Colour;
    // 1 Red
    // 2 Blue
    // 3 Yellow
    // 4 Green
    public int Column;
    public int Row;
    int LayerType = 10;
    public LayerMask layerMask;
    public float Raylength;
   public bool CheckTrigger;
    public bool ClearNeighbours;
    RaycastHit Hit;
    DotManagerScript DotManagerScript;
    GameObject DotManagerObj;
    private BoardScript Board;
    private GameObject OtherDot;
    public bool DefaultColour;
    public List<GameObject> neighbours = new List<GameObject>();
     CircleCollider2D col2d;
    public Material HighlitedMat;
    Material Default;
    int Test;
       // Use this for initialization
    void Start()
    {
        ClearNeighbours = false;
           col2d = GetComponent<CircleCollider2D>();
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
        Board = FindObjectOfType<BoardScript>();
        CheckTrigger = false;
        Default = GetComponent<Renderer>().material;
     }

    // Update is called once per frame
    void Update()
    {
        Test = DotManagerScript.Peices.Capacity;
        if (ClearNeighbours)
        {
            neighbours.Clear();
            ClearNeighbours = false;

        }
       if(DefaultColour)
        {
            this.gameObject.GetComponent<Renderer>().material = Default;

        }
    }
    private void OnMouseEnter()
    {
        Debug.Log("enter");
        if(DotManagerScript.Peices.Capacity >= 0)
        {
             if (DotManagerScript.Peices.Contains(this.gameObject))
            {
                //  DotManagerScript.Peices[Test].GetComponent<Renderer>().material = Default;
                 this.gameObject.GetComponent<Renderer>().material = Default;
                DotManagerScript.Peices.Remove(this.gameObject);

            }
           
        }
    }

    private void OnMouseDown()
    {
        DotManagerScript.Peices.Clear();
        this.gameObject.GetComponent<Renderer>().material = HighlitedMat;
        this.gameObject.layer = LayerType;
     }
    private void OnMouseDrag()
    {
         DotScript[] Dots = FindObjectsOfType<DotScript>();
        bool CircleOverlap = Physics2D.OverlapCircle(transform.position, 1);

        foreach (DotScript dot in Dots)
         {
             if (dot.gameObject.GetInstanceID() != gameObject.GetInstanceID())
             {
                if (CircleOverlap)
                // if (col2d.bounds.Intersects(dot.gameObject.GetComponent<Collider2D>().bounds))
                 {
                     if (neighbours.Contains(dot.gameObject))
                     {
       
       
                     }
                     else
                     {
                      // Changes Intersecting Objects layer to 10(Enabled)
                      //   Debug.Log("[" + gameObject.name + "] found a neighbour: " + dot.gameObject.name);
                        dot.gameObject.layer = LayerType;
                     //    dot.gameObject.GetComponent<DotScript>().OnMouseDrag();
                        //dot.gameObject.GetComponent<NeighborScript>().enabled = true;
                        //dot.gameObject.GetComponent<NeighborScript>().CheckTrigger = true;

                        //       Debug.Log(dot.gameObject);
                         // Adds it to the list of available moves
                        neighbours.Add(dot.gameObject);
                        DotManagerScript.GetComponent<DotManagerScript>().NumberOfNeighbours += 1;
 
                    }

                }
             }
         }
     //   neighbours.Clear();

        RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hitInfo.collider != null)
        {
 

             if (hitInfo.collider.gameObject.layer == 10)
             {
                if (DotManagerScript.Peices.Contains(hitInfo.collider.gameObject))
                {


                }
                else
                {
                    hitInfo.collider.gameObject.GetComponent<Renderer>().material = HighlitedMat;
                    DotManagerScript.Peices.Add(hitInfo.collider.gameObject);

                }
                Debug.Log(hitInfo.collider.name);

             }
        }
       
    }
    private void OnMouseExit()
    {
 
    }
    private void OnMouseUp()
    {
        this.gameObject.GetComponent<Renderer>().material = Default;
        
        DotManagerScript.CheckConnection = true;
        this.gameObject.layer = LayerMask.GetMask("Default");
        ClearNeighbours = true;
    }


}