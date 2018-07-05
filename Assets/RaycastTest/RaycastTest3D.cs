using UnityEngine;
using System.Collections;

public class RaycastTest3D : MonoBehaviour {
	public QueryTriggerInteraction query;
	public float distance = 100f;
	public LayerMask mask;
	public float speed = 90f;
	Ray ray;
	RaycastHit hit;
	public float directionBasu = 1f;

	void Start(){
		Debug.Log (" Vertical > rotate");
	}

	void Update () {
		ray.origin 		= transform.position;
		ray.direction 	= transform.forward * directionBasu;

		if (Physics.Raycast (ray, out hit, distance, mask, query)) {
			Debug.Log (" > 3D hit");
			Debug.DrawLine (transform.position, hit.point, Color.green);
		} else {
			Debug.DrawLine (transform.position, ray.origin + ray.direction * distance, Color.grey);
		}

		float _v = Input.GetAxisRaw ("Vertical");
		if (_v != 0) {
			transform.Rotate (-_v * Vector3.right * speed * Time.deltaTime);
		}
			
	}
}
