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
     Collider2D col2d;
    public Material HighlitedMat;
    Material Default;
    int PeicesCapacity;
  public  int ToggleHighlite;
       // Use this for initialization
    void Start()
    {
        ClearNeighbours = false;
           col2d = GetComponent<Collider2D>();
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
        Board = FindObjectOfType<BoardScript>();
        CheckTrigger = false;
        Default = GetComponent<Renderer>().material;
     }

    // Update is called once per frame
    void Update()
    {
        PeicesCapacity = DotManagerScript.Peices.Capacity;
      // if (DotManagerScript.Peices[PeicesCapacity - 1].GetComponent<Renderer>().material == Default)
      // {
      //     Debug.Log("Material");
      //     this.gameObject.GetComponent<Renderer>().material = Default;
      // }
        if (ClearNeighbours)
        {
            neighbours.Clear();
            ClearNeighbours = false;

        }
      
    }
    private void OnMouseEnter()
    {
     //  Debug.Log("enter");
     //  ToggleHighlite += 2;
     //
     //  if (ToggleHighlite >= 2)
     //  {
     //       if (DotManagerScript.Peices.Contains(this.gameObject))
     //      {
     //      //      DotManagerScript.Peices[PeicesCapacity].GetComponent<Renderer>().material = Default;
     //          this.gameObject.GetComponent<Renderer>().material = Default;
     //          DotManagerScript.Peices.Remove(this.gameObject);
     //
     //      }
     //
     //  }
    }
    private void OnMouseExit()
    {
        

    }

    private void OnMouseDown()
    {
        DotManagerScript.Peices.Clear();
        this.gameObject.GetComponent<Renderer>().material = HighlitedMat;
        this.gameObject.layer = LayerType;
        ToggleHighlite += 1;
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
                  
                        dot.gameObject.layer = LayerType;
 
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
             if(hitInfo.collider.gameObject.layer == 11)
            {
                Debug.Log("WALL");
                OnMouseUp();
            }
        }
       
    }
    private void OnMouseUp()
    {
        this.gameObject.GetComponent<Renderer>().material = Default;
        ToggleHighlite = 0;

        DotManagerScript.CheckConnection = true;
        this.gameObject.layer = LayerMask.GetMask("Default");
        ClearNeighbours = true;
    }


}