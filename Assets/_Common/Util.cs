﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util{
	public static Vector3 GetDirFromAngle(float _angle){
		return new Vector3(
			Mathf.Cos (_angle * Mathf.Deg2Rad),
			Mathf.Sin (_angle * Mathf.Deg2Rad), 
			0
		);
	}

	//A -> B => xy 평면에서 바라보는 x축을 기준으로 각도.
	public static float GetAngleFromDir(Vector3 _viewDir){
		return Mathf.Atan2 (_viewDir.y, _viewDir.x) * Mathf.Rad2Deg;
    }

    //public static Quaternion GetQuaternionFormDir(Vector3 _viewDir)
    //{
    //    return Quaternion.Euler(0, 0, Mathf.Atan2(_viewDir.y, _viewDir.x) * Mathf.Rad2Deg );
    //}

	public static Quaternion GetQuaternionFromDir2D(Vector3 _viewDir)
	{
		//float _angle = Mathf.Atan2 (_dir.y, _dir.x) * Mathf.Rad2Deg;
		//	Quaternion _q = Quaternion.Euler (Vector3.forward * _angle);
		//	return _q;
		return Quaternion.Euler(0, 0, Mathf.Atan2(_viewDir.y, _viewDir.x) * Mathf.Rad2Deg );
	}

    //A1, A2 사이각
    //PosNegAngle (Vector3.forward, Vector3.right, Vector3.up)
    //PosNegAngle (Vector3.right, Vector3.forward, Vector3.up)
    //PosNegAngle (Vector3.up, Vector3.forward, Vector3.right)
    //PosNegAngle (Vector3.forward, Vector3.up, Vector3.right)
    public static float GetAngleFromDir(Vector3 _a1, Vector3 _a2, Vector3 _n){
		float _angle = Vector3.Angle (_a1, _a2);
		float _sign = Mathf.Sign (Vector3.Dot (_n, Vector3.Cross (_a1, _a2)));
		return _sign * _angle;
	}
}
