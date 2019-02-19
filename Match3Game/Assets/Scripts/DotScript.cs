using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DotScript : MonoBehaviour
{
    public int Column;
    public int Row;
    public LayerMask layerMask;
    public float Raylength;
    RaycastHit Hit;
    DotManagerScript DotManagerScript;
    GameObject DotManagerObj;
    private BoardScript Board;
    private GameObject OtherDot;
 
     bool hasBeenTouched;
    // Use this for initialization
    void Start()
    {
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManagerScript>();
        Board = FindObjectOfType<BoardScript>();
 
        hasBeenTouched = true;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnMouseDrag()
    {

       RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
       if (hitInfo.collider != null)
       {
            if(DotManagerScript.Peices.Contains(hitInfo.collider.gameObject))
            {

            }
            else
            {
                DotManagerScript.Peices.Add(hitInfo.collider.gameObject);

            }
            Debug.Log(hitInfo.collider.name);
       }
         
    }

    private void OnMouseUp()
    {
        DotManagerScript.CheckConnection = true;
    }


}