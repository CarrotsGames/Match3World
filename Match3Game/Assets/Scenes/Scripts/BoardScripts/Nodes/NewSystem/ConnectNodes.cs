using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectNodes : MonoBehaviour
{
    string Colour;
    bool TestThis;
    public DotManager DotManagerScript;
    private GameObject DotManagerObj;
    // Start is called before the first frame update
    void Start()
    {
        TestThis = true;
        DotManagerObj = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManagerObj.GetComponent<DotManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Debug.Log("ButtonDown");
            MouseTrace();
        
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("ButtonUp");
            TestThis = true;
            DotManagerScript.CheckConnection = true;

        }
    }
    private void MouseTrace()
    {     
        RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hitInfo.collider != null)
        {
           //  hitInfo.transform.GetComponent<Node>().DefaultScale();
            if (hitInfo.transform.gameObject.layer == 17)
            {
                if (TestThis)
                {
                    Debug.Log(hitInfo.collider.gameObject.tag);
                    Colour = hitInfo.transform.gameObject.tag;
                    TestThis = false;
                }
                if (hitInfo.collider.gameObject.tag == Colour && !DotManagerScript.Peices.Contains(hitInfo.collider.gameObject))
                {
                  //  hitInfo.transform.GetComponent<Node>().JuiceScale();
                    hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;

                    DotManagerScript.Peices.Add(hitInfo.collider.gameObject);
                     Debug.Log("START COMBO");
                }
                else
                {
                    Debug.Log("END COMBO");
                }

                // GET DOTMANAGER LIST TO ADD THESE NODES INTO

            }

        }
        
    }
}
