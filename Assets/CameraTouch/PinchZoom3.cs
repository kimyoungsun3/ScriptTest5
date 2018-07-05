using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom3 : MonoBehaviour {

	public float speedZoomPerspective = 0.08f;
	public float speedMovePerspective = .1f;
	//public Vector2 perspectiveZoomMinMax = new Vector2 (10f, 179f);
	public float speedZoomOrtho = 0.08f;
	public float speedMoveOrtho = 1f;
	public Vector2 orthoZoomMinMax = new Vector2 (1f, 15f);

	Touch t0, t1;
	Vector2 t0OldPos, t1OldPos;
	float distanceOld, distanceCur, deltaDistance;
	int touchCount;
	Transform trans;
	Vector3 move;

	Transform target;
	Camera camera;
	System.Action callbackTouch;

	void Start(){
		trans = transform;
		camera = GetComponent<Camera> ();
		if (camera.orthographic) {
			callbackTouch = TouchOrthographics;
		} else {
			callbackTouch = TouchPerspective;
		}			
	}

	void Update () {
		touchCount = Input.touchCount;
		if (touchCount > 0) {
			if (callbackTouch != null) {
				callbackTouch ();
			}
		}
	}

	void TouchOrthographics(){
		t0 = Input.GetTouch (0);
		if (touchCount == 1) {
			//trans.Translate (-t0.deltaPosition * Time.deltaTime * speedMoveOrtho);
			trans.Translate (-t0.deltaPosition * speedMoveOrtho);
		}else if (Input.touchCount == 2) {
			t1 = Input.GetTouch (1);

			t0OldPos = t0.position - t0.deltaPosition;
			t1OldPos = t1.position - t1.deltaPosition;

			distanceOld = Vector2.Distance (t0OldPos, t1OldPos);
			distanceCur = Vector2.Distance (t0.position, t1.position);
			deltaDistance = distanceOld - distanceCur;

			camera.orthographicSize += deltaDistance * speedZoomOrtho;
			camera.orthographicSize = Mathf.Clamp (camera.orthographicSize, orthoZoomMinMax.x, orthoZoomMinMax.y);
		}
	}

	float targetDistance;
	Vector3 targetDir;
	void TouchPerspective(){
		t0 = Input.GetTouch (0);
		if (touchCount == 1) {
			//trans.Translate (-t0.deltaPosition * Time.deltaTime * speedMovePerspective);
			if (t0.phase == TouchPhase.Began) {
				Ray _ray = camera.ScreenPointToRay (t0.position);
				RaycastHit _hit;
				if (Physics.Raycast (_ray, out _hit, camera.farClipPlane)) {
					target = _hit.collider.transform;
					targetDistance = Vector3.Distance (target.position, trans.position);
				}
			}else if(t0.phase == TouchPhase.Ended){
				target = null;
			}
			trans.Translate (-t0.deltaPosition * speedMovePerspective);

			if (target != null) {
				targetDir = target.position - trans.position;
				targetDir = Vector3.ClampMagnitude (targetDir, targetDistance);
				trans.position = target.position - targetDir;
				//trans.rotation = Quaternion.FromToRotation (Vector3.forward, targetDir);	//일정 각도에서 짐벌락...
				//trans.LookAt (target);													//일정 각도에서 짐벌락...
				//trans.rotation = Quaternion.FromToRotation (trans.forward, targetDir);	//튀는 현상 발생...
				trans.rotation = Quaternion.FromToRotation (trans.forward, targetDir) * trans.rotation;
			}



		}else if (Input.touchCount == 2) {
			t1 = Input.GetTouch (1);

			t0OldPos = t0.position - t0.deltaPosition;
			t1OldPos = t1.position - t1.deltaPosition;

			distanceOld = Vector2.Distance (t0OldPos, t1OldPos);
			distanceCur = Vector2.Distance (t0.position, t1.position);
			deltaDistance = distanceOld - distanceCur;

			//Debug.Log ("> perspect");
			trans.Translate (-Vector3.forward * deltaDistance * speedZoomPerspective);
			//camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
			//camera.fieldOfView = Mathf.Clamp (camera.fieldOfView, perspectiveZoomMinMax.x, perspectiveZoomMinMax.y);
		}

	}
}
