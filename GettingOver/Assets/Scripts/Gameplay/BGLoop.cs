using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoop : MonoBehaviour {

	[SerializeField]
	List<Transform> BGImagePrefab = new List<Transform>();
	[SerializeField]
	List<Transform> BGImage = new List<Transform>();

	[SerializeField]
	Transform BG;

	[SerializeField]
	int numBG;

	[SerializeField]
	int currentBG;

	// Use this for initialization
	void Start () {
		currentBG = 0;
		for (int i = 0; i < numBG; i++) {
			if (currentBG < BGImagePrefab.Count){
				BGImage.Add (Instantiate<Transform> (BGImagePrefab [currentBG], new Vector3 (0, 5, 0), BGImagePrefab [currentBG].rotation));
			}
			else{
				currentBG = 0;
				BGImage.Add (Instantiate<Transform> (BGImagePrefab [currentBG], new Vector3 (0, 5, 0), BGImagePrefab [currentBG].rotation));
			}
			currentBG++;
		}
	}

	// Update is called once per frame
	void Update () {
		for (int i = 1; i < BGImage.Count; i++) {
			BGImage [i].position = new Vector3 (BGImage [i - 1].position.x + 88, 5, 0);
		}

		for (int i = 0; i < BGImage.Count; i++) {
			BGImage [i].SetParent (BG);
		}
	}
}
