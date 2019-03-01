using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLineScript : MonoBehaviour
{
    private LineRenderer Line;
    private float Counter;
    //distance of line between orign to destination
    private float LineDistance;

    // Current position
     public Transform Origin;
    // New position
     public List<GameObject> Destination = new List<GameObject>();
    // how fast line draws
    public float LineDrawSpeed = 6f;
    public bool DrawLine;

    // Use this for initialization
    void Start()
    {
        DrawLine = false;
           Line = GetComponent<LineRenderer>();
        Line.SetWidth(.45f, .45f);

    }

    // Update is called once per frame
    void Update()
    {
        Line.SetPosition(0, Origin.position);
               // LineDistance = Vector2.Distance(Origin.position, Destination[i].transform.position);

        if (Counter < LineDistance)
            {
            for (int i = 0; i < Destination.Count; i++)
            {


                Counter += .1f / LineDrawSpeed;
                float x = Mathf.Lerp(0, LineDistance, Counter);
                Vector3 PointA = Origin.position;
                Vector3 PointB = Destination[i].transform.position;

                Vector3 PointAlongLine = x * Vector3.Normalize(PointB - PointA) + PointA;
                
                Line.SetPosition(1, PointAlongLine);
            }
            }
         
    }
    private void OnMouseEnter()
    {
        Debug.Log("hit");

        RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hitInfo.collider != null)
        {
            Debug.Log("hit");
            Destination.Add(hitInfo.collider.gameObject);
                
        }
    }
}
