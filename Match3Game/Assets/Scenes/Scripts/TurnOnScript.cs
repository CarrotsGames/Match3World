using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnOnScript : MonoBehaviour
{

   private void OnMouseDrag()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hitInfo.collider != null)
        {
             gameObject.GetComponent<DotScript>().enabled = true;

            Debug.Log("MOUSEHITME");
        }
    }
}
