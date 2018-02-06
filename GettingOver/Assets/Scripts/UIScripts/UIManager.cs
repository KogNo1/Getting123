using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	enum BtnHandle { none, playGame, shop, rate, share, sound, shopHat, shopWp, shopFoot, shopBrand, pause, home, restart, continueButton, rewardCoin }

	enum IsSceneName { none, Menu, ShopHat, ShopWeapon, ShopFoot}

	[SerializeField]
	BtnHandle btnHandle = BtnHandle.none;

	[SerializeField]
	IsSceneName isSceneName = IsSceneName.none;

	[SerializeField]
	UIAnis uiAnis;

	[Header("Button Choose")]
	[SerializeField]
	UnityEngine.UI.Button [] chooseButtonHat;
	[SerializeField]
	UnityEngine.UI.Button [] chooseButtonWp;
	[SerializeField]
	UnityEngine.UI.Button [] chooseButtonFoot;

	[Header("Image lock")]
	[SerializeField]
	GameObject [] lockImg;
	[SerializeField]
	GameObject [] lockImgWp;
	[SerializeField]
	GameObject [] lockImgFoot;

	[Header("Button buy")]
	[SerializeField]
	GameObject [] buyBtn;
	[SerializeField]
	GameObject [] buyBtnWp;
	[SerializeField]
	GameObject [] buyBtnFoot;

	[Header("Data files")]
	[SerializeField]
	DataReader[] dataHat;
	[SerializeField]
	DataReader[] dataWp;
	[SerializeField]
	DataReader[] dataFoot;

	[Header("GoldTxt")]
	[SerializeField]
	UnityEngine.UI.Text totalGold;

	[Header("Choose Button")]
	[SerializeField]
	Sprite FrameChoose;
	[SerializeField]
	Sprite FrameUnChoose;

	[Header("3 type shop")]
	[SerializeField]
	UnityEngine.UI.Button obShopWp;
	[SerializeField]
	UnityEngine.UI.Button obShopFoot;
	[SerializeField]
	UnityEngine.UI.Button obShopHat;

	[Header("3 type shop GameObject")]
	[SerializeField]
	GameObject shopWpGob;
	[SerializeField]
	GameObject shopFootGob;
	[SerializeField]
	GameObject shopHatGob;

	[Header("Sound button")]
	[SerializeField]
	UnityEngine.UI.Image soundBtn;
	[SerializeField]
	Sprite soundOn;
	[SerializeField]
	Sprite soundOff;

	[Header("Pause panel")]
	[SerializeField]
	GameObject pausePanel;

	[Header("Background")]
	[SerializeField]
	GameObject bgIp;
	[SerializeField]
	GameObject bgIpx;
	[SerializeField]
	GameObject bgIpad;

	[Header("Group shop")]
	[SerializeField]
	GameObject shopGroup;

	[Header("Link rate share")]
	[SerializeField]
	string linkRate;
	[SerializeField]
	string linkShare;

	void Awake() {
		if (bgIp != null && bgIpad != null && bgIpx != null) {
			if (MultiResolution.device == "iphone") {
				bgIp.SetActive (true);
				bgIpad.SetActive (false);
				bgIpx.SetActive (false);
				shopGroup.transform.localScale = new Vector3 (1f, 1f, 1);
			}
			if (MultiResolution.device == "iphonex") {
				bgIp.SetActive (false);
				bgIpad.SetActive (false);
				bgIpx.SetActive (true);
				shopGroup.transform.localScale = new Vector3 (0.8f, 0.8f, 1);
			}
			if (MultiResolution.device == "ipad") {
				bgIp.SetActive (false);
				bgIpad.SetActive (true);
				bgIpx.SetActive (false);
				shopGroup.transform.localScale = new Vector3 (1f, 1f, 1);
			}
		}
	}

	// Use this for initialization
	void Start () {
		//CheckItemChosen ();
		CheckStatus ();

		DisplayTotalGold ();
	}

	public void PressButton() {
		uiAnis.MaximumTarget ();
	}

	public void PressButton2() {
		uiAnis.MaximumTarget2 ();
	}

	public void UnpressButton() {
		uiAnis.MinimizeTarget ();

		switch (btnHandle) {
		case BtnHandle.none:
			break;
		case BtnHandle.playGame:
			PlayGame ();
			break;
		case BtnHandle.shop:
			Shop ();
			break;
		case BtnHandle.rate:
			Rate ();
			break;
		case BtnHandle.share:
			Share ();
			break;
		case BtnHandle.sound:
			Sound ();
			break;
		case BtnHandle.shopBrand:
			break;
		case BtnHandle.pause:
			PauseButton ();
			break;
		case BtnHandle.home:
			HomeButton ();
			break;
		case BtnHandle.restart:
			RestartButton ();
			break;
		case BtnHandle.continueButton:
			ContinueButton ();
			break;
		case BtnHandle.rewardCoin:
			RewardCoin ();
			break;
		}
	}

	public void UnpressButton2() {
		uiAnis.MinimizeTarget2 ();

		switch (btnHandle) {
		case BtnHandle.shopHat:
			ChangeShopHat ();
			break;
		case BtnHandle.shopWp:
			ChangeShopWp ();
			break;
		case BtnHandle.shopFoot:
			ChangeShopFoot ();
			break;
		}
	}

	void PlayGame() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Gameplay");
	}

	void Shop() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("ShopScene");
	}

	void Rate(){
		Application.OpenURL (linkRate);
	}

	void Share(){
		Application.OpenURL (linkShare);
	}

	void RewardCoin() {
		LoadingScene.ads.ShowRewardBasedVideo ();
	}

	void Sound(){
		if (SaveManager.instance.state.statusSound) {
			SaveManager.instance.state.statusSound = false;
			soundBtn.sprite = soundOff;
			SaveManager.instance.Save ();
		}
		else if(SaveManager.instance.state.statusSound == false){
			SaveManager.instance.state.statusSound = true;
			soundBtn.sprite = soundOn;
			SaveManager.instance.Save ();
		}
	}

	void CheckSound() {
		if (soundBtn != null) {
			if (SaveManager.instance.state.statusSound)
				soundBtn.sprite = soundOn;
			else
				soundBtn.sprite = soundOff;
		}
	}

	public void BackButton(string nameBackScene) {
		UnityEngine.SceneManagement.SceneManager.LoadScene (nameBackScene);
	}

	void ChangeShopHat(){
		obShopWp.enabled = true;
		obShopWp.GetComponent<UnityEngine.UI.Image> ().sprite = FrameUnChoose;
		shopWpGob.SetActive (false);

		obShopHat.enabled = false;
		obShopHat.GetComponent<UnityEngine.UI.Image> ().sprite = FrameChoose;
		shopHatGob.SetActive (true);

		obShopFoot.enabled = true;
		obShopFoot.GetComponent<UnityEngine.UI.Image> ().sprite = FrameUnChoose;
		shopFootGob.SetActive (false);
	}

	void ChangeShopWp(){
		obShopWp.enabled = false;
		obShopWp.GetComponent<UnityEngine.UI.Image> ().sprite = FrameChoose;
		shopWpGob.SetActive (true);

		obShopHat.enabled = true;
		obShopHat.GetComponent<UnityEngine.UI.Image> ().sprite = FrameUnChoose;
		shopHatGob.SetActive (false);

		obShopFoot.enabled = true;
		obShopFoot.GetComponent<UnityEngine.UI.Image> ().sprite = FrameUnChoose;
		shopFootGob.SetActive (false);
	}

	void ChangeShopFoot(){
		obShopWp.enabled = true;
		obShopWp.GetComponent<UnityEngine.UI.Image> ().sprite = FrameUnChoose;
		shopWpGob.SetActive (false);

		obShopHat.enabled = true;
		obShopHat.GetComponent<UnityEngine.UI.Image> ().sprite = FrameUnChoose;
		shopHatGob.SetActive (false);

		obShopFoot.enabled = false;
		obShopFoot.GetComponent<UnityEngine.UI.Image> ().sprite = FrameChoose;
		shopFootGob.SetActive (true);
	}

	void PauseButton(){
		pausePanel.SetActive (true);
	}

	void HomeButton(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("MenuScene");
	}

	void RestartButton(){
		LoadingScene.ads.ShowInterstitial ();
		LoadingScene.ads.RequestInterstitial ();
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Gameplay");
	}

	void ContinueButton(){
		pausePanel.SetActive (false);
	}

	public void ItemChosen(int indexItem) {
		switch(isSceneName) {
			case IsSceneName.ShopHat:
				if (SaveManager.instance.state.isUnlockItemHat [indexItem]) {

					for (int i = 0; i < chooseButtonHat.Length; i++) {
						if (i == indexItem)
							chooseButtonHat [i].GetComponent<UnityEngine.UI.Image> ().sprite = FrameChoose;
						else
							chooseButtonHat [i].GetComponent<UnityEngine.UI.Image> ().sprite = FrameUnChoose;
					}

					SaveManager.instance.state.indexHat = indexItem;
					SaveManager.instance.Save ();
				}
				break;

			case IsSceneName.ShopWeapon:
				if (SaveManager.instance.state.isUnlockItemWp [indexItem]) {

					for (int i = 0; i < chooseButtonWp.Length; i++) {
						if (i == indexItem)
							chooseButtonWp [i].GetComponent<UnityEngine.UI.Image> ().sprite = FrameChoose;
						else
							chooseButtonWp [i].GetComponent<UnityEngine.UI.Image> ().sprite = FrameUnChoose;
					}

					SaveManager.instance.state.indexWp = indexItem;
					SaveManager.instance.Save ();
				}
				break;

			case IsSceneName.ShopFoot:
				if (SaveManager.instance.state.isUnlockItemFoot [indexItem]) {

					for (int i = 0; i < chooseButtonFoot.Length; i++) {
						if (i == indexItem)
							chooseButtonFoot [i].GetComponent<UnityEngine.UI.Image> ().sprite = FrameChoose;
						else
							chooseButtonFoot [i].GetComponent<UnityEngine.UI.Image> ().sprite = FrameUnChoose;
					}

					SaveManager.instance.state.indexFoot = indexItem;
					SaveManager.instance.Save ();
				}
				break;
		}
	}

	void CheckStatus() {
		switch(isSceneName) {
			case IsSceneName.ShopHat:
				for (int i = 0; i < chooseButtonHat.Length; i++) {
					if (SaveManager.instance.state.isUnlockItemHat [i]) {
						lockImg [i].SetActive (false);
						buyBtn [i].SetActive (false);
						chooseButtonHat [i].interactable = true;
					} else {
						lockImg [i].SetActive (true);
						buyBtn [i].SetActive (true);
						chooseButtonHat [i].interactable = false;
					}

					if (i == SaveManager.instance.state.indexHat)
						chooseButtonHat [i].GetComponent<UnityEngine.UI.Image> ().sprite = FrameChoose;
					else
						chooseButtonHat [i].GetComponent<UnityEngine.UI.Image> ().sprite = FrameUnChoose;
				}
				break;

			case IsSceneName.ShopWeapon:
				for (int i = 0; i < chooseButtonWp.Length; i++) {
					if (SaveManager.instance.state.isUnlockItemWp [i]) {
						lockImgWp [i].SetActive (false);
						buyBtnWp [i].SetActive (false);
						chooseButtonWp [i].interactable = true;
					} else {
						lockImgWp [i].SetActive (true);
						buyBtnWp [i].SetActive (true);
						chooseButtonWp [i].interactable = false;
					}

					if (i == SaveManager.instance.state.indexWp)
						chooseButtonWp [i].GetComponent<UnityEngine.UI.Image> ().sprite = FrameChoose;
					else
						chooseButtonWp [i].GetComponent<UnityEngine.UI.Image> ().sprite = FrameUnChoose;
				}
				break;

			case IsSceneName.ShopFoot:
				for (int i = 0; i < chooseButtonFoot.Length; i++) {
					if (SaveManager.instance.state.isUnlockItemFoot [i]) {
						lockImgFoot [i].SetActive (false);
						buyBtnFoot [i].SetActive (false);
						chooseButtonFoot [i].interactable = true;
					} else {
						lockImg [i].SetActive (true);
						buyBtnFoot [i].SetActive (true);
						chooseButtonFoot [i].interactable = false;
					}

					if (i == SaveManager.instance.state.indexFoot)
						chooseButtonFoot [i].GetComponent<UnityEngine.UI.Image> ().sprite = FrameChoose;
					else
						chooseButtonFoot [i].GetComponent<UnityEngine.UI.Image> ().sprite = FrameUnChoose;
				}
				break;
		}
	}

	void DisplayTotalGold() {
		if(totalGold != null)
			totalGold.text = SaveManager.instance.state.gold.ToString ();
	}

	public void BuyItem(int indexItem){
		switch(isSceneName) {
			case IsSceneName.ShopHat:
				if (SaveManager.instance.state.gold >= dataHat[indexItem].dataObject.price) {

					SaveManager.instance.state.isUnlockItemHat [indexItem] = true;
					SaveManager.instance.state.gold -= dataHat [indexItem].dataObject.price;
					SaveManager.instance.Save ();

					CheckStatus ();

					DisplayTotalGold ();
				}
				break;

			case IsSceneName.ShopWeapon:
				if (SaveManager.instance.state.gold >= dataWp[indexItem].dataObject.price) {

					SaveManager.instance.state.isUnlockItemWp [indexItem] = true;
					SaveManager.instance.state.gold -= dataWp [indexItem].dataObject.price;
					SaveManager.instance.Save ();

					CheckStatus ();

					DisplayTotalGold ();
				}
				break;

			case IsSceneName.ShopFoot:
				if (SaveManager.instance.state.gold >= dataFoot[indexItem].dataObject.price) {

					SaveManager.instance.state.isUnlockItemFoot [indexItem] = true;
					SaveManager.instance.state.gold -= dataFoot [indexItem].dataObject.price;
					SaveManager.instance.Save ();

					CheckStatus ();

					DisplayTotalGold ();
				}
				break;
		}
	}
}
