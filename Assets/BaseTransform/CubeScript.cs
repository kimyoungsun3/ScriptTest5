using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {
	public Transform target;
	public float speed = 2f;
	public float speedTurn = 180f;
	public int mode = -1;
	Vector3 p1, p2;
	Quaternion q1, q2;

	void Start () {
		target.SetParent (transform);

		p1 = transform.position;
		q1 = transform.rotation;
		p2 = target.position;
		q2 = target.rotation;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			mode = -1;
			transform.position = p1;
			transform.rotation = q1;
			target.position = p2;
			target.rotation = q2;
		}

		if(mode == 0)
			transform.position += transform.forward * speed * Time.deltaTime;
		else if (mode == 1)
			transform.position += Vector3.forward * speed * Time.deltaTime;

		else if (mode == 10)
			transform.Translate(transform.forward * speed * Time.deltaTime);
		else if (mode == 11)
			transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
		else if (mode == 12)
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		else if (mode == 13)
			transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

		else if (mode == 50)
			transform.eulerAngles += transform.up * speedTurn * Time.deltaTime;
		else if (mode == 51)
			transform.eulerAngles += Vector3.up * speedTurn * Time.deltaTime;
		
		else if (mode == 61)
			transform.Rotate (transform.up * speedTurn * Time.deltaTime);
		else if (mode == 62)
			transform.Rotate (transform.up * speedTurn * Time.deltaTime, Space.World);
		else if (mode == 63)
			transform.Rotate (Vector3.up * speedTurn * Time.deltaTime);
		else if (mode == 64)
			transform.Rotate (Vector3.up * speedTurn * Time.deltaTime, Space.World);
	}

	void OnDrawGizmos(){
		Debug.DrawRay (transform.position, transform.right, Color.red);
		Debug.DrawRay (transform.position, transform.up, Color.green);
		Debug.DrawRay (transform.position, transform.forward, Color.blue);


		Debug.DrawRay (target.position, target.right, Color.red);
		Debug.DrawRay (target.position, target.up, Color.green);
		Debug.DrawRay (target.position, target.forward, Color.blue);
	}
}
