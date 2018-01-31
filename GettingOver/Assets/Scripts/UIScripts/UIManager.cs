using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	enum BtnHandle { none, playGame, shop, rate, share, sound, shopBrand }

	enum IsSceneName { none, Menu, ShopHat, ShopWeapon}

	[SerializeField]
	BtnHandle btnHandle = BtnHandle.none;

	[SerializeField]
	IsSceneName isSceneName = IsSceneName.none;

	[SerializeField]
	UIAnis uiAnis;

	[SerializeField]
	UnityEngine.UI.Button [] chooseButtonHat;

	[SerializeField]
	GameObject [] lockImg;

	[SerializeField]
	GameObject [] buyBtn;

	[SerializeField]
	DataReader[] dataHat;

	[SerializeField]
	UnityEngine.UI.Text totalGold;

	[Header("Choose Button")]
	[SerializeField]
	Sprite FrameChoose;
	[SerializeField]
	Sprite FrameUnChoose;

	void Awake() {
		
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
		}
	}

	void PlayGame() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Gameplay");
	}

	void Shop() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("ShopScene");
	}

	void Rate(){
		Application.OpenURL ("");
	}

	void Share(){
		Application.OpenURL ("");
	}

	void Sound(){
		
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
		}
	}

	void CheckStatus() {
		switch(isSceneName) {
		case IsSceneName.ShopHat:
			for (int i = 0; i < chooseButtonHat.Length; i++)
				if (SaveManager.instance.state.isUnlockItemHat [i]) {
					lockImg [i].SetActive (false);
					buyBtn [i].SetActive (false);
					chooseButtonHat [i].interactable = true;
				} else {
					lockImg [i].SetActive (true);
					buyBtn [i].SetActive (true);
					chooseButtonHat [i].interactable = false;
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
		}
	}
}
