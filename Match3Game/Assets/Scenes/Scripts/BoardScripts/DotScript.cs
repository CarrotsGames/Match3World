using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DotScript : MonoBehaviour
{

    public float defultSize = 2.5f;
    public float jucSize = 3;

    public LayerMask layerMask;
    public List<GameObject> neighbours = new List<GameObject>();
    public int ToggleHighlite;
    public bool StartDrawingLine;
    [HideInInspector]
    public bool ClearNeighbours;
    [HideInInspector]
    public bool DefaultColour;
    [HideInInspector]
    public bool GrowSize;
    [HideInInspector]
    public int LayerType = 10;
    private float time;
    private BoardScript Board;
    private GameObject HappinessManagerGameobj;
    public HappinessManager HappinessManagerScript;
    private AudioSource audio;
    public DotManager DotManagerScript;
    private GameObject DotManagerObj;
    private LineRenderer DrawLine;
    private Collider2D col2d;
    private Material Default;
    public Material BlueEmmision;
    string Colour;
    // Use this for initialization
    void Start()
    {
        HappinessManagerGameobj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessManagerGameobj.GetComponent<HappinessManager>();
        Physics2D.IgnoreLayerCollision(0, 14);

        audio = GetComponent<AudioSource>();
        DrawLine = GetComponent<LineRenderer>();
        DrawLine.enabled = false;
        GrowSize = false;
        time = 0.25f;
        ClearNeighbours = false;
        col2d = GetComponent<Collider2D>();
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        Board = FindObjectOfType<BoardScript>();
        Default = GetComponent<Renderer>().material;
        BlueEmmision = GetComponent<SpriteRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.tag == "Gold" && !HappinessManagerScript.IsSleeping)
        {
            Destroy(gameObject);
        }

        if (DotManagerScript.StopInteracting)
        {
            OnMouseUp();
            DotManagerScript.StopInteracting = false;
        }
        if (ClearNeighbours)
        {
            neighbours.Clear();
            ClearNeighbours = false;
            gameObject.layer = 0;

        }
        // restes dot layer
        if (DotManagerScript.ResetLayer)
        {
            gameObject.layer = 0;
            DotManagerScript.ResetLayer = false;
        }
        // resets dot material 
        if (DotManagerScript.ResetMaterial)
        {
            gameObject.GetComponent<Renderer>().material = Default;

        }
       // if (DotManagerScript.StartHighliting)
       // {
       //     for (int i = 0; i < DotManagerScript.Peices.Count; i++)
       //     {
       //         GameObject Test;
       //         transform.gameObject.GetComponent<DotScript>().DrawLine.positionCount = i;
       //         DrawLine.SetPosition(DotManagerScript.LineCount, DotManagerScript.Peices[i].transform.position);
       //
       //
       //     }
       //
       // }
    }
    private void OnMouseExit()
    {
        // Decreases size of peice when selected
        if (DotManagerScript.StartHighliting == true)
        {
            Vector3 newScale = new Vector3();
            newScale.x = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
            newScale.z = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
            newScale.y = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
            transform.localScale = newScale;
        }
        else
        {
            gameObject.layer = 0;
        }
    }

    private void OnMouseOver()
    {

        if (DotManagerScript.StartHighliting == true)
        {
            // Increases size of peice when selected
            Vector3 newScale = new Vector3();
            newScale.x = Mathf.Clamp(transform.localScale.y, jucSize, jucSize);
            newScale.z = Mathf.Clamp(transform.localScale.y, jucSize, jucSize);
            newScale.y = Mathf.Clamp(transform.localScale.y, jucSize, jucSize);
            transform.localScale = newScale;
            audio.PlayDelayed(0.15f);
 
        }
        else
        {
            //  DotManagerScript.StartHighliting = false;
            Vector3 newScale = new Vector3();
            newScale.x = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
            newScale.z = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
            newScale.y = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
            transform.localScale = newScale;
            gameObject.layer = 0;
            DotManagerScript.RedSelection = false;
            DotManagerScript.BlueSelection = false;
            DotManagerScript.YellowSelection = false;
            DotManagerScript.PurpleSelection = false;
            DotManagerScript.ResetLayer = true;

        }
    }
    private void OnMouseDown()
    {

        DotManagerScript.StartHighliting = true;
        // Checks which colout tag the mouse is interacting with to know which colour to focus on
        switch (transform.tag)
        {
            case  "Red":
                Colour = "Red";
                DotManagerScript.RedSelection = true;
                
                break;
            case "Blue":
                Colour = "Blue";
                //DotManagerScript.BlueSelection = true;
                DotManagerScript.BlueSelection = true;

                break;
            case "Green":
                Colour = "Green";
                // DotManagerScript.YellowSelection = true;
                DotManagerScript.YellowSelection = true;

                break;
            case "Yellow":
                Colour = "Yellow";
                //    DotManagerScript.PurpleSelection = true;
                DotManagerScript.PurpleSelection = true;
                break;
            case "Gold":
                Colour = "Gold";
                //    DotManagerScript.PurpleSelection = true;
                DotManagerScript.GoldSelection = true;
                break;
        }

         
        DotManagerScript.Peices.Clear();
       // DrawLine.SetPosition(0, transform.position);
        // Increases size of peice when selected
        Vector3 newScale = new Vector3();
        newScale.x = Mathf.Clamp(transform.localScale.x, jucSize, jucSize);
        newScale.z = Mathf.Clamp(transform.localScale.z, jucSize, jucSize);
        newScale.y = Mathf.Clamp(transform.localScale.y, jucSize, jucSize);
        transform.localScale = newScale;
        // changes colour of peice to black
        this.gameObject.GetComponent<Renderer>().material.color = Color.black;
        // changes peice layer
        this.gameObject.layer = LayerType;
 
        ToggleHighlite += 1;
        audio.PlayDelayed(0);
        DotManagerScript.MouseCursorObj.SetActive(true);
    }
    private void OnMouseDrag()
    {
        DotScript[] Dots = FindObjectsOfType<DotScript>();
        bool CircleOverlap = Physics2D.OverlapCircle(transform.position, 1);
     
        foreach (DotScript dot in Dots)
        {
            // if the Node is not the current node
            if (dot.gameObject.GetInstanceID() != gameObject.GetInstanceID())
             {
           
                 if (neighbours.Contains(dot.gameObject) && dot.gameObject.tag == Colour)
                 {

                    // do nothing
                 }
                 // If the neighbour list doesent contain the selected node
                 else if (!neighbours.Contains(dot.gameObject) && dot.gameObject.tag == Colour)
                 {
                    // change node layer to the layertype needed to connect nodes
                     dot.gameObject.layer = LayerType;
                    // add to list
                     neighbours.Add(dot.gameObject);
                    // Grow selected node 
                     dot.gameObject.GetComponent<DotScript>().GrowSize = true;
                    // 
                     DotManagerScript.GetComponent<DotManager>().NumberOfNeighbours += 1;
                    // if the node selected is not equal to the colour node before it end chain
                     if (dot.gameObject.tag != Colour)
                     {
                          OnMouseUp();
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
                if (DotManagerScript.RedSelection)
                {
                    if (DotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Red")
                    {



                    }
                    else if (!DotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Red")
                    {
                        hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                        // draws line renderer to hit position
                        DrawLine.SetPosition(DotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);
                        // increases linecount so it can be drawn onto the next peice
                        DotManagerScript.LineCount += 1;
                        // increase amount of line renderer positions
                        DrawLine.positionCount += 1;

                        if (DotManagerScript.LineCount < 2)
                        {
                            DrawLine.SetPosition(DotManagerScript.LineCount, transform.position);

                        }
                        else
                        {
                            DrawLine.SetPosition(DotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);

                        }

                        // adds hit.collider to Peices list
                        DotManagerScript.Peices.Add(hitInfo.collider.gameObject);

                    }
                    if (hitInfo.collider.gameObject.tag == "Gold" || hitInfo.collider.gameObject.tag == "Blue" || hitInfo.collider.gameObject.tag == "Yellow" || hitInfo.collider.gameObject.tag == "Green")
                    {
                        OnMouseUp();
                    }
                }
                // Checks for only Blue pieces
                if (DotManagerScript.BlueSelection)
                {
                    if (DotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Blue")
                    {



                    }
                    else if (!DotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Blue")
                    {
                        hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                        // draws line renderer to hit position
                        DrawLine.SetPosition(DotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);
                        // increases linecount so it can be drawn onto the next peice
                        DotManagerScript.LineCount += 1;
                        // increase amount of line renderer positions
                        DrawLine.positionCount += 1;

                        if (DotManagerScript.LineCount < 2)
                        {
                            DrawLine.SetPosition(DotManagerScript.LineCount, transform.position);

                        }
                        else
                        {
                            DrawLine.SetPosition(DotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);

                        }

                        // adds hit.collider to Peices list
                        DotManagerScript.Peices.Add(hitInfo.collider.gameObject);

                    }
                    if (hitInfo.collider.gameObject.tag == "Gold" || hitInfo.collider.gameObject.tag == "Red" || hitInfo.collider.gameObject.tag == "Yellow" || hitInfo.collider.gameObject.tag == "Green")
                    {
                        OnMouseUp();
                    }
                }
                // Checks for only Purple pieces
                if (DotManagerScript.PurpleSelection)
                {
                    if (DotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Yellow")
                    {



                    }
                    else if (!DotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Yellow")
                    {
                        hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                        // draws line renderer to hit position
                        DrawLine.SetPosition(DotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);
                        // increases linecount so it can be drawn onto the next peice
                        DotManagerScript.LineCount += 1;
                        // increase amount of line renderer positions
                        DrawLine.positionCount += 1;

                        if (DotManagerScript.LineCount < 2)
                        {
                            DrawLine.SetPosition(DotManagerScript.LineCount, transform.position);

                        }
                        else
                        {
                            DrawLine.SetPosition(DotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);

                        }

                        // adds hit.collider to Peices list
                        DotManagerScript.Peices.Add(hitInfo.collider.gameObject);
                    }
                        if (hitInfo.collider.gameObject.tag == "Gold" || hitInfo.collider.gameObject.tag == "Blue" || hitInfo.collider.gameObject.tag == "Green" || hitInfo.collider.gameObject.tag == "Red")
                        {
                            OnMouseUp();
                        }
                }
                // Checks for only yellow pieces
                if (DotManagerScript.YellowSelection)
                {
                    if (DotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Green")
                    {



                    }
                    else if (!DotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Green")
                    {
                        hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                        // draws line renderer to hit position
                        DrawLine.SetPosition(DotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);
                        // increases linecount so it can be drawn onto the next peice
                        DotManagerScript.LineCount += 1;
                        // increase amount of line renderer positions
                        DrawLine.positionCount += 1;

                        if (DotManagerScript.LineCount < 2)
                        {
                            DrawLine.SetPosition(DotManagerScript.LineCount, transform.position);

                        }
                        else
                        {
                            DrawLine.SetPosition(DotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);

                        }

                        // adds hit.collider to Peices list
                        DotManagerScript.Peices.Add(hitInfo.collider.gameObject);
                        
                    }
                    if (hitInfo.collider.gameObject.tag == "Blue" || hitInfo.collider.gameObject.tag == "Red" || hitInfo.collider.gameObject.tag == "Yellow" ||
                        hitInfo.collider.gameObject.tag == "Gold")
                    {
                        OnMouseUp();
                    }
                }
                if (DotManagerScript.GoldSelection)
                {
                    if (DotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Gold")
                    {



                    }
                    else if (!DotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == "Gold")
                    {
                        hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                        // draws line renderer to hit position
                        DrawLine.SetPosition(DotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);
                        // increases linecount so it can be drawn onto the next peice
                        DotManagerScript.LineCount += 1;
                        // increase amount of line renderer positions
                        DrawLine.positionCount += 1;

                        if (DotManagerScript.LineCount < 2)
                        {
                            DrawLine.SetPosition(DotManagerScript.LineCount, transform.position);

                        }
                        else
                        {
                            DrawLine.SetPosition(DotManagerScript.LineCount, hitInfo.collider.gameObject.transform.position);

                        }

                        // adds hit.collider to Peices list
                        DotManagerScript.Peices.Add(hitInfo.collider.gameObject);

                    }
                    if (hitInfo.collider.gameObject.tag == "Blue" || hitInfo.collider.gameObject.tag == "Yellow" || hitInfo.collider.gameObject.tag == "Green"
                         || hitInfo.collider.gameObject.tag == "Red")
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
                DotManagerScript.ResetMaterial = true;
                OnMouseUp();
            }
           
        }
   
    }
 
    public void OnMouseUp()
    {
 
        // Resets Linerenderer
        DrawLine.positionCount = 1;

        // turns off highlite
        ToggleHighlite = 0;
        DotManagerScript.ResetMaterial = false;
        // Resets peices material and layer
        this.gameObject.layer = LayerMask.GetMask("Default");
        gameObject.layer = 0;
        // makes peices unable to grow
        GrowSize = false;
        // Resets neighbour list
        ClearNeighbours = true;
        // Goes into DotManagerScript to check if there was a connection
        DotManagerScript.CheckConnection = true;
        DotManagerScript.MouseCursorObj.SetActive(false);

        // Resets size of peices  
         Vector3 newScale = new Vector3();
         newScale.x = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
         newScale.z = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
         newScale.y = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
         transform.localScale = newScale;
        DotManagerScript.StartHighliting = false;
 

    }

}