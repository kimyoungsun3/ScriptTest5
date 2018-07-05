using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubData : MonoBehaviour {

	float size = 2f;
	bool bSetting = false;
	Quaternion firstQ = Quaternion.identity;
	public void SetRotationInfo(Quaternion _q){
		bSetting = true;
		firstQ = _q;
		Debug.Log (firstQ);
	}

	// Update is called once per frame
	void Update () {
		if (bSetting) {
			Vector3 dir = firstQ * Vector3.right * size;
			Debug.DrawRay (transform.position, dir, Color.red);
			dir = firstQ * Vector3.up * size;
			Debug.DrawRay (transform.position, dir, Color.green);
			dir = firstQ * Vector3.forward * size;
			Debug.DrawRay (transform.position, dir, Color.blue);
		}
		
	}
}
