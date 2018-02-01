using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAnim : MonoBehaviour {

	[SerializeField]
	Transform hand;

	[SerializeField]
	float speed;
	
	// Update is called once per frame
	void Update () {
		RotationHand ();
	}

	void RotationHand(){
		hand.Rotate (0, 0, speed);
	}
}
