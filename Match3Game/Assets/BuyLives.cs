using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class BuyLives : MonoBehaviour
{
    GameObject PowerUpGameObj;
    GameObject Challenges;
    private void Start()
    {
        PowerUpGameObj = GameObject.FindGameObjectWithTag("PUM");
        Challenges = GameObject.Find("CHALLENGE");
    }
    public void InGameCurrencyPurchase()
    {
        if (PowerUpGameObj.GetComponent<PowerUpManager>().Currency > 50)
        {
            Lives.LiveCount = 1;
            PlayerPrefs.SetInt("LIVECOUNT", Lives.LiveCount);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            PowerUpGameObj.GetComponent<PowerUpManager>().Currency -= 50;
        }
        else
        {
            Debug.Log("not enough coins");
        }
    }
}
