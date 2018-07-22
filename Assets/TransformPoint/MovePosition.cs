using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition : MonoBehaviour {
	public Transform targetPlus, targetTransformPoint;
	public Vector3 b_a = new Vector3(1, -1, 0);

	
	// Update is called once per frame
	void Update () {
		targetPlus.position = transform.position + b_a;	
		targetTransformPoint.position = transform.TransformPoint (b_a);	
	}
}
