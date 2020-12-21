using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    public static AdManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } 
    }


    private AdSetting adSetting = new AdSetting();
    public static Action OnFinishADRewarded; 


    private void Start()
    { 
        Advertisement.AddListener(this);
        Advertisement.Initialize(adSetting.gameId, adSetting.testMode);
    } 

    public void MyShowInterstitialAD()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(adSetting.placementInterstitialId))
        {
            Advertisement.Show(adSetting.placementInterstitialId);
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    } 

    public void MyShowRewardedAD()
    {
        bool isReady = Advertisement.IsReady(adSetting.placementRewardedVideoId);
        // Check if UnityAds ready before calling Show method:
        if (isReady)
        {
            Advertisement.Show(adSetting.placementRewardedVideoId);
        } 
    }

    //================================ Ads Process  ================================================   

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    { 
        if (showResult == ShowResult.Finished)
        {
            if(placementId == adSetting.placementRewardedVideoId)
            {
                if (OnFinishADRewarded != null) { OnFinishADRewarded(); }
            } 
        }
        
        /*else if (showResult == ShowResult.Skipped) { }
        else if (showResult == ShowResult.Failed) { }*/
    }

    public void OnUnityAdsReady(string placementId) { }

    public void OnUnityAdsDidError(string message) { }

    public void OnUnityAdsDidStart(string placementId){  }



    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }


}
