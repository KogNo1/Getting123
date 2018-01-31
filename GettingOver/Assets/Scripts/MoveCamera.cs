using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	[SerializeField]
	private float xMax, yMax, xMin, yMin;

	[SerializeField]
	private Transform player;


	private Vector3 offset;

	void Start ()
	{
		
	}

	void LateUpdate ()
	{
		transform.position = new Vector3 (Mathf.Clamp (player.position.x, xMin, xMax), Mathf.Clamp (player.position.y, yMin, yMax), transform.position.z);
	}
}
