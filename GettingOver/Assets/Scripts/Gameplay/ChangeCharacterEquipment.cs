using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	// Use this for initialization
	void Awake () {
		Hat.sprite = hatSprite [SaveManager.instance.state.indexHat];
		Foot.sprite = footSprite [SaveManager.instance.state.indexFoot];
	}
}
