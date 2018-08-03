using System.Collections;
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


	//-------------------------------------------------------
	// 포물선 공식....
	// 아래의 식은 물리 공식에 입각한 식이다...
	//
	// Kinematic Equation
	//  time(t), displament(s), accelation(a)
	// [--------------------------------]
	// initVelocity(u), finalVelocity(v), 
	//
	// 1. (u+v)/2 = s/t
	// 2. u + at = v
	// 3. s = ut + at^2/2
	// 4. s = vt - at^2/2
	// 5. u^2 + 2as = v^2
	//
	// pX  : A -> P
	// pYZ : A -> P
	// h   : 최고 높이.
	// g   : 중력.
	//
	// 	up					right						down
	// vUp:0				vRight:						vDown:
	// tUp:Sqrt(-2h/g)		tRight:tUp + tDown *		tDown:Sqrt(2(pY - h)/g)
	// aUp:g				aRight:0					aDown:g
	// sUp:h				sRight:pX					sDown:pY - h
	// uUp:Sqrt(-2gh) *		uRight:px / (tUp + tDown) *	uDown:0
	//-------------------------------------------------------
	public static StructInitData CalculateInitVelocityParabola(Vector3 _startPos, Vector3 _targetPos, float _h = 25f, float _gravity = -18f){
		float _pY 		= _targetPos.y - _startPos.y;
		Vector3 _pXZ 	= _targetPos - _startPos;
		_pXZ.y = 0;
		//Debug.Log ("pY:" + _pY + " pXZ:" + _pXZ);
		float _timeRight= (Mathf.Sqrt ((-2f * _h) / _gravity) + Mathf.Sqrt (2f * (_pY - _h) / _gravity));
		Vector3 _uUp 	= Mathf.Sqrt (-2f * _gravity * _h) * Vector3.up;
		Vector3 _uRight = _pXZ / _timeRight;
		//Debug.Log ( "_timeRight:" + _timeRight + " _uUp:" + _uUp  " _uRight:" + _uRight );

		Vector3 _velocity = _uUp + _uRight;
		return new StructInitData(_velocity, _timeRight);
	}

	public struct StructInitData{
		public readonly Vector3 initVelocity;
		public readonly float time;
		public StructInitData(Vector3 _v, float _t){
			initVelocity = _v;
			time = _t;
		}
	}
}
