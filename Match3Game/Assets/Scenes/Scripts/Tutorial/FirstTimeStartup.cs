using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// USE ME AT END OF SPLASHSCREEN
public class FirstTimeStartup : MonoBehaviour
{
    private int FirstTime;
    // Start is called before the first frame update
    void Start()
    {
        FirstTime = PlayerPrefs.GetInt("FTS");
        if (FirstTime >= 1)
        {
            SceneManager.LoadScene("Main Screen");

        }
        else 
        {
            SceneManager.LoadScene("Gobu Tut");
        }
    }

    
}
