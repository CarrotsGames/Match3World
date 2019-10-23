using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loadmoneystore : MonoBehaviour {
    


    public void LoadMoneyStore()
    {
        if (PlayFabLogin.HasLoggedIn == true)
        {
            SceneManager.LoadScene("Money Store");
        }
        else
        {
            Debug.Log("You must be online to access money store");
        }
    }

    public void LoadStore()
    {
        SceneManager.LoadScene("StoreScene");
    }
}
