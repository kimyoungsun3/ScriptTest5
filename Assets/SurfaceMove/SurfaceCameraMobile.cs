using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceCameraMobile : MonoBehaviour {
	const float ANGLEX_MIN = -50f;
	const float ANGLEX_MAX = +80f;
	const float DISTANCE_MIN = 3f;
	const float DISTANCE_MAX = 20f;

	public Transform target;
	Transform trans;

	float distance = 10f;
	float angleX = 0f;
	float angleY = 0f;
	float sensivityX = 0.5f;
	float sensivityY = 1.0f;
	float sensivityD = 0.1f;
	Quaternion dirQ;
	bool bMove;

	void Start () {
		trans = transform;

		trans.LookAt (target);
		angleY = trans.eulerAngles.y;
		angleX = trans.eulerAngles.x;

		bMove = true;
	}

	int touchCount;
	Touch t0, t1;
	Vector2 t0OldPos, t1OldPos;
	float distanceOld, distanceCur, deltaDistance;
	void Update () {
		touchCount = Input.touchCount;
		if (touchCount > 0) {
			t0 = Input.GetTouch (0);
			if (touchCount == 1) {
				if (t0.deltaPosition != Constant.V2_ZERO) {
					bMove = true;
					angleY += t0.deltaPosition.x * sensivityY;
					angleX -= t0.deltaPosition.y * sensivityX;
					//Debug.Log (t0.deltaPosition + ":" + currentX + ":"+ currentY);

					angleX = Mathf.Clamp (angleX, ANGLEX_MIN, ANGLEX_MAX);
				}
			} else if (Input.touchCount == 2) {
				t1 = Input.GetTouch (1);
				if (t0.deltaPosition != Constant.V2_ZERO || t1.deltaPosition != Constant.V2_ZERO) {
					bMove = true;

					t0OldPos = t0.position - t0.deltaPosition;
					t1OldPos = t1.position - t1.deltaPosition;

					distanceOld = Vector2.Distance (t0OldPos, t1OldPos);
					distanceCur = Vector2.Distance (t0.position, t1.position);
					deltaDistance = distanceOld - distanceCur;
					//Debug.Log (t0.deltaPosition + ":" + t1.deltaPosition);
					//Debug.Log (deltaDistance + ":" + (t0.deltaPosition + t1.deltaPosition).magnitude);

					distance += deltaDistance * sensivityD;
					distance = Mathf.Clamp (distance, DISTANCE_MIN, DISTANCE_MAX);
				}
			}
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
