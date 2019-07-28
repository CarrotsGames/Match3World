using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;
 public class PlayBannerAd : MonoBehaviour
{
    public string gameId = "3222685";
    public string placementId = "OpeningSceneBanner";
    public bool testMode = true;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        
    }
    private void Update()
    {
        //Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(placementId);
    }


    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

  //  IEnumerator ShowBannerWhenReady()
  //  {
  //      while (!Advertisement.IsReady(placementId))
  //      {
  //        
  //
  //          yield return new WaitForSeconds(0.5f);
  //      }
  //
  //  }
}