using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCharacter : MonoBehaviour
{
    public void LoadKoko()
    {
        GameObject Settings = GameObject.Find("Settings");
        Settings.GetComponent<settings>().SaveData();
        Settings.GetComponent<settings>().PushAnalytics();
        SceneManager.LoadScene("Triangle Scene"); 
    }
    public void LoadBinkie()
    {
        GameObject Settings = GameObject.Find("Settings");
        Settings.GetComponent<settings>().SaveData();
        Settings.GetComponent<settings>().PushAnalytics();
        SceneManager.LoadScene("Circle Scene");
    }
}
