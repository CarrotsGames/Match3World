using UnityEngine;
using System.Collections;

public class LookAtScript : MonoBehaviour
{

    public float Speed;
    public float Limit;
    private Vector3 center;

    private void Start()
    {
        // referneces Starting position 
        center = transform.position;
    }
    private void Update()
    {
        // Gets position of mouse
        Vector3 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Pos.z = 0.0f;
        //moves eyes position towards position of mouse 
        Vector3 Direction = (Pos - transform.position) * Speed;
        // Clamps Position of eyes by limit
        Direction = Vector3.ClampMagnitude(Direction, Limit);
        // Moves eyes 
        Vector3 Eyeroll = center + Direction;
        transform.position = center + Direction;
    }

}
