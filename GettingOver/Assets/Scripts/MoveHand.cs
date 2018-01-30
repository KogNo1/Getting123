using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour {

	public float amount;
	public Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal") * amount * Time.deltaTime;

		if (rb.velocity.magnitude < 4.5f)
			rb.AddTorque (-h * amount);

		Debug.Log (rb.velocity.magnitude);
	}
}
