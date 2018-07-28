using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMInfo : MonoBehaviour {
	public LayerMask mask;

	void Start () {
		Debug.Log (this + " gameObject.layer :" + gameObject.layer);	
		Debug.Log (this + " mask :" + mask.value);
	}
}
