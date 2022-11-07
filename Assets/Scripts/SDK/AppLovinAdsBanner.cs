using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AppLovinAdsBanner : MonoBehaviour
{
   /* [SerializeField] string bannerAdUnitIDAndroid;
    [SerializeField] string bannerAdUnitIDiOs;
    //[SerializeField] string skKey; 
    // [SerializeField] string userId; 
    string bannerAdUnitId;

    public bool mBunnerLoaded;

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
            bannerAdUnitId = bannerAdUnitIDAndroid;
        else
            bannerAdUnitId = bannerAdUnitIDiOs;


        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
        {
            InitializeBannerAds();


        };

        MaxSdk.SetSdkKey("uvdwP7XF8RM1QyDmosTEP61VawhovyXEbSwIJ91flhTlh8kRGvMnZ_4DSvo5Kv0SAxrAlrG2bpn2tD2hBJqZba");
        // MaxSdk.SetUserId(userId);
        MaxSdk.InitializeSdk();


    }

    public void ShowAdsBanner()
    {
        if (mBunnerLoaded)
        {
            MaxSdk.ShowBanner(bannerAdUnitId);
            MaxSdkUtils.GetAdaptiveBannerHeight();
        }
        else
        {
            InitializeBannerAds();
        }

    }

    public void HideAdsBunner()
    {
        MaxSdk.HideBanner(bannerAdUnitId);
    }

    public void InitializeBannerAds()
    {
        // Banners are automatically sized to 320?50 on phones and 728?90 on tablets
        // You may call the utility method MaxSdkUtils.isTablet() to help with view sizing adjustments
        MaxSdk.CreateBanner(bannerAdUnitId, MaxSdkBase.BannerPosition.BottomCenter);
        MaxSdk.SetBannerExtraParameter(bannerAdUnitId, "adaptive_banner", "true");
        // Set background or background color for banners to be fully functional
        MaxSdk.SetBannerBackgroundColor(bannerAdUnitId, Color.white);

        MaxSdkCallbacks.Banner.OnAdLoadedEvent += OnBannerAdLoadedEvent;
        MaxSdkCallbacks.Banner.OnAdLoadFailedEvent += OnBannerAdLoadFailedEvent;
        MaxSdkCallbacks.Banner.OnAdClickedEvent += OnBannerAdClickedEvent;
        MaxSdkCallbacks.Banner.OnAdRevenuePaidEvent += OnBannerAdRevenuePaidEvent;
        MaxSdkCallbacks.Banner.OnAdExpandedEvent += OnBannerAdExpandedEvent;
        MaxSdkCallbacks.Banner.OnAdCollapsedEvent += OnBannerAdCollapsedEvent;
    }

    private void OnBannerAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {

        mBunnerLoaded = true;
        Debug.Log("bunner loaded");
    }

    private void OnBannerAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        Debug.Log("bunner loaded failed");
        mBunnerLoaded = false;
    }

    private void OnBannerAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }

    private void OnBannerAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }

    private void OnBannerAdExpandedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }

    private void OnBannerAdCollapsedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }*/

}
