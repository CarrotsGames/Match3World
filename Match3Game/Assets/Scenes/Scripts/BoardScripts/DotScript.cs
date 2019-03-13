using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DotScript : MonoBehaviour
{
 
    public LayerMask layerMask;
    public List<GameObject> neighbours = new List<GameObject>();
    public int ToggleHighlite;


    public bool ClearNeighbours;
    public bool DefaultColour;
    public bool GrowSize;

    private int LayerType = 10;
    private float time;
    private BoardScript Board;

    private AudioSource audio;
    private DotManagerScript dotManagerScript;
    private GameObject DotManagerObj;
    private LineRenderer DrawLine;
    private Collider2D col2d;
    private Material Default;
      // Use this for initialization
    void Start()
    {

      
        audio = GetComponent<AudioSource>();
        DrawLine = GetComponent<LineRenderer>();
        DrawLine.enabled = false;
        GrowSize = false;
        time = 0.25f;
        ClearNeighbours = false;
        col2d = GetComponent<Collider2D>();
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        dotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
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
        // Decreases size of peice when selected
        if (dotManagerScript.StartHighliting == true)
        {
            Vector3 newScale = new Vector3();
            newScale.x = Mathf.Clamp(transform.localScale.y, 0.8f, 0.8f);
            newScale.z = Mathf.Clamp(transform.localScale.y, 0.8f, 0.8f);
            newScale.y = Mathf.Clamp(transform.localScale.y, 0.8f, 0.8f);
            transform.localScale = newScale;
        }
    }

    private void OnMouseEnter()
    {
        if (dotManagerScript.StartHighliting == true)
        {
            // Increases size of peice when selected
            Vector3 newScale = new Vector3();
            newScale.x = Mathf.Clamp(transform.localScale.y, 1, 1);
            newScale.z = Mathf.Clamp(transform.localScale.y, 1, 1);
            newScale.y = Mathf.Clamp(transform.localScale.y, 1, 1);
            transform.localScale = newScale;
            audio.PlayDelayed(0.15f);
        }
    }
    private void OnMouseDown()
    {

        dotManagerScript.Peices.Clear();
        // starts drawing line renderer from current peice
        DrawLine.SetPosition(0, transform.position);
        dotManagerScript.StartHighliting = true;
        // Increases size of peice when selected
        Vector3 newScale = new Vector3();
        newScale.x = Mathf.Clamp(transform.localScale.x, 1, 1);
        newScale.z = Mathf.Clamp(transform.localScale.z, 1, 1);
        newScale.y = Mathf.Clamp(transform.localScale.y, 1, 1);
        transform.localScale = newScale;
        // changes colour of peice to black
        this.gameObject.GetComponent<Renderer>().material.color = Color.black;
        // changes peice layer
        this.gameObject.layer = LayerType;
 
        ToggleHighlite += 1;
        audio.PlayDelayed(0);

       dotManagerScript.MouseCursorObj.SetActive(true);
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

                        dotManagerScript.GetComponent<DotManagerScript>().NumberOfNeighbours += 1;
 
                    }

                }
             }
         }
     //   neighbours.Clear();
     // Detects which peices are being chosen via raycast
        RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hitInfo.collider != null)
        {
            DrawLine.enabled = true;

            if (hitInfo.collider.gameObject.layer == 10)
             {
                if (dotManagerScript.Peices.Contains(hitInfo.collider.gameObject))
                {
       


                }
                else
                {
                     hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                    // draws line renderer to hit position
                    DrawLine.SetPosition(dotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);
                    // increases linecount so it can be drawn onto the next peice
                    dotManagerScript.LineCount += 1;
                    // increase amount of line renderer positions
                    DrawLine.positionCount += 1;

                    if(dotManagerScript.LineCount < 2)
                    {
                        DrawLine.SetPosition(dotManagerScript.LineCount, transform.position );

                    }
                    else
                    {
                        DrawLine.SetPosition(dotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position  );

                    }

                    // adds hit.collider to Peices list
                    dotManagerScript.Peices.Add(hitInfo.collider.gameObject);

                }
                Debug.Log(hitInfo.collider.name);

             }
            // if player interacts with wall reset all current chains
             if(hitInfo.collider.gameObject.layer == 11)
            {
                Debug.Log("WALL");
                this.gameObject.GetComponent<Renderer>().material = Default;

                OnMouseUp();
            }
        }
       
    }
    private void OnMouseUp()
    {
        dotManagerScript.MouseCursorObj.SetActive(false);

        // turns off highlite
        ToggleHighlite = 0;
        // Resets size of peices
        Vector3 newScale = new Vector3();
        newScale.x = Mathf.Clamp(transform.localScale.y, 0.8f, 0.8f);
        newScale.z = Mathf.Clamp(transform.localScale.y, 0.8f, 0.8f);
        newScale.y = Mathf.Clamp(transform.localScale.y, 0.8f, 0.8f);
        transform.localScale = newScale;
        dotManagerScript.StartHighliting = false;

        // Goes into dotManagerScript to check if there was a connection
        dotManagerScript.CheckConnection = true;
        // Resets Linerenderer
        DrawLine.positionCount = 1;
        // Resets peices material and layer
        this.gameObject.GetComponent<Renderer>().material = Default;
        this.gameObject.layer = LayerMask.GetMask("Default");
        // makes peices unable to grow
        GrowSize = false;
        // Resets neighbour list
        ClearNeighbours = true;
    }


}