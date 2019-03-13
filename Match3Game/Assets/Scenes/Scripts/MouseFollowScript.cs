using UnityEngine;
using System.Collections;

public class MouseFollowScript : MonoBehaviour
{

    public float Distance = 0;
 
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        Vector2 Pos = ray.GetPoint(Distance);
        transform.position = Pos;
    }
}
