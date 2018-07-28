using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMDoor : MonoBehaviour {
	public float speed = 3;
	public float wayPointWaitTime = 2f;
	float delayTime;
	public Transform[] points;
	int index = -1;

	void Start(){
		index = points.Length > 0? 0:-1;
	}

	void Update(){
		if (index != -1 && Time.time > delayTime) {
			transform.position = Vector3.MoveTowards (transform.position, points [index].position, speed * Time.deltaTime);

			if (transform.position == points [index].position) {
				delayTime = Time.time + wayPointWaitTime;
				index++;
				if (index >= points.Length) {
					index = 0;
				}
			}
		}

	}
}
