using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour {
	public Transform target;
	public Transform minT, maxT;
	Vector2 min, max;
	Transform trans;
	Vector3 pos, currentVelocity;
	float depthZ;

	void Start () {
		trans = transform;
		min = minT.position;
		max = maxT.position;
		depthZ = trans.position.z;		
	}


	void Update () {
		if(target != null){
			pos = target.position;
			pos.x = Mathf.Clamp (pos.x, min.x, max.x);
			pos.y = Mathf.Clamp (pos.y, min.y, max.y);
			pos.z = depthZ;

			trans.position = Vector3.SmoothDamp (trans.position, pos, ref currentVelocity, 0.15f);
		}
		
	}
}
