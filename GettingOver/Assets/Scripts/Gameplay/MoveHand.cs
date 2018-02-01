using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour {

	public float amount;
	public Rigidbody2D rb;

	float angle;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		float h = Input.GetAxis("Horizontal") * amount * Time.deltaTime;

		if (rb.velocity.magnitude < 4.5f)
			rb.AddTorque (-h * amount);
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Move ();
		}
	}

	void Move(){
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 0f;

		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);

		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;

		if (rb.velocity.magnitude < 4.5f)
			rb.AddTorque (angle * amount * Time.deltaTime);

		Debug.Log (angle);
//		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (Vector3.forward * (angle)), amount * Time.deltaTime);
	}
}
