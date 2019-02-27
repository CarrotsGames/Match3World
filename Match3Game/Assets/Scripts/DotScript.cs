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
 
    int LayerType = 10;
    public LayerMask layerMask;
    public bool ClearNeighbours;
    DotManagerScript DotManagerScript;
    GameObject DotManagerObj;
    private BoardScript Board;
    public bool DefaultColour;
    public List<GameObject> neighbours = new List<GameObject>();
    Collider2D col2d;
    public Material HighlitedMat;
    Material Default;
    public int ToggleHighlite;
    float time;
    public bool GrowSize;
     // Use this for initialization
    void Start()
    {
        GrowSize = false;
        time = 0.25f;
        ClearNeighbours = false;
        col2d = GetComponent<Collider2D>();
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
        Board = FindObjectOfType<BoardScript>();
        Default = GetComponent<Renderer>().material;
     }

    // Update is called once per frame
    void Update()
    {
       
        if (ClearNeighbours)
        {
            neighbours.Clear();
            ClearNeighbours = false;

        }
      
    }
    private void OnMouseExit()
    {
       
            Vector3 newScale = new Vector3();
            newScale.x = Mathf.Clamp(transform.localScale.y, 0.65f, 0.65f);
            newScale.z = Mathf.Clamp(transform.localScale.y, 0.65f, 0.65f);

            newScale.y = Mathf.Clamp(transform.localScale.y, 0.65f, 0.65f);
            transform.localScale = newScale;
         
       
        
    }

    private void OnMouseEnter()
    {
        Vector3 newScale = new Vector3();
        newScale.x = Mathf.Clamp(transform.localScale.y, 0.80f, 0.80f);
        newScale.z = Mathf.Clamp(transform.localScale.y, 0.80f, 0.80f);

        newScale.y = Mathf.Clamp(transform.localScale.y, 0.80f, 0.80f);
        transform.localScale = newScale;


    }
    private void OnMouseDown()
    {
        Vector3 newScale = new Vector3();
        newScale.x = Mathf.Clamp(transform.localScale.x, 0.65f, 0.65f);
        newScale.z = Mathf.Clamp(transform.localScale.z, 0.65f, 0.65f);

        newScale.y = Mathf.Clamp(transform.localScale.y, 0.65f, 0.65f);
        transform.localScale = newScale;

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
                        dot.gameObject.GetComponent<DotScript>().GrowSize = true;
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
        Vector3 newScale = new Vector3();
        newScale.x = Mathf.Clamp(transform.localScale.y, 0.65f, 0.65f);
        newScale.z = Mathf.Clamp(transform.localScale.y, 0.65f, 0.65f);

        newScale.y = Mathf.Clamp(transform.localScale.y, 0.65f, 0.65f);
        transform.localScale = newScale;

        this.gameObject.GetComponent<Renderer>().material = Default;
        ToggleHighlite = 0;
        GrowSize = false;
         DotManagerScript.CheckConnection = true;
        this.gameObject.layer = LayerMask.GetMask("Default");
        ClearNeighbours = true;
    }


}