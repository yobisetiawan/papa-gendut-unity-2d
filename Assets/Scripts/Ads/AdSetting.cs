using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdSetting
{
    //get this in the project unity dashboard 
#if UNITY_IOS
    public string gameId = "3834372";
#elif UNITY_ANDROID
    public string gameId = "3834373";
#endif


    public string placementBannerId = "bannerPlacement";
    public string placementInterstitialId = "video";
    public string placementRewardedVideoId = "rewardedVideo";


    public bool testMode = true;

}
