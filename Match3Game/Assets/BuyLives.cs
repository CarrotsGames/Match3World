using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

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
            PowerUpGameObj.GetComponent<PowerUpManager>().PowerUpSaves();
        }
        else
        {
            Debug.Log("not enough coins");
        }
    }
    public void PlayChallengeAd()
    {
 
        Advertisement.Show();    
        Lives.LiveCount += 1;
        PlayerPrefs.SetInt("LIVECOUNT", Lives.LiveCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Debug.Log("PLAYED AD");
     
    }
    public void PlayLivesAdMainScene()
    {
        GameObject OutOfLifeCanvas = GameObject.Find("OutOfLifeCanvus");
        Advertisement.Show();
        Lives.LiveCount += 1;
        PlayerPrefs.SetInt("LIVECOUNT", Lives.LiveCount);
        OutOfLifeCanvas.SetActive(false);
    }
 
    public void BuyThreeLives()
    {
        GameObject OutOfLifeCanvas = GameObject.Find("OutOfLifeCanvus");

        Lives.LiveCount = 3;
        PlayerPrefs.SetInt("LIVECOUNT", Lives.LiveCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        OutOfLifeCanvas.SetActive(false);

        //Debug.Log("PLAYED AD");

    }
}

