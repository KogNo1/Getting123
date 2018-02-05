using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class UIAnis {
	[SerializeField]
	private Transform target;

	[SerializeField]
	private Vector3 maxScale;

	[SerializeField]
	private Vector3 originScale;

	[SerializeField]
	private Vector3 minScale;

	[SerializeField]
	private Sprite inActiveSpr;

	[SerializeField]
	private Sprite activeSpr;

	public void MaximumTarget() {
		target.transform.localScale = maxScale;
		Image targetSpr = target.GetComponent<Image> ();

		if (targetSpr != null && activeSpr != null)
			targetSpr.sprite = activeSpr;
	}

	public void MinimizeTarget() {
		target.transform.localScale = originScale;

		Image targetSpr = target.GetComponent<Image> ();

		if (targetSpr != null && inActiveSpr != null)
			targetSpr.sprite = inActiveSpr;
	}

	public void MaximumTarget2() {
		target.transform.localScale = maxScale;
	}

	public void MinimizeTarget2() {
		target.transform.localScale = originScale;
	}
}
