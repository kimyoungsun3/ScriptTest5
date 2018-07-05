using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayGizmos : MonoBehaviour {
	float size = 1f;
	public bool bLocalView = true;
	public TextMesh text, text2;
	Quaternion rotation, rotation2;
	Vector3 position, position2;

	void Start(){
		if (text != null) {
			rotation = text.transform.rotation;
			position = text.transform.position;
			rotation2 = text2.transform.rotation;
			position2 = text2.transform.position;
		}
	}

	bool bSetting = false;
	Quaternion firstQ = Quaternion.identity;
	public void SetRotationInfo(Quaternion _q){
		bSetting = true;
		firstQ = _q;
	}

	void Update(){
		if (text != null) {
			text.transform.rotation = rotation;
			text.transform.position = position;
			text.text = ((bLocalView)?"L":"G") + transform.eulerAngles;

			text2.transform.rotation = rotation2;
			text2.transform.position = position2;
		}

		if (bSetting) {
			Vector3 dir = firstQ * Vector3.left;
			Debug.DrawRay (transform.position, dir * size, Color.red);
			dir = firstQ * Vector3.up;
			Debug.DrawRay (transform.position, dir * size, Color.green);
			dir = firstQ * Vector3.forward;
			Debug.DrawRay (transform.position, dir * size, Color.blue);
		}
	}

	void OnDrawGizmos(){

		if (bLocalView) {
			Gizmos.color = Color.red;
			Gizmos.DrawRay (transform.position, transform.right * size);
			Gizmos.color = Color.green;
			Gizmos.DrawRay (transform.position, transform.up * size);
			Gizmos.color = Color.blue;
			Gizmos.DrawRay (transform.position, transform.forward * size);
		} else {
			Vector3 p = transform.position + new Vector3 (0.1f, 0.1f, 0.1f);
			Gizmos.color = Color.red;
			Gizmos.DrawRay (p, Vector3.right * size);
			Gizmos.color = Color.green;
			Gizmos.DrawRay (p, Vector3.up * size);
			Gizmos.color = Color.blue;
			Gizmos.DrawRay (p, Vector3.forward * size);
		}
	}
}
