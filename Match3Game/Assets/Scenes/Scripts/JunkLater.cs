using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JunkLater : MonoBehaviour {

    private GameObject settings;
	// Use this for initialization
	void Start () {
        settings = GameObject.Find("Settings");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoHome()
    {
        if (!GameObject.Find("Store"))
        {
            settings.GetComponent<settings>().LoadMain();
        }
        SceneManager.LoadScene("Main Screen");
    }

    public void LoadStore()
    {
        SceneManager.LoadScene("StoreScene");
    }

    public void LoadMoney()
    {

        SceneManager.LoadScene("Money Store");
    }
    public void LoadTut()
    {
        SceneManager.LoadScene("Main Screen Tut");
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }




}
