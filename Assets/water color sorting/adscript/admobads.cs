using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GoogleMobileAds.Api;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class admobads : MonoBehaviour {
	/*bool hidebanner;
	
	public string appid;
	public string bannerid;
	public string intersitialid;
	//rewardedvideo ad
	public string admobrewardedvideoid;
	private RewardedAd rewardbasedad;
	//end
	private BannerView bannerview;
	InterstitialAd interstitial;
	AdRequest bannerrequest;
	AdRequest interstialrequest;
	string agefilter;
	Scene m_scene;
	int privacyvalue;
	int removeadvalue;
    int rewardedvalue,npavalue;
	// Use this for initialization
	void Start () {
        npavalue= PlayerPrefs.GetInt("NPAValue", 0);
        agefilter = PlayerPrefs.GetString ("agecheck");
		privacyvalue = PlayerPrefs.GetInt ("privacyvalue",0);
        MobileAds.Initialize(initStatus => { });
      //  MobileAds.Initialize (appid);
			print ("againrun");
	     	requestbanner ();
			requestintersitial ();

        this.rewardbasedad = new RewardedAd(admobrewardedvideoid);
        //	this.rewardbasedad = RewardBasedVideoAd.Instance;
        // Called when the user should be rewarded for watching a video.
      //  rewardbasedad.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardbasedad.OnUserEarnedReward += HandleRewardBasedVideoRewarded;
        this.requestrewardbasedvideo ();
	}
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        if (rewardedvalue == 1)
        {
            prefmanager.instance.SetcoinsValue(prefmanager.instance.Getcoinsvalue() + 100);
        }else if(rewardedvalue == 2)
        {
            int value = prefmanager.instance.Gettubevalue();
            value++;
            print("Total Value" + value);
            prefmanager.instance.SettubeValue(value);
            UIManager.instance.Setaddtubeandhintvalue();
        }
        else if (rewardedvalue == 3)
        {
            int value = prefmanager.instance.Gethintvalue();
            value++;
            prefmanager.instance.SetHintValue(value);
            UIManager.instance.Setaddtubeandhintvalue();
        }
        else if (rewardedvalue == 4)
        {

            UIManager.instance.SkipLevel();
        }

        this.requestrewardbasedvideo();
        //
    }
    private void requestrewardbasedvideo(){
		//	AdRequest request = new AdRequest.Builder ().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build ();
		//	AdRequest request = new AdRequest.Builder().AddExtra("max_ad_content_rating", agefilter).Build();
		AdRequest request = new AdRequest.Builder().AddExtra("npa",npavalue.ToString()).Build();
        this.rewardbasedad.LoadAd(request);
       // this.rewardbasedad.LoadAd (request,admobrewardedvideoid);
	}
	//show rewarded video ad

	public void showad(int n){
        rewardedvalue = n;

        if (rewardbasedad.IsLoaded()){
            rewardbasedad.Show ();
		}
	}
	void Update(){
		//loading = Resources.FindObjectsOfTypeAll (typeof(GameObject));
		m_scene = SceneManager.GetActiveScene ();
		//if(m_scene.name=="Main"){
			removeadvalue = PlayerPrefs.GetInt ("removeads",0);
			if(bannerview!=null){
			//	bannerview.SetPosition (AdPosition.Top);
			//	showBanner ();
            }
            else
            {
              //  requestbanner();
            }
	//	}
			
	}
	public void requestbanner(){

		removeadvalue = PlayerPrefs.GetInt ("removeads",0);
        if (removeadvalue != 1)
        {
            if (bannerview == null)
            {
                agefilter = PlayerPrefs.GetString("agecheck");
                AdSize adaptiveSize =
                AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
                bannerview = new BannerView(bannerid, adaptiveSize, AdPosition.Bottom);
                //	bannerrequest = new AdRequest.Builder ().AddTestDevice ("2077ef9a63d2b398840261c8221a0c9b").Build ();
                //		bannerrequest = new AdRequest.Builder().AddExtra("max_ad_content_rating", agefilter).Build();
                bannerrequest = new AdRequest.Builder().AddExtra("npa", npavalue.ToString()).Build();
                bannerview.LoadAd(bannerrequest);
            }
            else
            {
                showBanner();
            }

        }
	}

	//hide banner ads

	public void requestintersitial(){
        if (removeadvalue != 1)
        {
            agefilter = PlayerPrefs.GetString("agecheck");
            interstitial = new InterstitialAd(intersitialid);
            //	bannerrequest = new AdRequest.Builder ().AddTestDevice ("2077ef9a63d2b398840261c8221a0c9b").Build ();
            //bannerrequest =new AdRequest.Builder().AddExtra("max_ad_content_rating", agefilter).Build();
            bannerrequest = new AdRequest.Builder().AddExtra("npa", npavalue.ToString()).Build();
            interstitial.LoadAd(bannerrequest);
        }
	}




	public void showinterstialad(){
        if (removeadvalue != 1)
        {
            interstitial.Show();
        }

	}
//	public void loadinterstitialad(){
//		interstitial = new InterstitialAd (intersitialid);
//		interstialrequest=new AdRequest.Builder().AddExtra("max_ad_content_rating", agefilter).Build();
//		interstitial.LoadAd (interstialrequest);
//	}
	public void HideBanner(){
		if(bannerrequest!=null){
		      bannerview.Hide ();
		}
	}
	public void showBanner(){
        if (removeadvalue != 1)
        {

            if (bannerrequest != null)
            {
                bannerview.Show();
            }
            else
            {
                requestbanner();
            }
        }
		
	}
	public void OnDestroybanner(){
		if (bannerrequest != null) {
			bannerview.Destroy ();
		}
	}*/

}
