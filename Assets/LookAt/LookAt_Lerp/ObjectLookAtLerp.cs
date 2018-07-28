using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtLerp : MonoBehaviour {
	public List<Transform> listTargets = new List<Transform>();
	int index = 0;
	Transform transTarget;
	public float speedLookAt = 30f;

	void Start(){
		Debug.Log ("push Space bar and next target");
		if (listTargets.Count > 0) {
			transTarget = listTargets [index];
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && index >= 0) {
			index = (index + 1) % listTargets.Count;
			transTarget = listTargets[index];
		}

		//----------------------------------------
		if (transTarget != null) {
			//transform.LookAt (target);	
			Vector3 _dir 		= transTarget.position - transform.position;
			Quaternion _dirQ 	= Quaternion.LookRotation (_dir);
			transform.rotation 	= Quaternion.Lerp (transform.rotation, _dirQ, speedLookAt * Time.deltaTime);
		}
	}
}
