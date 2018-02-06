using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRepeat : MonoBehaviour {
	void OnTriggerEnter2D (Collider2D other)
	{
		transform.gameObject.SetActive (false);
		SaveManager.instance.state.gold++;
		SaveManager.instance.Save ();
	}
}
