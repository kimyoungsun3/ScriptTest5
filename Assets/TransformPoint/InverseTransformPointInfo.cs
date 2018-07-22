using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseTransformPointInfo : MonoBehaviour {
	public Transform target;

	public Vector3 b_a;
	public Vector3 bITPa;
	
	// Update is called once per frame
	void Update () {
		b_a = target.position - transform.position;
		bITPa = transform.InverseTransformPoint(target.position);
	}
}
