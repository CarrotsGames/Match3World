using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine;
using System;


using GoogleMobileAds.Common;
public class PlayGoogleAd : MonoBehaviour
{
    private RewardBasedVideoAd RewardAd;
    private GameObject PowerUpManagerGameObj;
    // Start is called before the first frame update
    void Start()
    {
        PowerUpManagerGameObj = GameObject.Find("PowerUpManager");
       
        RewardAd = RewardBasedVideoAd.Instance;
        RewardAd.OnAdClosed += HandleOnAdClosed;
        RewardAd.OnAdFailedToLoad += HandleOnAdFailedToLoad; 
        RewardAd.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        RewardAd.OnAdLoaded += HandleOnAdLoaded;
        RewardAd.OnAdOpening += HandleOnAdOpening;
        RewardAd.OnAdRewarded += HandleOnAdRewarded;
        RewardAd.OnAdStarted += HandleOnAdStarted;
 
    }

    public  void ShowRewardAd()
    {
        if(RewardAd.IsLoaded())
        {
            RewardAd.Show();   
        }
        else
        {
            Debug.Log("Ads not ready yet....");
        }
         
    }
   public void LoadRewardedAd()
    {
        #if UNITY_EDITOR
        string AdUnitID = "ca-app-pub-6453336321724884/1616867641";
        #elif UNITY_ANDROID
        string AdUnitID = "ca-app-pub-6453336321724884/1616867641"
        #endif
        RewardAd.LoadAd(new AdRequest.Builder().Build(), AdUnitID);
        ShowRewardAd();
    }
    // These are the ad callback events that can be hooked into.
    public event EventHandler<EventArgs> OnAdLoaded;

    public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

    public event EventHandler<EventArgs> OnAdOpening;

    public event EventHandler<EventArgs> OnAdStarted;

    public event EventHandler<EventArgs> OnAdClosed;

    public event EventHandler<Reward> OnAdRewarded;

    public event EventHandler<EventArgs> OnAdLeavingApplication;

    public event EventHandler<EventArgs> OnAdCompleted;
    public void HandleOnAdLoaded(object Sender, EventArgs Gold)
    {

    }
    public void HandleOnAdFailedToLoad(object Sender, AdFailedToLoadEventArgs Gold)
    {
       
    }
    public void HandleOnAdOpening(object Sender, EventArgs Gold)
    {

    }
    public void HandleOnAdStarted(object Sender, EventArgs Gold)
    {

    }
    public void HandleOnAdClosed(object Sender, EventArgs Gold)
    {

    }
    public void HandleOnAdRewarded(object Sender, Reward Gold)
    {
        MonoBehaviour.print(String.Format("You Just got !", Gold.Amount, Gold.Type));
         
    }
    public void HandleOnAdLeavingApplication(object Sender, EventArgs Gold)
    {

    }
}

