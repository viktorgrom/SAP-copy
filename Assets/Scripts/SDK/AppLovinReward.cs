using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppLovinReward : MonoBehaviour
{
   // public Dev2dev dev2Dev;
   // public AppsFlyerObject appsFlyerObject;

/*
    [SerializeField] private AudioSource mMusicBackgroundSource;
    private int _musicPref;
    public bool adsVideoLoaded = false;
    
    // 1 = fuel, 2 = engine, 3 = money
    private int _numberOfUpgrateSlot;
    private int _getBonusTrue;
    // public bool readyAdsVideo = false;
    [SerializeField] string adUnitIdAndroid;
    [SerializeField] string adUnitIdiOS;
    string adUnitId;
    int retryAttempt;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
            adUnitId = adUnitIdAndroid;
        else
            adUnitId = adUnitIdiOS;

        MaxSdkCallbacks.OnSdkInitializedEvent += sdkConfiguration =>
        {

            InitializeRewardedAds();
        };

        MaxSdk.SetSdkKey("uvdwP7XF8RM1QyDmosTEP61VawhovyXEbSwIJ91flhTlh8kRGvMnZ_4DSvo5Kv0SAxrAlrG2bpn2tD2hBJqZba");
        MaxSdk.InitializeSdk();

        //  mMusicBackgroundSource = GetComponent<AudioSource>();
    }


    public void InitializeRewardedAds()
    {
        // Attach callback
        MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
        MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdLoadFailedEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
        MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
        MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedAdRevenuePaidEvent;
        MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdHiddenEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;

        // Load the first rewarded ad
        LoadRewardedAd();
    }

    public void LoadRewardedAd()
    {
        MaxSdk.LoadRewardedAd(adUnitId);


    }

    public void CheckReadyVideo(bool isReady)
    {
        if (MaxSdk.IsRewardedAdReady(adUnitId))
        {
            isReady = true;
        }
        else
        {
            isReady = false;
        }
    }

    public void ShowRewardAd()
    {
        if (MaxSdk.IsRewardedAdReady(adUnitId))
        {
            MaxSdk.ShowRewardedAd(adUnitId);
        }
    }

    private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {

        // Rewarded ad is ready for you to show. MaxSdk.IsRewardedAdReady(adUnitId) now returns 'true'.

        adsVideoLoaded = true;

        // Reset retry attempt
        retryAttempt = 0;
    }

    private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {

        adsVideoLoaded = false;
        // Rewarded ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds).

        retryAttempt++;
        double retryDelay = Math.Pow(2, Math.Min(6, retryAttempt));

        Invoke("LoadRewardedAd", (float)retryDelay);
    }

    private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        _musicPref = PlayerPrefs.GetInt("music", 0);



       // dev2Dev.Dev2devLogAdsShow();
      //  appsFlyerObject.AppsFlyerEventShowAds();
    }

    private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad failed to display. AppLovin recommends that you load the next ad.
        LoadRewardedAd();*/

        /* if (_musicPref == 0)
         {
             mMusicBackgroundSource.mute = true;
         }*/
  /*  }

    private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {

    }

    private void OnRewardedAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is hidden. Pre-load the next ad
        Debug.Log("unity-script: I got RewardedVideoAdClosedEvent");
        LoadRewardedAd();

        //  mMusicBackgroundSource.mute = false;
        PlayerPrefs.SetInt("BonusStarted", 0);

    }

    private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
    {
        // The rewarded ad displayed and the user should receive the reward.


        _getBonusTrue = PlayerPrefs.GetInt("BonusStarted");

        if (_getBonusTrue == 1)
        {
            
            PlayerPrefs.SetInt("BonusStarted", 0);
        }

        _numberOfUpgrateSlot = PlayerPrefs.GetInt("AdsUpgrate");


    }

    private void OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Ad revenue paid. Use this callback to track user revenue.

        // Update is called once per frame

    }*/
}