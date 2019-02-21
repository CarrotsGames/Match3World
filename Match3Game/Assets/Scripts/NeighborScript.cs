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
   
   public List<GameObject> neighbours = new List<GameObject>();
   private void Awake()
   {
       col2d = GetComponent<CircleCollider2D>();
       DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
   
       dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
        CheckTrigger = false;
       gameObject.GetComponent<NeighborScript>().enabled = false;
   }
   // Activate when mouse is over item
   private void OnMouseEnter()
    {
       Debug.Log("MOUSEENTER");
      // Goes into this when player holds finger from one dot the second dot 
       if (CheckTrigger)
        {
          //  if(neighbours.Contains(gameObject))
          //  {
          //
          //  }
          //  else
          //  {
          //      dotManagerScript.Peices.Add(gameObject);
                 this.gameObject.layer = LayerMask.GetMask("Default");
          //
          //  }

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
                            Debug.Log("[" + gameObject.name + "] found a neighbour: " + dot.gameObject.name);
                            dot.gameObject.layer = LayerType;
                            dot.gameObject.GetComponent<DotScript>().CheckTrigger = true;
    
                            //    dot.gameObject.GetComponent<DotScript>().OnMouseDrag();
                            Debug.Log(dot.gameObject);
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
                Debug.Log(hitInfo.collider.gameObject);
    
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
        CheckTrigger = false;
    }
   // when mouse/finger releae reset gameobjects mask and bool
   private void OnMouseExit()
   {
       Debug.Log(gameObject.layer);
   }
   private void OnMouseUp()
    {
    
       Debug.Log(this.gameObject);
       this.gameObject.GetComponent<NeighborScript>().enabled = false;
       CheckTrigger = false;
      // gameObject.layer = 0;
        Debug.Log("NeighborScriptLift");
    }
}