﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
	
	[SerializeField]
	private GameObject[] checkpointList;

	[SerializeField]
	private GameObject stick;

	int checkpointValue;
	// Use this for initialization
	void Start () {
		checkpointValue = PlayerPrefs.GetInt ("checkpoint", 0);
		Debug.Log (checkpointValue);
		transform.position = checkpointList [checkpointValue].transform.position;
		stick.transform.position = checkpointList [checkpointValue].transform.position + new Vector3 (0.6f, 1.5f, 0);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.gameObject.tag == "CheckPoint") 
		{
			int temp = int.Parse (other.transform.name);
			if (temp > checkpointValue) 
			{
				PlayerPrefs.SetInt ("checkpoint", temp);
				Debug.Log (other.transform.name);
			}
		}
	}
}