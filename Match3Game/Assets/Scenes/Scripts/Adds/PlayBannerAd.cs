using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;
using UnityEngine.SceneManagement;

public class PlayBannerAd : MonoBehaviour
{
    public string gameId = "3222685";
    public string placementId = "OpeningSceneBanner";
    public bool testMode = true;
    string SceneName;
    
    void Start()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneName = CurrentScene.name;
        Advertisement.Initialize(gameId, testMode);
        
    }
    private void Update()
    {
        if(SceneName == "Book")
        {
          //Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
          Advertisement.Banner.Show(placementId);
        }
        else
        {
            Advertisement.Banner.Hide();
        }

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