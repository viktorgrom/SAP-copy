using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppLovinInterstitial : MonoBehaviour
{
   /*// public Dev2dev dev2Dev;
   // public AppsFlyerObject appsFlyerObject;
    [SerializeField] private AudioSource mMusicBackgroundSource;
    private int _musicPref;
    public bool success = false;

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

            InitInterstitial();
        };


        MaxSdk.SetSdkKey("uvdwP7XF8RM1QyDmosTEP61VawhovyXEbSwIJ91flhTlh8kRGvMnZ_4DSvo5Kv0SAxrAlrG2bpn2tD2hBJqZba");
        MaxSdk.InitializeSdk();


        //  mMusicBackgroundSource = GetComponent<AudioSource>();
    }

    private void InitInterstitial()
    {
        // Attach callback
        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;

        // Load the first interstitial
        LoadInterstitial();
    }

    public void LoadInterstitial()
    {
        MaxSdk.LoadInterstitial(adUnitId);

        success = false;
    }

    public void ShowInterstitial()
    {
        if (MaxSdk.IsInterstitialReady(adUnitId))
        {
            MaxSdk.ShowInterstitial(adUnitId);
        }
    }


    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is ready for you to show. MaxSdk.IsInterstitialReady(adUnitId) now returns 'true'

        // Reset retry attempt
        retryAttempt = 0;
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)

        retryAttempt++;
        double retryDelay = Math.Pow(2, Math.Min(6, retryAttempt));

        Invoke("LoadInterstitial", (float)retryDelay);
    }

    private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        _musicPref = PlayerPrefs.GetInt("music", 0);*/

        /* if(_musicPref == 0)
         {
             mMusicBackgroundSource.mute = true;
         }*/

      //  dev2Dev.Dev2devLogAdsShow();
      //  appsFlyerObject.AppsFlyerEventShowAds();
  /*  }

    private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad failed to display. AppLovin recommends that you load the next ad.
        LoadInterstitial();
    }

    private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }

    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is hidden. Pre-load the next ad.
        LoadInterstitial();
        //  mMusicBackgroundSource.mute = false;
    }*/

}
