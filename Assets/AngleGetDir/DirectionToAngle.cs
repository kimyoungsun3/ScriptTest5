using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionToAngle : MonoBehaviour {
	public Transform playerTrans;

	void Update () {
		Vector3 targetDir = Vector3.right;
		Vector3 playerLookDir = playerTrans.position - transform.position;
		Quaternion playerLookQ = Quaternion.LookRotation (playerLookDir);

		float angle;
		//Vector3 d = Vector3.up;
		//Vector3 d = Vector3.down;
		//Vector3 d = Vector3.left;
		//Vector3 d = Vector3.right;
		Vector3 d = Vector3.forward;
		angle = Vector3.SignedAngle(targetDir, playerLookDir, d);


		Debug.Log(playerLookQ.eulerAngles
			+ ":" + angle
			+ ":" + PosNegAngle (targetDir, playerLookDir, d)
			//+ ":" + PosNegAngle (playerLookDir, targetDir, d)
			+ ":" + GetAngleFromDir(playerLookDir)
		);
		Debug.Log (
			PosNegAngle (Vector3.forward, Vector3.right, Vector3.up)
			+ ":" + PosNegAngle (Vector3.right, Vector3.forward, Vector3.up)
			+ ":" + PosNegAngle (Vector3.up, Vector3.forward, Vector3.right)
			+ ":" + PosNegAngle (Vector3.forward, Vector3.up, Vector3.right)
		);
	}		

	float PosNegAngle(Vector3 a1, Vector3 a2, Vector3 n){
		float angle = Vector3.Angle (a1, a2);
		float sign = Mathf.Sign(Vector3.Dot(n, Vector3.Cross(a1, a2)));
		return angle * sign;
	}

	float GetAngleFromDir(Vector3 dir){
		return Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
	}
}
