using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera20 : MonoBehaviour {
	public float ANGLEX_MIN = -60f;
	public float ANGLEX_MAX = +80f;
	public float DISTANCE_MIN = 1f;
	public float DISTANCE_MAX = 15f;

	public Transform target;
	Vector3 targetPosOld;
	MoveControllerMaster targetScp;

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

		targetScp = target.GetComponent<MoveControllerMaster> ();
		trans.LookAt (target);

		angleY = trans.eulerAngles.y;
		angleX = trans.eulerAngles.x;
		//Debug.Log ("Start1 > " + angleX + ":" + angleY);
		if (angleX >= 180f) {
			angleX = 360 - angleX; 
		}

		bMove = true;
		//Debug.Log ("Start2 > " + angleX + ":" + angleY);
	}

	void Update () {
		if (Input.GetMouseButton (1)) {
			bMove = true;
			angleX -= Input.GetAxis ("Mouse Y") * sensivityX;//    상하이동 -> X축이동...
			angleY += Input.GetAxis ("Mouse X") * sensivityY;//<-> 좌우이동 -> Y축이동...
			//Debug.Log (
			//	" " + Input.GetAxis ("Mouse Y") + " -> " + angleX
			//	+ " " + Input.GetAxis ("Mouse X") + " -> " + angleY
			//);
			angleX = Mathf.Clamp (angleX, ANGLEX_MIN, ANGLEX_MAX);
		}

		wheel = Input.GetAxis ("Mouse ScrollWheel");
		if (wheel != 0) {
			bMove = true;
			distance -= Input.GetAxis ("Mouse ScrollWheel") * sensivityD;
			//Debug.Log (Input.GetAxis ("Mouse ScrollWheel") + " -> " + distance);

			distance = Mathf.Clamp (distance, DISTANCE_MIN, DISTANCE_MAX);
		}

		//마우스 이동 없이 전진....
		//Debug.Log(bMove + ":" + target.position + ":" + targetPosOld);
		//if (!bMove && targetScp.input != Constant.V2_ZERO) {
		//	angleY = target.eulerAngles.y;
		//	Debug.Log (" AngleY ->");
		//}
	}

	void LateUpdate(){
		if(bMove || target.position != targetPosOld){ 
			//Debug.Log ("LateUpdate > " + angleX + ":" + angleY);
			//Debug.Log ("   ->");
			bMove = false;
			dirQ = Quaternion.Euler (angleX, angleY, 0);
			trans.position = target.position + dirQ * Constant.V3_BACK * distance;
			trans.LookAt (target.position);
			//Debug.Log(Vector3.Distance(target.position, trans.position));
		}
		targetPosOld = target.position;
	}
}
