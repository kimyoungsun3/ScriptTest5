using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest2 : MonoBehaviour {
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
		if(Physics.Raycast(ray, out hit, distance, mask, query)){
			Gizmos.color = Color.green;
			Gizmos.DrawLine (ray.origin, hit.point);
		}else{
			Gizmos.color = Color.grey;
			Gizmos.DrawLine (ray.origin, ray.origin + ray.direction * distance);
		}
		
	}
}
