using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorCross : MonoBehaviour {
	public Transform p0, p1, p2;

	private void OnDrawGizmos()
	{
		if (p1 == null)
			return;

		Vector3 _dir1 = p1.position - p0.position;
		Vector3 _dir2 = p2.position - p0.position;

		Gizmos.color = Color.red;
		Gizmos.DrawLine(p0.position, p1.position);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(p0.position, p2.position);

		Gizmos.color = Color.blue;
		Vector3 _cross = Vector3.Cross(_dir1, _dir2);
		Gizmos.DrawRay(p0.position, _cross * 3f);		
	}
}
