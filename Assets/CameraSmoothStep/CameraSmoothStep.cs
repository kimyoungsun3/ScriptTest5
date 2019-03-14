using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothStep : MonoBehaviour {
	public Transform target;
	Transform trans;
	Vector3 position;
	public float smoothStepSpeed = 0.3f;

	private void Start()
	{
		trans		= transform;
		position	= trans.position;
	}
	void Update () {
		position.x = Mathf.SmoothStep(trans.position.x, target.position.x, smoothStepSpeed);
		position.y = Mathf.SmoothStep(trans.position.y, target.position.y, smoothStepSpeed);

		trans.position = position;
	}
}
