using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds 
{


//    1012932
	// Use this for initialization


    public static void ShowAdvertisement()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    public static void ShowRewardedAdvertisement()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = RewardMethod };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    public static void RewardMethod(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.Log("Video Failed to load!");
                break;
            case ShowResult.Skipped:
                Debug.Log("Video Skipped!");
                break;
            case ShowResult.Finished:
                Debug.Log("You were Rewarded!");
                break;
        }

    }
}
