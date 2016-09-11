using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using GoogleMobileAds.Api;

public class AdMob : MonoBehaviour {
	BannerView bannerView;
	InterstitialAd interstitial;

	// Use this for initialization
	void Awake () {
        RequestBanner();
        bannerView.Hide();
        DontDestroyOnLoad(gameObject);
	}
	
    void Start ()
    {

    }

	// Update is called once per frame
	void Update () {
	
	}

	private void RequestBanner ()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-3902298493650266/4176030236";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-3902298493650266/2468637830";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
	}

	private void RequestInterstitial ()
	{
		#if UNITY_ANDROID
		string adUnitId = "INSERT_ANDROID_INTERSTITIAL_AD_UNIT_ID_HERE";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}

    public void bannerHide ()
    {
        bannerView.Hide();
        bannerView.LoadAd(new AdRequest.Builder().Build());
    }

    public void bannerShow()
    {
        bannerView.Show();
    }
}
