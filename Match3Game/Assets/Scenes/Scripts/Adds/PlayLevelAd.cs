using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class PlayLevelAd : MonoBehaviour
{
     public string gameId = "3222685";
    public string placementId;

    public bool testMode = false;
    //Located in Canvas
    private void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }
 
    public void PlayAdNow()
    {
        Advertisement.Show(placementId);

        Advertisement.Show();
        Debug.Log("PLAYED AD");
    }
}