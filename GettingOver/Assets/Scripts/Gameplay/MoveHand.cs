using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour {

	public float amount;
	public Rigidbody2D rb;

	float angle;

	int moveWhere;

	int whatControl;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		moveWhere = 0;
		whatControl = 0;
	}

	void Update ()
	{
		if (whatControl == 0) {
			MovebyClick ();
		} else if (whatControl == 1) {
			float h = Input.GetAxis ("Horizontal") * amount * Time.deltaTime;

			if (rb.velocity.magnitude < 4.5f)
				rb.AddTorque (-h * amount);
		} else {
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
				MovebyDrag ();
			}
		}
	}

	void MovebyDrag(){
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 0f;

		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);

		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;

		if (rb.velocity.magnitude < 4.5f)
			rb.AddTorque (angle * amount * Time.deltaTime);

//		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (Vector3.forward * (angle)), amount * Time.deltaTime);
	}

	void MovebyClick(){
		if (moveWhere == 0) {
			float h = Input.GetAxis ("Fire1") * amount * Time.deltaTime;
			if (rb.velocity.magnitude < 4.5f)
				rb.AddTorque (-h * amount);
		} else {
			float h = Input.GetAxis ("Fire1") * amount * Time.deltaTime;
			if (rb.velocity.magnitude < 4.5f)
				rb.AddTorque (h * amount);
		}
	}

	public void MoveRight(){
		moveWhere = 0;
	}

	public void MoveLeft(){
		moveWhere = 1;
	}
}
