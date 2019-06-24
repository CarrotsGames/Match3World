using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeZones : MonoBehaviour {
    int rng;
    public GameObject[] FreezePos;
    public GameObject FreezeZonePrefab;
    private GameObject CurrentZone;
	// Use this for initialization
	void Start ()
    {
        rng = Random.Range(0, FreezePos.Length);
        CurrentZone =  Instantiate(FreezeZonePrefab, FreezePos[rng].transform.position, FreezePos[rng].transform.rotation);
 	}
	
	// Update is called once per frame
	void Update ()
    {
		if(CurrentZone == null)
        {
            rng = Random.Range(0, FreezePos.Length);
            CurrentZone = Instantiate(FreezeZonePrefab, FreezePos[rng].transform.position, FreezePos[rng].transform.rotation);
        }
	}
}
