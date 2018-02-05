using System.Collections;
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
		checkpointValue = SaveManager.instance.state.checkpoint;
		transform.position = checkpointList [checkpointValue].transform.position;
		stick.transform.position = checkpointList [checkpointValue].transform.position + new Vector3 (0.6f, 1.5f, 0);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.gameObject.tag == "CheckPoint") 
		{
			int temp = int.Parse (other.transform.name);
			SaveManager.instance.state.checkpoint = temp;
			SaveManager.instance.Save ();
		}
	}
}
