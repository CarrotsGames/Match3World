using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour {
    public GameObject scoreboard;
    float FirstTimeStartUp;

    public GameObject hungerBar;

    public void Awake()
    {
        FirstTimeStartUp = PlayerPrefs.GetFloat("FTS");
        if (FirstTimeStartUp > 0)
        {
            scoreboard.SetActive(false);
        }
        hungerBar.SetActive(false);

    }
  
   
}
