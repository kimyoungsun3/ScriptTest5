using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera2: MonoBehaviour {
	const float ANGLEX_MIN = -50f;
	const float ANGLEX_MAX = +80f;
	const float DISTANCE_MIN = 5f;
	const float DISTANCE_MAX = 20f;

	public Transform target;
	Transform trans;

	float distance = 10f;
	float angleX = 0f;
	float angleY = 0f;
	float sensivityX = 1.0f;
	float sensivityY = 4.0f;
	float sensivityD = 10.0f;
	Quaternion dirQ;
	float wheel;
	bool bMove;

	void Start () {
		trans = transform;

		trans.LookAt (target);
		angleY = trans.eulerAngles.y;
		angleX = trans.eulerAngles.x;

		bMove = true;
	}

	void Update () {
		if (Input.GetMouseButton (1)) {
			bMove = true;
			angleY += Input.GetAxis ("Mouse X") * sensivityY;//<-> 좌우이동 -> Y축이동...
			angleX -= Input.GetAxis ("Mouse Y") * sensivityX;//    상하이동 -> X축이동...
			//Debug.Log (angleY + ":"+ angleX);

			//angleX = Mathf.Clamp (angleX, ANGLEX_MIN, ANGLEX_MAX);
		}

		wheel = Input.GetAxis ("Mouse ScrollWheel");
		if (wheel != 0) {
			bMove = true;
			distance -= Input.GetAxis ("Mouse ScrollWheel") * sensivityD;
			//Debug.Log (Input.GetAxis ("Mouse ScrollWheel"));

			distance = Mathf.Clamp (distance, DISTANCE_MIN, DISTANCE_MAX);
		}
	}

	void LateUpdate(){
		if(bMove){ 
			bMove = false;
			dirQ = Quaternion.Euler (angleX, angleY, 0);
			trans.position = target.position + dirQ * Constant.V3_BACK * distance;
			trans.LookAt (target.position);
			//Debug.Log(Vector3.Distance(target.position, trans.position));
		}
	}
}
