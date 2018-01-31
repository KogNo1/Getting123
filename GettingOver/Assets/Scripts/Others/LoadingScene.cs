using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : MonoBehaviour {

	//public static GoogleMobileAdsDemoScript ads = new GoogleMobileAdsDemoScript();

	void Start(){
		//ads.RequestBanner ();
		//ads.RequestInterstitial ();
		//ads.RequestRewardBasedVideo ();
		SaveManager.instance.state.isUnlockItemHat[0] = true;
		SaveManager.instance.Save ();
		StartCoroutine (Loading ());
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
}
