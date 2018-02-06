using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScene : MonoBehaviour {

	[SerializeField]
	private CanvasGroup fadeGroup;
	private float loadTime;
	private float fadeSpeed = 1f;

	[Header("Background")]
	[SerializeField]
	GameObject bgIp;
	[SerializeField]
	GameObject bgIpx;
	[SerializeField]
	GameObject bgIpad;

	// Use this for initialization
	void Start () {

		if (MultiResolution.device == "iphone") {
			bgIp.SetActive (true);
			bgIpad.SetActive (false);
			bgIpx.SetActive (false);
		}
		if (MultiResolution.device == "iphonex") {
			bgIp.SetActive (false);
			bgIpad.SetActive (false);
			bgIpx.SetActive (true);
		}
		if (MultiResolution.device == "ipad") {
			bgIp.SetActive (false);
			bgIpad.SetActive (true);
			bgIpx.SetActive (false);
		}

		//fadeGroup = FindObjectOfType<CanvasGroup> ();
		if (SaveManager.instance.state.fadeInOut == false) {
			if (fadeGroup != null)
				fadeGroup.alpha = 1;
		} else {
			if (fadeGroup != null)
				fadeGroup.alpha = 0;
		}
	}

	// Update is called once per frame
	void Update () {
		if (SaveManager.instance.state.fadeInOut == false) {
			fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeSpeed;
			if (fadeGroup.alpha == 0) {
				fadeGroup.blocksRaycasts = false;
				FadePlayOneShot ();
				if (LoadingScene.showInter == false) {
					// Quang Cao Inter
					LoadingScene.showInter = true;
				}
			}
		} else {
			fadeGroup.blocksRaycasts = false;
		}
	}

	// Save lai dieu kien de fade chi chay dc mot lan khi vao game
	void FadePlayOneShot(){
		SaveManager.instance.state.fadeInOut = true;
		SaveManager.instance.Save ();
	}
}
