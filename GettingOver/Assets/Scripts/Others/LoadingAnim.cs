using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAnim : MonoBehaviour {

	[SerializeField]
	Transform hand, head;

	[SerializeField]
	float speedHand, speedHead;

	[SerializeField]
	float time, timeInter;

	void Start(){
		timeInter = 0.5f;
	}

	// Update is called once per frame
	void Update () {
		if (time >= timeInter) {
			timeInter = 1f;
			time = 0;
		} else {
			time += Time.deltaTime;
		}
		RotationHand ();
		ShakeHead ();
	}

	void RotationHand(){
		hand.Rotate (0, 0, speedHand);
	}

	void ShakeHead(){
		head.Rotate (0, 0, speedHead);
		if (time >= timeInter) {
			speedHead *= -1;
		}

	}
}
