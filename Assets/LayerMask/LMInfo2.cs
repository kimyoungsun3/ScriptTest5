using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMInfo2 : MonoBehaviour {
	public LayerMask mask;

	void Start () {
		Debug.Log(LayerMask.GetMask("UI", "Ground"));

		int layer = LayerMask.NameToLayer ("UI");
		Debug.Log (layer);
		Debug.Log (LayerMask.LayerToName (layer));


		int i, maskValue, l;
		for (i = 0; i < 10; i++) {
			maskValue = (int)Mathf.Pow (2, i);
			l = (int)Mathf.Log (maskValue, 2);
			Debug.Log (i + " > " + l + " > " + maskValue);
		}
	}
}
