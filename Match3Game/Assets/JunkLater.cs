﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JunkLater : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoHome()
    {
        SceneManager.LoadScene("Main Screen");
    }

    public void LoadStore()
    {
        SceneManager.LoadScene("StoreScene");
    }




}