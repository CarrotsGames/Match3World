using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class PlayAdd : MonoBehaviour
{
    public string gameId = "3192812";
    public bool testMode = false;
    public string placementId;

    //Located in Canvas
    public GameObject EventsGameObj;
    private void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }
    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.O))
        //{
        //    PlayAdNow();
        //}
    }
    public void PlayDailySpinAd()
    {
        if (EventsGameObj.GetComponent<EventScript>().CanDoDaily == true)
        {
            Advertisement.Show(placementId);
            Debug.Log("PLAYED SPIN AD");
        }
    }

    public void PlayAdNow()
    {
       Advertisement.Show();
       //Debug.Log("PLAYED AD");
    }
}
