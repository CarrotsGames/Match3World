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
        hasBeenTouched = true;
      }

    // Update is called once per frame
    void Update()
    {
        TargetX = Column;
        TargetY = Row;
    }
    private void OnMouseDrag()
    {       
        if(!hasBeenTouched)
        { 
         FirstTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         Test.Peices.Add(this.gameObject);
         hasBeenTouched = true;
        }
         //NavigateThroughPieces();

    }

    private void OnMouseUp()
    {
        Debug.Log("MouseUp");
        for (int i = 0; i < Test.Peices.Capacity; i++)
        {
            Debug.Log("TEST" + i);
        }
    }

    //  void CalculateAngle()
    //  {
    //       if (gameObject.transform.position.x == FirstTouchPos.x && gameObject.transform.position.y == FirstTouchPos.y)
    //      {
    //          Debug.Log(gameObject);
    //      }
    //   }
    //
    //  void NavigateThroughPieces()
    //  {
    //      if(SwipeAngle > -45 && SwipeAngle <= 45)
    //      {
    //          // right swipe
    //          OtherDot = Board.AllDots[Column , Row];
    //           Debug.Log(OtherDot);
    //        }
    //      else  if (SwipeAngle > 45 && SwipeAngle <= 185)
    //      {
    //          // up swipe
    //          
    //      }
    //      else if (SwipeAngle > -135 || SwipeAngle <= 135)
    //      {
    //          // left swipe
    //        
    //      }
    //      else if (SwipeAngle < -45 && SwipeAngle >= 45)
    //      {
    //          // Down swipe
    //        
    //      }
    //  }

}