using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeFreeze : MonoBehaviour {

    public float FreezeTimer;
    public GameObject DotManager;
    private DotManager DotManagerScript;

    // Use this for initialization
    void Start () {
        DotManager = GameObject.FindGameObjectWithTag("DotManager");
        DotManagerScript = DotManager.GetComponent<DotManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "FreezeZone")
        {
            FreezeTimer -= Time.deltaTime;
            if(FreezeTimer < 0)
            {
               GetComponent<DotScript>().Frozen = true;

                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;

            }
            Debug.Log("FREEZEZONE");

        }

    }
}
