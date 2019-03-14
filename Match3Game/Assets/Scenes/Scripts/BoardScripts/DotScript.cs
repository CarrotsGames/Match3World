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
        if(dotManagerScript.StopInteracting)
        {
            OnMouseUp();
            dotManagerScript.StopInteracting = false;
        }
        if (ClearNeighbours)
        {
            neighbours.Clear();
            ClearNeighbours = false;
            gameObject.layer = 0;

        }
        if(dotManagerScript.ResetLayer)
        {
            gameObject.layer = 0;
            dotManagerScript.ResetLayer = false;
        }
        if(dotManagerScript.ResetMaterial)
        {
            this.gameObject.GetComponent<Renderer>().material = Default;
            dotManagerScript.ResetMaterial = false;
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
        else
        {
            gameObject.layer = 0;
        }
    }

    private void OnMouseOver()
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
        else
        {
            //  dotManagerScript.StartHighliting = false;
            Vector3 newScale = new Vector3();
            newScale.x = Mathf.Clamp(transform.localScale.y, 0.8f, 0.8f);
            newScale.z = Mathf.Clamp(transform.localScale.y, 0.8f, 0.8f);
            newScale.y = Mathf.Clamp(transform.localScale.y, 0.8f, 0.8f);
            transform.localScale = newScale;
            gameObject.layer = 0;
            dotManagerScript.RedSelection = false;
            dotManagerScript.BlueSelection = false;
            dotManagerScript.YellowSelection = false;
            dotManagerScript.PurpleSelection = false;
            dotManagerScript.ResetLayer = true;

        }
    }
    private void OnMouseDown()
    {
        // Checks which colout tag the mouse is interacting with to know which colour to focus on
        switch (transform.tag)
        {
            case  "Red":
                dotManagerScript.RedSelection = true;
 

                break;
            case "Blue":
                dotManagerScript.BlueSelection = true;

 
                break;
            case "Green":
                dotManagerScript.YellowSelection = true;

 
                break;
            case "Yellow":
                dotManagerScript.PurpleSelection = true;

 
                break;
        }

         
        dotManagerScript.Peices.Clear();
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
                  {
                    //Changes red peices layer to 10 so they can be selected
                    if (dotManagerScript.RedSelection)
                    {
                        if (neighbours.Contains(dot.gameObject) && dot.gameObject.tag == "Red")
                        {


                        }
                        else if (!neighbours.Contains(dot.gameObject) && dot.gameObject.tag == "Red")
                        {

                            dot.gameObject.layer = LayerType;

                            neighbours.Add(dot.gameObject);
                            dot.gameObject.GetComponent<DotScript>().GrowSize = true;

                            dotManagerScript.GetComponent<DotManagerScript>().NumberOfNeighbours += 1;
                            if (dot.gameObject.tag == "Blue" || dot.gameObject.tag == "Yellow" || dot.gameObject.tag == "Green")
                            {
                                OnMouseUp();
                            }
                        }
           
                    }
                    //Changes Blue peices layer to 10 so they can be selected
                    if (dotManagerScript.BlueSelection)
                    {
                        if (neighbours.Contains(dot.gameObject) && dot.gameObject.tag == "Blue")
                        {


                        }
                        else if (!neighbours.Contains(dot.gameObject) && dot.gameObject.tag == "Blue")
                        {

                            dot.gameObject.layer = LayerType;

                            neighbours.Add(dot.gameObject);
                            dot.gameObject.GetComponent<DotScript>().GrowSize = true;

                            dotManagerScript.GetComponent<DotManagerScript>().NumberOfNeighbours += 1;
                            if (dot.gameObject.tag == "Red" || dot.gameObject.tag == "Yellow" || dot.gameObject.tag == "Green")
                            {
                                OnMouseUp();
                            }
                        }
                    }
                    //Changes Yellow peices layer to 10 so they can be selected
                    if (dotManagerScript.YellowSelection)
                    {
                        if (neighbours.Contains(dot.gameObject) && dot.gameObject.tag == "Green")
                        {


                        }
                        else if (!neighbours.Contains(dot.gameObject) && dot.gameObject.tag == "Green")
                        {

                            dot.gameObject.layer = LayerType;

                            neighbours.Add(dot.gameObject);
                            dot.gameObject.GetComponent<DotScript>().GrowSize = true;

                            dotManagerScript.GetComponent<DotManagerScript>().NumberOfNeighbours += 1;
                            if (dot.gameObject.tag == "Blue" || dot.gameObject.tag == "Yellow" || dot.gameObject.tag == "Red")
                            {
                                OnMouseUp();
                            }
                        }
                    }
                    //Changes Purple peices layer to 10 so they can be selected
                    if (dotManagerScript.PurpleSelection)
                    {
                        if (neighbours.Contains(dot.gameObject) && dot.gameObject.tag == "Yellow")
                        {


                        }
                        else if (!neighbours.Contains(dot.gameObject) && dot.gameObject.tag == "Yellow")
                        {

                            dot.gameObject.layer = LayerType;

                            neighbours.Add(dot.gameObject);
                            dot.gameObject.GetComponent<DotScript>().GrowSize = true;

                            dotManagerScript.GetComponent<DotManagerScript>().NumberOfNeighbours += 1;
                            if (dot.gameObject.tag == "Blue" || dot.gameObject.tag == "Red" || dot.gameObject.tag == "Green")
                            {
                                OnMouseUp();
                            }
                        }
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
                // Checks for only Red pieces
                if (dotManagerScript.RedSelection)
                {
                    if (dotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Red")
                    {



                    }
                    else if (!dotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Red")
                    {
                        hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                        // draws line renderer to hit position
                        DrawLine.SetPosition(dotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);
                        // increases linecount so it can be drawn onto the next peice
                        dotManagerScript.LineCount += 1;
                        // increase amount of line renderer positions
                        DrawLine.positionCount += 1;

                        if (dotManagerScript.LineCount < 2)
                        {
                            DrawLine.SetPosition(dotManagerScript.LineCount, transform.position);

                        }
                        else
                        {
                            DrawLine.SetPosition(dotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);

                        }

                        // adds hit.collider to Peices list
                        dotManagerScript.Peices.Add(hitInfo.collider.gameObject);

                    }
                    if (hitInfo.collider.gameObject.tag == "Blue" || hitInfo.collider.gameObject.tag == "Yellow" || hitInfo.collider.gameObject.tag == "Green")
                    {
                        OnMouseUp();
                    }
                }
                // Checks for only Blue pieces
                if (dotManagerScript.BlueSelection)
                {
                    if (dotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Blue")
                    {



                    }
                    else if (!dotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Blue")
                    {
                        hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                        // draws line renderer to hit position
                        DrawLine.SetPosition(dotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);
                        // increases linecount so it can be drawn onto the next peice
                        dotManagerScript.LineCount += 1;
                        // increase amount of line renderer positions
                        DrawLine.positionCount += 1;

                        if (dotManagerScript.LineCount < 2)
                        {
                            DrawLine.SetPosition(dotManagerScript.LineCount, transform.position);

                        }
                        else
                        {
                            DrawLine.SetPosition(dotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);

                        }

                        // adds hit.collider to Peices list
                        dotManagerScript.Peices.Add(hitInfo.collider.gameObject);

                    }
                    if (hitInfo.collider.gameObject.tag == "Red" || hitInfo.collider.gameObject.tag == "Yellow" || hitInfo.collider.gameObject.tag == "Green")
                    {
                        OnMouseUp();
                    }
                }
                // Checks for only Purple pieces
                if (dotManagerScript.PurpleSelection)
                {
                    if (dotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Yellow")
                    {



                    }
                    else if (!dotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Yellow")
                    {
                        hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                        // draws line renderer to hit position
                        DrawLine.SetPosition(dotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);
                        // increases linecount so it can be drawn onto the next peice
                        dotManagerScript.LineCount += 1;
                        // increase amount of line renderer positions
                        DrawLine.positionCount += 1;

                        if (dotManagerScript.LineCount < 2)
                        {
                            DrawLine.SetPosition(dotManagerScript.LineCount, transform.position);

                        }
                        else
                        {
                            DrawLine.SetPosition(dotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);

                        }

                        // adds hit.collider to Peices list
                        dotManagerScript.Peices.Add(hitInfo.collider.gameObject);
                    }
                        if (hitInfo.collider.gameObject.tag == "Blue" || hitInfo.collider.gameObject.tag == "Green" || hitInfo.collider.gameObject.tag == "Red")
                        {
                            OnMouseUp();
                        }
                }
                // Checks for only yellow pieces
                if (dotManagerScript.YellowSelection)
                {
                    if (dotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Green")
                    {



                    }
                    else if (!dotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Green")
                    {
                        hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                        // draws line renderer to hit position
                        DrawLine.SetPosition(dotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);
                        // increases linecount so it can be drawn onto the next peice
                        dotManagerScript.LineCount += 1;
                        // increase amount of line renderer positions
                        DrawLine.positionCount += 1;

                        if (dotManagerScript.LineCount < 2)
                        {
                            DrawLine.SetPosition(dotManagerScript.LineCount, transform.position);

                        }
                        else
                        {
                            DrawLine.SetPosition(dotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);

                        }

                        // adds hit.collider to Peices list
                        dotManagerScript.Peices.Add(hitInfo.collider.gameObject);
                        
                    }
                    if (hitInfo.collider.gameObject.tag == "Blue" || hitInfo.collider.gameObject.tag == "Red" || hitInfo.collider.gameObject.tag == "Yellow")
                    {
                        OnMouseUp();
                    }
                }

             }
            else
            {
                gameObject.layer = 0;
             
                OnMouseUp();
            }
            // if player interacts with wall reset all current chains
             if(hitInfo.collider.gameObject.layer == 11)
            {
                Debug.Log("WALL");
                dotManagerScript.ResetMaterial = true;
                OnMouseUp();
            }
           
        }
   
    }
 
    private void OnMouseUp()
    {
 
        // Resets Linerenderer
        DrawLine.positionCount = 1;

        // turns off highlite
        ToggleHighlite = 0;
        dotManagerScript.ResetMaterial = true;
        // Resets peices material and layer
        this.gameObject.layer = LayerMask.GetMask("Default");
        gameObject.layer = 0;
        // makes peices unable to grow
        GrowSize = false;
        // Resets neighbour list
        ClearNeighbours = true;
        // Goes into dotManagerScript to check if there was a connection
        dotManagerScript.CheckConnection = true;
        dotManagerScript.MouseCursorObj.SetActive(false);

        // Resets size of peices  
         Vector3 newScale = new Vector3();
         newScale.x = Mathf.Clamp(transform.localScale.y, 0.8f, 0.8f);
         newScale.z = Mathf.Clamp(transform.localScale.y, 0.8f, 0.8f);
         newScale.y = Mathf.Clamp(transform.localScale.y, 0.8f, 0.8f);
         transform.localScale = newScale;
       

    }


}