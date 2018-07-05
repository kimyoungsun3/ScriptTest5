using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDDD : MonoBehaviour {
	public LayerMask mask;

	// Use this for initialization
	void Start () {
		int x = LayerMask.GetMask ("Players", "Ground");
		int x2 = LayerMask.GetMask ("Players");
		Debug.Log (x);
		Debug.Log (x2);
		Debug.Log(Mathf.Log (x2, 2));
		Debug.Log(Mathf.Log (x, 2));
		//x2 >> 2
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (mask.value);
		
	}
}
