using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoop : MonoBehaviour {

	[Header("BG Options")]
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

	[SerializeField]
	GameObject[] listCoin;

	[Header("Map Options")]
	[SerializeField]
	List<Transform> Maps = new List<Transform>();

	public static bool isMoveMap;

	bool isChange1, isChange2, firstChangeMap1, firstChangeMap2;

	// Use this for initialization
	void Start () {
		SoundManager.BGMs.Play ();
		isMoveMap = false;
		isChange1 = true;
		isChange2 = false;
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

		if (isMoveMap) {
			MoveMap ();
		}
	}

	void MoveMap(){
		if (SaveManager.instance.state.checkpoint == 7) {
			if (isChange1) {
				ResetCoin ();
				if (!firstChangeMap1) {
					Maps [0].position = new Vector3 (639.2f, 0, 0);
					firstChangeMap1 = true;
				} else
					Maps [0].position = new Vector3 (Maps [0].position.x + 639.2f, 0, 0);
				isChange1 = false;
				isChange2 = true;
			}
		} else if (SaveManager.instance.state.checkpoint == 3) {
			if (isChange2) {
				ResetCoin ();
				if (!firstChangeMap2) {
					Maps [1].position = new Vector3 (639.5f, 0, 0);
					firstChangeMap2 = true;
				} else
					Maps [1].position = new Vector3 (Maps [1].position.x + 639.5f, 0, 0);
				isChange2 = false;
				isChange1 = true;
			}
		}
		isMoveMap = false;
	}

	// Reset coin when loop the BG
	void ResetCoin ()
	{
		for (int i = 0; i < listCoin.Length; i++) 
		{
			if (!listCoin [i].activeSelf)
				listCoin [i].SetActive (true);
		}
	}
}
