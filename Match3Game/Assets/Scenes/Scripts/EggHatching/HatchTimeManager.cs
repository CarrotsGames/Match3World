using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchTimerManager : MonoBehaviour {
    public static HatchTimerManager sharedInstance = null;
    private string _url = "https://screamingchilligam.wixsite.com/chillicountdown";
    private string _timeData;
    private string _currentTime;
    private string _currentDate;


    //make sure there is only one instance of this always.
    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else if (sharedInstance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    //time fether coroutine
    public IEnumerator getTime()
    {
        Debug.Log("==> step 1. Getting info from internet now!");
        WWW www = new WWW(_url);
        yield return www;
        Debug.Log("==> step 2. Got the info from internet!");
        _timeData = www.text;
        string[] words = _timeData.Split('/');
        //timerTestLabel.text = www.text;
        Debug.Log("The date is : " + words[0]);
        Debug.Log("The time is : " + words[1]);

        //setting current time
        _currentDate = words[0];
        _currentTime = words[1];
    }


    //get the current time at startup
    void Start()
    {
        Debug.Log("==> TimeManager script is Ready.");
        StartCoroutine("getTime");
    }

    //get the current date
    public string getCurrentDateNow()
    {
        return _currentDate;
    }


    //get the current Time
    public string getCurrentTimeNow()
    {
        return _currentTime;
    }


}