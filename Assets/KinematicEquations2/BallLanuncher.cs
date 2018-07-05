using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLanuncher : MonoBehaviour {
	public Rigidbody ball;
	public Transform target;

	public float h = 25f;
	public float gravity = -18f;
	public bool bDebug = true;

	void Start(){
		ball.useGravity = false;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			Launch ();
		}

		if (bDebug) {
			DrawPath ();
		}
	}

	void Launch(){
		//Debug.Log ("b:" + Physics.gravity);
		Physics.gravity = Vector3.up * gravity;
		//Debug.Log ("a:" + Physics.gravity);
		ball.useGravity = true;
		ball.velocity = CalculateLaunchVelocity ().initialVelocity;
		//Debug.Log ("c:" + CalculateLaunchVelocity ());
	}

	LaunchData CalculateLaunchVelocity(){
		float displacementY = target.position.y - ball.position.y;
		Vector3 displacementXZ = target.position - ball.position;
		displacementXZ.y = 0;
		//Vector3 displacementXZ = new Vector3(target.position.x - ball.position.x, 0, target.position.z - ball.position.z);
		float time = (Mathf.Sqrt ((-2f * h) / gravity) + Mathf.Sqrt (2f * (displacementY - h) / gravity));

		Vector3 velocityY = Vector3.up * Mathf.Sqrt (-2f * gravity * h);
		Vector3 velocityXZ = displacementXZ / time;

		//return velocityXZ + velocityY * -Mathf.Sign(gravity);
		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
	}

	void DrawPath(){
		LaunchData _launchData = CalculateLaunchVelocity ();
		int _count = 30;
		float _time, _timeToTarget = _launchData.timeToTarget;
		Vector3 _pos;
		Vector3 _prePos = ball.position;

		for (int i = 1; i <= _count; i++) {
			_time = i / (float)_count * _timeToTarget;
			//s = ut + at^2/2
			_pos = _launchData.initialVelocity * _time + Vector3.up * gravity * _time * _time / 2f;
			_pos = _pos + ball.position;
			Debug.DrawLine (_prePos, _pos, Color.green);

			_prePos = _pos;
		}
	}

	struct LaunchData{
		public readonly Vector3 initialVelocity;
		public readonly float timeToTarget;

		public LaunchData(Vector3 _initialVelocity, float _timeToTarget){
			initialVelocity = _initialVelocity;
			timeToTarget = _timeToTarget;
		}
	}
}
