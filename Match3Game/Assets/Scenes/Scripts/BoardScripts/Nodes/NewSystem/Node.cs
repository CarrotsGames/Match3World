using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public float defultSize = 2.5f;
    public float jucSize = 3;
    public bool SelfDestruct;
    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (SelfDestruct)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Destroy(this.gameObject);
                SelfDestruct = false;
            }
        }
    }
   public void OnMouseEnter()
    {
        Vector3 newScale = new Vector3();
        newScale.x = Mathf.Clamp(transform.localScale.y, jucSize, jucSize);
        newScale.z = Mathf.Clamp(transform.localScale.y, jucSize, jucSize);
        newScale.y = Mathf.Clamp(transform.localScale.y, jucSize, jucSize);
        transform.localScale = newScale;
    }
    public void OnMouseExit()
    {
        Vector3 newScale = new Vector3();
        newScale.x = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
        newScale.z = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
        newScale.y = Mathf.Clamp(transform.localScale.y, defultSize, defultSize);
        transform.localScale = newScale;
       // HasPlayedSound = true;
    }
}
