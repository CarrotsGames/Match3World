using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// USE ME AT END OF SPLASHSCREEN
public class FirstTimeStartup : MonoBehaviour
{
    private int FirstTime;
   
   public void StartGame()
    {
        FirstTime = PlayerPrefs.GetInt("FTS");
        if (FirstTime >= 1)
        {
            SceneManager.LoadScene("Main Screen");

        }
        else
        {
            SceneManager.LoadScene("Gobu Tut");

            FirstTime = 1;
            PlayerPrefs.SetInt("FTS", 1);
        }
    }

}
