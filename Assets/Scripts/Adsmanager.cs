using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Adsmanager : MonoBehaviour 
{
    private const string android_game_id = "2883511";
    private const string ios_game_id = "2883510";

    private const string rewarded_video_id = "rewardedVideo";

    static Adsmanager _instance;
    public static Adsmanager instance()
    {
        return _instance;
    }

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        Initialize();
    }

    private void Initialize()
    {
        #if UNITY_ANDROID
        Advertisement.Initialize(android_game_id);
        #elif UNITY_IOS
        Advertisement.Initialize(ios_game_id);
        #endif
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady(rewarded_video_id))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };

            Advertisement.Show(rewarded_video_id, options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                {
                    Debug.Log("The ad was successfully shown.");
                    Application.LoadLevel(1);
                    break;
                }
            case ShowResult.Skipped:
                {
                    Debug.Log("The ad was skipped before reaching the end.");
                    Application.LoadLevel(1);
                    break;
                }
            case ShowResult.Failed:
                {
                    Debug.LogError("The ad failed to be shown.");
                    break;
                }
        }
    }    
}
