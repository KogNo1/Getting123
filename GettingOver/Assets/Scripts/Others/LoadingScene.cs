using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : MonoBehaviour {

	//public static GoogleMobileAdsDemoScript ads = new GoogleMobileAdsDemoScript();

	public static bool showInter;

	private CanvasGroup fadeGroup;
	private float loadTime;
	private float LogoTime = 4.0f;

	void Awake(){
		showInter = false;
		if (SaveManager.instance.state.fadeInOut == true) {
			BackFadeFirstTime ();
		}
	}

	void Start(){
		fadeGroup = FindObjectOfType<CanvasGroup> ();
		fadeGroup.alpha = 1;

		if (Time.time < LogoTime) {
			loadTime = LogoTime;
		} else {
			loadTime = Time.time;
		}

		//ads.RequestBanner ();
		//ads.RequestInterstitial ();
		//ads.RequestRewardBasedVideo ();
		SaveManager.instance.state.isUnlockItemHat[0] = true;
		SaveManager.instance.Save ();
//		StartCoroutine (Loading ());
	}

	void Update () {
		if (Time.time < LogoTime) {
			fadeGroup.alpha = 1 - Time.time;
		}

		if (Time.time > LogoTime && loadTime != 0) {
			fadeGroup.alpha = Time.time - LogoTime;
			if (fadeGroup.alpha >= 1) {
				UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
			}
		}
	}

	IEnumerator Loading()
	{
		for (int i = 0; i < 120; i++)
		{
			yield return new WaitForEndOfFrame();
		}
		//ads.ShowBanner ();
		//ads.ShowInterstitial ();
		//ads.ShowRewardBasedVideo ();
		UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
	}

	void BackFadeFirstTime(){
		SaveManager.instance.state.fadeInOut = false;
		SaveManager.instance.Save ();
	}
}
