using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeFreeze : MonoBehaviour {

    public float FreezeTimer;
    public GameObject DotManager;
    private DotManager DotManagerScript;
    public Material FreezeMaterial;
    float FreezeColourTime;
    private bool Freeze;
    // Use this for initialization
    void Start () {
        DotManager = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManager.GetComponent<DotManager>();
        Freeze = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Freeze)
        {
            if (FreezeColourTime < 1)
            {
                FreezeColourTime += Time.deltaTime / 2;
                // GetComponent<SpriteRenderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, FreezeMaterial.color, FreezeColourTime);
                transform.GetChild(0).GetComponent<SpriteRenderer>().material = FreezeMaterial;
            }
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "FreezeZone")
        {
            FreezeTimer -= Time.deltaTime;
          

            if (FreezeTimer < 0)
            {
                Freeze = true;
                GetComponent<DotScript>().Frozen = true;               
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            }
        
        }

    }
}
