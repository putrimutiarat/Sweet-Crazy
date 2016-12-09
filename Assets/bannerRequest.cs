using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class bannerRequest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        RequestBanner();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-1969361650840725/1359583294";
#elif UNITY_IPHONE
                string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
                string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }
}
