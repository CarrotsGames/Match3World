using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TimeMaster : MonoBehaviour {

    DateTime CurrentDate;
    DateTime OldDate;

    public String SaveLocation;
    public static TimeMaster instance;

    
	// Use this for initialization
	void Awake ()
    {
		
	}
 
}
