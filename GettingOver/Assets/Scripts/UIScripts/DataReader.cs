using UnityEngine;
using UnityEngine.UI;

public class DataReader : MonoBehaviour {

	// Object ScriptData
	public ScriptData dataObject;

	// Component display data
	[Header("Object get data")]
	[SerializeField]
	Image avatar;
	[SerializeField]
	Text price;
		
	// Use this for initialization
	void Start () {
		// Get sprite from dataObject
		avatar.sprite = dataObject.avatar;

		// Get price from dataObject
		if (dataObject.price != 0)
			price.text = dataObject.price.ToString ();
		else
			price.text = "FREE";
	}
}
