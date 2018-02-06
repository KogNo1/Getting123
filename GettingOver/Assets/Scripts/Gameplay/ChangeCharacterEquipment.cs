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
	GameObject[] weapons;

	[Header("Character hinge joint")]
	[SerializeField]
	HingeJoint2D hingeOfCharacter;

	[Header("EventTrigger Button Control")]
	[SerializeField]
	EventTrigger rightButton;
	[SerializeField]
	EventTrigger leftButton;

	[Header("Reward button")]
	[SerializeField]
	GameObject rewardBtn;

	public static float timer;

	// Use this for initialization
	void Awake () {
		for (int i = 0; i < weapons.Length; i++) {
			if (i == SaveManager.instance.state.indexWp) {
				weapons [i].SetActive (true);
				hingeOfCharacter.connectedBody = weapons [i].GetComponent<Rigidbody2D> ();

				MoveHand moveHand = weapons [i].GetComponent<MoveHand> ();

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
			}
			else
				weapons [i].SetActive (false);
		}
		Hat.sprite = hatSprite [SaveManager.instance.state.indexHat];
		Foot.sprite = footSprite [SaveManager.instance.state.indexFoot];
	}

	void Update() {
		timer += Time.deltaTime;
		if (timer >= 60) {
			rewardBtn.SetActive (true);
		} else
			rewardBtn.SetActive (false);
	}
}
