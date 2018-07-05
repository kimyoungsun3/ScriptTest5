using UnityEngine;
using System.Collections;

public class RaycastTest2D : MonoBehaviour {
	//public QueryTriggerInteraction query;
	public float distance = 10f;
	public LayerMask mask;
	public float speed = 90f;
	Ray ray;
	RaycastHit2D hit;
	public float directionBasu = 1f;

	void Start(){
		Debug.Log (" Vertical > rotate");
	}

	void Update () {
		ray.origin 		= transform.position;
		ray.direction 	= transform.right * directionBasu;
		hit = Physics2D.Raycast (ray.origin, ray.direction, distance, mask);
		//hit = Physics2D.Raycast (ray, out hit, distance, mask, query);

		if (hit) {
			Debug.Log (" > 2D hit");
			Debug.DrawLine (transform.position, hit.point, Color.green);
		} else {
			Debug.DrawLine (transform.position, ray.origin + ray.direction * distance, Color.grey);
		}

		float _v = Input.GetAxisRaw ("Vertical");
		if (_v != 0) {
			transform.Rotate (_v * Vector3.forward * speed * Time.deltaTime);
		}
			
	}
}
