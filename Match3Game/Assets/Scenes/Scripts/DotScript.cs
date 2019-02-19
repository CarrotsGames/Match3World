using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DotScript : MonoBehaviour
{
    public int Column;
    public int Row;
    public int TargetX;
    public int TargetY;
    RaycastHit Hit;
    CameraScript Test;
    GameObject CameraObj;
    private BoardScript Board;
    private GameObject OtherDot;
    private Vector2 FirstTouchPos;
    private Vector2 FinalTouchPos;
     public float SwipeAngle = 0;
    bool hasBeenTouched;
    // Use this for initialization
    void Start()
    {
        CameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        Test = CameraObj.GetComponent<CameraScript>();
        Board = FindObjectOfType<BoardScript>();
        TargetX = (int)transform.position.x;
        TargetY = (int)transform.position.y;
      }

    // Update is called once per frame
    void Update()
    {
        TargetX = Column;
        TargetY = Row;
    }
    private void OnMouseDrag()
    {       

         FirstTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         Test.Peices.Add(this.gameObject);
         //NavigateThroughPieces();

    }

    private void OnMouseUp()
    {
        Debug.Log("MouseUp");
        for (int i = 1; i < Test.Peices.Capacity; i++)
        {
            if (Test.Peices[i].tag == "Green")
            {
                Debug.Log("GREEN");
            }
            else
            {
                Debug.Log(" Not green");

            }
            Debug.Log("TEST" + i);
        }
    }

}