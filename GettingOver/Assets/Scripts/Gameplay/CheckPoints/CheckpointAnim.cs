using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAnim : MonoBehaviour {

	[SerializeField]
	float timeAnim;

	int currentAnim;

	[SerializeField]
	List<Sprite> flagAnim = new List<Sprite>();

	[SerializeField]
	SpriteRenderer flag;

	// Use this for initialization
	void Start () {
		currentAnim = 0;
		StartCoroutine (FlagDoAnim (timeAnim));
	}
	
	IEnumerator FlagDoAnim(float time){
		yield return new WaitForSeconds (time);
		if (currentAnim < flagAnim.Count - 1) {
			currentAnim++;
		} else {
			currentAnim = 0;
		}
		flag.sprite = flagAnim [currentAnim];
		StartCoroutine (FlagDoAnim (timeAnim));
	}
}
