using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoop : MonoBehaviour {

	[SerializeField]
	List<Transform> BGImagePrefab = new List<Transform>();
	[SerializeField]
	List<Transform> BGImage = new List<Transform>();

	[SerializeField]
	int numBG;

	[SerializeField]
	int currentBG;

	// Use this for initialization
	void Start () {
		currentBG = 0;
		for (int i = 0; i < numBG; i++) {
			if (i < BGImagePrefab.Count){
				currentBG = i;
				BGImage.Add (Instantiate<Transform> (BGImagePrefab [currentBG], new Vector3 (0, 5, 0), BGImagePrefab [currentBG].rotation));
			}
			else{
				currentBG = i - BGImagePrefab.Count;
				BGImage.Add (Instantiate<Transform> (BGImagePrefab [currentBG], new Vector3 (0, 5, 0), BGImagePrefab [currentBG].rotation));
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
