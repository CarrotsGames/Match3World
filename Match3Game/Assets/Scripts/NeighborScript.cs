using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NeighborScript : MonoBehaviour
{
   private RaycastHit Hit;
   private DotManagerScript dotManagerScript;
   private GameObject DotManagerObj;
    CircleCollider2D col2d;
   public bool CheckTrigger;
   private int LayerType = 10;
    public bool ClearNeighbours;

    public List<GameObject> neighbours = new List<GameObject>();
   private void Awake()
    {
        ClearNeighbours = false;

        col2d = GetComponent<CircleCollider2D>();
       DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
   
       dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
        CheckTrigger = false;
       gameObject.GetComponent<NeighborScript>().enabled = false;
   }

    private void Update()
    {
        if (ClearNeighbours)
        {
            neighbours.Clear();
            ClearNeighbours = false;
            CheckTrigger = false;

        }
    }
    // Activate when mouse is over item
    private void OnMouseEnter()
    {
     //  Debug.Log("MOUSEENTER");
      // Goes into this when player holds finger from one dot the second dot 
       if (CheckTrigger)
        {
        
            this.gameObject.layer = LayerMask.GetMask("Default");
           

            DotScript[] Dots = FindObjectsOfType<DotScript>();
    
            foreach (DotScript dot in Dots)
            {
                if (dot.gameObject.GetInstanceID() != gameObject.GetInstanceID())
                {
                    if (col2d.bounds.Intersects(dot.gameObject.GetComponent<Collider2D>().bounds))
                    {
                        if (neighbours.Contains(dot.gameObject))
                        {
    
    
                        }
                        else
                        {
                           // Changes Intersecting Objects layer to 10(Enabled)
                          //  Debug.Log("[" + gameObject.name + "] found a neighbour: " + dot.gameObject.name);
                            dot.gameObject.layer = LayerType;
                            dot.gameObject.GetComponent<NeighborScript>().CheckTrigger = true;
                            dot.gameObject.GetComponent<NeighborScript>().enabled = true;


                            // Adds it to the list of available moves
                            neighbours.Add(dot.gameObject);
                           dotManagerScript.GetComponent<DotManagerScript>().NumberOfNeighbours += 1;
                        }
    
                    }
                }
            }
   
            //   neighbours.Clear();
           // If the raycast hits a dot add it to the peices script
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hitInfo.collider != null)
            {
               // Debug.Log(hitInfo.collider.gameObject);
    
                if (hitInfo.collider.gameObject.layer == 10)
                {
                    if (dotManagerScript.Peices.Contains(hitInfo.collider.gameObject))
                    {
    
    
                    }
                    else
                    {
                       dotManagerScript.Peices.Add(hitInfo.collider.gameObject);
                           
                    }
                    Debug.Log(hitInfo.collider.name);
    
                }
            }
        }
     }
   // when mouse/finger releae reset gameobjects mask and bool
   private void OnMouseExit()
   {
        this.gameObject.layer = LayerMask.GetMask("Default");
        CheckTrigger = false;
        ClearNeighbours = true;

    }
    private void OnMouseUp()
    {
        this.gameObject.layer = LayerMask.GetMask("Default");
        dotManagerScript.CheckConnection = true;
        ClearNeighbours = true;

        // Debug.Log(this.gameObject);
        this.gameObject.GetComponent<NeighborScript>().enabled = false;
         CheckTrigger = false;
      // gameObject.layer = 0;
     //   Debug.Log("NeighborScriptLift");
    }
}