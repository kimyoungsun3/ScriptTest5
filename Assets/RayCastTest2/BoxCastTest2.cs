using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCastTest2 : MonoBehaviour {
	public LayerMask mask;
	Ray ray;
	RaycastHit hit;
	public QueryTriggerInteraction query = QueryTriggerInteraction.UseGlobal;
	public float distance = 100f;
	float v;
	public float speed = 30;

	void Update(){
		v = Input.GetAxisRaw ("Vertical");
		transform.Rotate (-v * Vector3.right * Time.deltaTime * speed);
	}


	void OnDrawGizmos () {
		ray.origin 		= transform.position;
		ray.direction 	= transform.forward;
		if (Physics.BoxCast (ray.origin, transform.lossyScale/2, ray.direction, out hit, transform.rotation, distance, mask, query)) {
			Gizmos.color = Color.green;
			Gizmos.DrawRay (ray.origin, ray.direction * hit.distance);
			Gizmos.DrawWireCube (ray.origin + ray.direction * hit.distance, transform.lossyScale);
		} else {
			Gizmos.color = Color.grey;
			Gizmos.DrawLine (ray.origin, ray.origin + ray.direction * distance);
		}
	}
}
