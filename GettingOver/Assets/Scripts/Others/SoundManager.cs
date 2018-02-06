using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static AudioSource Hits;
	public static AudioSource Clicks;
	public static AudioSource Coins;
	public static AudioSource BGMs;

	public AudioSource Hit;
	public AudioSource Click;
	public AudioSource Coin;
	public AudioSource BGM;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

		Hits = Hit;
		Clicks = Click;
		Coins = Coin;
		BGMs = BGM;
	}

	public static void MuteAll(){
		Hits.mute = true;
		Clicks.mute = true;
		Coins.mute = true;
		BGMs.mute = true;
	}

	public static void DontMuteAll(){
		Hits.mute = false;
		Clicks.mute = false;
		Coins.mute = false;
		BGMs.mute = false;
	}
}
