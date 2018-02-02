using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGravityController : MonoBehaviour {

	enum HandAndAss{none, Ass, Hand}

	[SerializeField]
	HandAndAss handle = HandAndAss.none;

	[SerializeField]
	Rigidbody2D rbBody;

	public static bool handGround, assground;

	// Use this for initialization
	void Start () {

	}

	void Update(){
		if (CharacterGravityController.handGround == false && CharacterGravityController.assground == false) {
			if (rbBody.gravityScale < 5)
				rbBody.gravityScale += Time.deltaTime * 0.5f;
			else
				rbBody.gravityScale = 5;
		} else {
			rbBody.gravityScale = 1;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Elements") {
			switch (handle) {
			case HandAndAss.Ass:
				CharacterGravityController.assground = true;
				break;
			case HandAndAss.Hand:
				CharacterGravityController.handGround = true;
				break;
			}
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Elements") {
			switch (handle) {
			case HandAndAss.Ass:
				CharacterGravityController.assground = false;
				break;
			case HandAndAss.Hand:
				CharacterGravityController.handGround = false;
				break;
			}
		}
	}
}
