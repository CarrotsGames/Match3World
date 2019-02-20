using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Nodes : MonoBehaviour
{
    public Transform CameraPosition;
    public List<Nodes> ReachableNodes = new List<Nodes>();
    [HideInInspector]
    public Collider2D col;
    // Use this for initialization
    void Start()
    {
        col = GetComponent<Collider2D>();
    }
 
}
