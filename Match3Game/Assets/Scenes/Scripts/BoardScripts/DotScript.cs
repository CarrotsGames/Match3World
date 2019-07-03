﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DotScript : MonoBehaviour
{

    public float defultSize = 2.5f;
    public float jucSize = 3;
    public LayerMask layerMask;
    public List<GameObject> neighbours = new List<GameObject>();
    public int ToggleHighlite; 
    [HideInInspector]
    public bool DefaultColour;
    [HideInInspector]
    public bool GrowSize;
    [HideInInspector]
    public int LayerType = 10;
    private bool HasPlayedSound;
    private GameObject MainCamera;
    private BoardScript Board;
    private GameObject HappinessManagerGameobj;
    public HappinessManager HappinessManagerScript;
    public DotManager DotManagerScript;
    private GameObject DotManagerObj;
    private Material Default;
    private GameObject AudioManagerGameObj;
    private AudioManager AudioManagerScript;
    string Colour;
    public bool SelfDestruct;
    [HideInInspector]
    public float Timer;
    [HideInInspector]
    public bool Frozen;
    GameObject FlashingGameObj;
    bool ReleaseNodeColour;
    float ResetMatTime;
    float VibrateSeconds;
    float FlashColour;
    // Use this for initialization
    void Start()
    {
        Timer = 1.6f;
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        VibrateSeconds = 0;
        HappinessManagerGameobj = GameObject.FindGameObjectWithTag("HM");
        HappinessManagerScript = HappinessManagerGameobj.GetComponent<HappinessManager>();
        Physics2D.IgnoreLayerCollision(0, 14);
        AudioManagerGameObj = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManagerScript = AudioManagerGameObj.GetComponent<AudioManager>();
        //flashes node outline red when player failes connect
        ReleaseNodeColour = false;
        // Enables the node to grow when hihglited
        GrowSize = false;   
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
        Board = FindObjectOfType<BoardScript>();
        Default = GetComponent<Renderer>().material;
        HasPlayedSound = true;
        SelfDestruct = false;
        ReleaseNodeColour = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.tag == "Gold" && !HappinessManagerScript.IsSleeping)
        {
            Destroy(gameObject);
        }
        // Time until node destroys itself( Activated outside of script)
        if(SelfDestruct)
        {
            Timer -= Time.deltaTime;
            if(Timer <= 0)
            {
                Timer = 2;

                Destroy(this.gameObject);
                SelfDestruct = false;
            }
        }
        if (ReleaseNodeColour)
        {
            ResetMatTime += Time.deltaTime;
            FlashColour += Time.deltaTime;
            // flashes the node red to grab attention to player
            if(FlashColour < 0.25f)
            {
                FlashingGameObj.GetComponent<Renderer>().material.color = Color.red;

            }
            else
            {
                FlashingGameObj.GetComponent<Renderer>().material.color = Color.white;
                if (FlashColour > 0.5f)
                {
                    FlashColour = 0;
                }
            }
            // time until the highlite is returned to default
            if (ResetMatTime > 1)
            {
                // StopCoroutine(VibratePhone());
                FlashingGameObj.GetComponent<Renderer>().material.color = Color.white;

                ResetMatTime = 0;
                ReleaseNodeColour = false;
                VibrateSeconds = 0;
            }
            // Starts vibrating phone
            else
            {
                StartCoroutine(VibratePhone());
            }
         }
   
        // restes dot layer
        if (DotManagerScript.ResetLayer)
        {
            gameObject.layer = 0;
            DotManagerScript.ResetLayer = false;
        }
        // resets dot material 
        if (DotManagerScript.ResetMaterial && !ReleaseNodeColour)
        {
          this.gameObject.GetComponent<Renderer>().material = Default;
          this.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

    }
    // vibrates phone twice with delay inbetween
    IEnumerator VibratePhone()
    {
        if (VibrateSeconds <= 0.55f)
        {
            yield return new WaitForSeconds(VibrateSeconds);
            VibrateSeconds += 0.55f;
            Handheld.Vibrate();
            Debug.Log("VIBRATE");
        }
        else
        {
            yield break;
        }
    }
    // when the players finger left the node
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
            if (HasPlayedSound)
            {
                if (DotManagerScript.Peices.Count > 4)
                {
                    float clamp = Mathf.Clamp(DotManagerScript.Peices.Count / 5,0 , 1.25f);

                    MainCamera.GetComponent<CameraShake>().ShakeCamera(clamp / 4, 0.25f);
                }                // Plays the Node Highlite Sound
                AudioManagerScript.NodeSource.clip = AudioManagerScript.NodeAudio[0];
                AudioManagerScript.NodeSource.Play();
                HasPlayedSound = false;
            }
        }
        else
        {
            //  DotManagerScript.StartHighliting = false;
            Vector3 newScale = new Vector3();
            newScale.x = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
            newScale.z = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
            newScale.y = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
            transform.localScale = newScale;
             DotManagerScript.NodeSelection = false;
         
          //  DotManagerScript.ResetLayer = true;

        }
    }
    private void OnMouseDown()
    {
        if (DotManagerScript.CanPlay)
        {
            if (!Frozen)
            {
                if (!DotManagerScript.StartHighliting)
                {

                    DotManagerScript.Companion.EatingPeices.Clear();
                }
                DotManagerScript.StartHighliting = true;
                DotManagerScript.NodeSelection = true;
                // Checks which colout tag the mouse is interacting with to know which colour to focus on
                switch (transform.tag)
                {
                    case "Red":
                        Colour = "Red";

                        break;
                    case "Blue":
                        Colour = "Blue";

                        break;
                    case "Green":
                        Colour = "Green";

                        break;
                    case "Yellow":
                        Colour = "Yellow";
                        break;
                    case "Gold":
                        Colour = "Gold";
                        break;
                    case "COLLECTED":
                        OnMouseUp();
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
                // plays the node highlite sound
                AudioManagerScript.NodeSource.clip = AudioManagerScript.NodeAudio[0];
                AudioManagerScript.NodeSource.PlayOneShot(AudioManagerScript.NodeSource.clip);

                DotManagerScript.MouseCursorObj.SetActive(true);
            }
        }
    }
    private void OnMouseDrag()
    {
        DotScript[] Dots = FindObjectsOfType<DotScript>();
        bool CircleOverlap = Physics2D.OverlapCircle(transform.position, 1);
     
        // Chenges nodes layer and adds it into list to not be added again
        foreach (DotScript dot in Dots)
        {
            
            // if the Node is not the current node
            if (dot.gameObject.GetInstanceID() != gameObject.GetInstanceID())
             {
           
               if (!neighbours.Contains(dot.gameObject) && dot.gameObject.tag == Colour)
                 {
                    // change node layer to the layertype needed to connect nodes
                     dot.gameObject.layer = LayerType;
                    // add to list
                     neighbours.Add(dot.gameObject);
                    // Grow selected node 
                     dot.gameObject.GetComponent<DotScript>().GrowSize = true;                                   
                 }                       
           
            }

        }
    
     
        // Changes colour of the nodes outline
        RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hitInfo.collider != null)
        {
            if(DotManagerScript.StartHighliting)
            {
                if (hitInfo.collider.gameObject.layer == 10)
                {
                    // Checks for that specific colour pieces
                    if (DotManagerScript.NodeSelection)
                    {
                        if (!DotManagerScript.Peices.Contains(hitInfo.collider.gameObject) && hitInfo.collider.gameObject.tag == Colour)
                        {
                            hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
                            // adds hit.collider to Peices list
                            DotManagerScript.Peices.Add(hitInfo.collider.gameObject);
                        }
                        // if the colour is different from the current colour being connected stop chain
                        if (hitInfo.collider.gameObject.tag != Colour && hitInfo.collider.gameObject.layer == LayerType)
                        {
                            //hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                            FlashingGameObj = hitInfo.collider.gameObject;
                            FlashingGameObj.gameObject.GetComponent<Renderer>().material.color = Color.red;

                            ReleaseNodeColour = true;
                            Debug.Log("OffPattern");
                            OnMouseUp();
                        }
                    }
                }
                else if (hitInfo.collider.gameObject.layer == 0)
                {
                    FlashingGameObj = hitInfo.collider.gameObject;
                    ReleaseNodeColour = true;
                    FlashingGameObj.gameObject.GetComponent<Renderer>().material.color = Color.red;
                    OnMouseUp();
                }
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

        neighbours.Clear();
        this.transform.gameObject.layer = 0;
        // Resets Linerenderer

        // turns off highlite
        ToggleHighlite = 0;
        DotManagerScript.ResetMaterial = false;
        // Resets peices material and layer
        //this.gameObject.layer = LayerMask.GetMask("Default");
         // makes peices unable to grow
        GrowSize = false;
        // Resets neighbour list
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