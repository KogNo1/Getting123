using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeCharacterEquipment : MonoBehaviour {

	[Header("Sprite Hat")]
	[SerializeField]
	SpriteRenderer Hat;
	[SerializeField]
	Sprite[] hatSprite;

	[Header("Sprite Foot")]
	[SerializeField]
	SpriteRenderer Foot;
	[SerializeField]
	Sprite[] footSprite;

	[Header("Weapon")]
	[SerializeField]
	SpriteRenderer weapon;
	[SerializeField]
	Sprite[] weaponsSpr;

	[Header("EventTrigger Button Control")]
	[SerializeField]
	EventTrigger rightButton;
	[SerializeField]
	EventTrigger leftButton;

	[Header("Reward button")]
	[SerializeField]
	GameObject rewardBtn;

	public static float timer;

	[Header("MoveHand")]
	[SerializeField]
	MoveHand moveHand;

	[Header("Collider")]
	[SerializeField]
	PolygonCollider2D[] colliderWeapons;


	// Use this for initialization
	void Awake () {
		weapon.sprite = weaponsSpr [SaveManager.instance.state.indexWp];

		EventTrigger.Entry entryMoveRight = new EventTrigger.Entry();
		entryMoveRight.eventID = EventTriggerType.PointerDown;
		entryMoveRight.callback.AddListener( (eventData) => { moveHand.MoveRight(); } );

		rightButton.triggers.Add (entryMoveRight);

		EventTrigger.Entry entryMoveLeft = new EventTrigger.Entry();
		entryMoveLeft.eventID = EventTriggerType.PointerDown;
		entryMoveLeft.callback.AddListener( (eventData) => { moveHand.MoveLeft(); } );

		leftButton.triggers.Add (entryMoveLeft);

		EventTrigger.Entry entryPointUp = new EventTrigger.Entry();
		entryPointUp.eventID = EventTriggerType.PointerUp;
		entryPointUp.callback.AddListener( (eventData) => { moveHand.pointUp(); } );

		rightButton.triggers.Add (entryPointUp);
		leftButton.triggers.Add (entryPointUp);



		for (int i = 0; i < colliderWeapons.Length; i++) {
			if (i == SaveManager.instance.state.indexWp)
				colliderWeapons [i].enabled = true;
			else
				colliderWeapons [i].enabled = false;
		}
		Hat.sprite = hatSprite [SaveManager.instance.state.indexHat];
		Foot.sprite = footSprite [SaveManager.instance.state.indexFoot];
	}

	void Update() {
		if (Application.internetReachability != NetworkReachability.NotReachable) {
			timer += Time.deltaTime;
			if (timer >= 60) {
				rewardBtn.SetActive (true);
			} else
				rewardBtn.SetActive (false);
		} else {
			rewardBtn.SetActive (false);
		}
	}
}
