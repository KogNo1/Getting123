using UnityEngine;

[CreateAssetMenu(fileName = "newItem", menuName = "Item")]
public class ScriptData : ScriptableObject {

	// Data
	public new int index;
	public new string name;
	public int price;
	public Sprite avatar;
	public bool isUnlock;
}
